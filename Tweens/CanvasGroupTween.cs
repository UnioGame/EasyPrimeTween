namespace Game.Runtime.EasyPrimeTweens.Tweens
{
    using System;
    using Data;
    using Interfaces;
    using PrimeTween;
    using Settings;
    using Sirenix.OdinInspector;
    using UnityEngine;

    [Serializable]
    public class CanvasGroupTween : ITween
    {
        [TabGroup("General", TextColor = "blue"), SerializeField]
        [HideLabel]
        private CanvasGroupTweenSettings canvasGroupTweenSettings;

        [TabGroup("Animation", TextColor = "green"), SerializeField]
        private CanvasGroup target;

        [TabGroup("Animation", TextColor = "green"), SerializeField]
        private TweenSettings<float> settings;

        private Tween _tween;
        private Tween _backwardTween;

        public Tween Tween => _tween;
        public Tween BackwardTween => _backwardTween;

        public PlayInSequenceType PlayInSequenceType => canvasGroupTweenSettings.GetPlayInSequenceType();

        [ButtonGroup]
        public void Play()
        {
            if (_tween.isAlive) return;

            CreatePlayTween();
        }

        [ButtonGroup]
        public void Backward()
        {
            if (_backwardTween.isAlive) return;

            CreateBackwardTween();
        }

        [ButtonGroup]
        public void Stop()
        {
            StopTween();
        }

        [ButtonGroup]
        public void Reset()
        {
            StopTween();
            CheckGeneralSettings();

            ResetRotate();
        }

        private void ResetRotate()
        {
            target.alpha = settings.startValue;
            target.interactable = canvasGroupTweenSettings.StartAnimation.interactable;
            target.blocksRaycasts = canvasGroupTweenSettings.StartAnimation.blocksRaycasts;
            target.ignoreParentGroups = canvasGroupTweenSettings.StartAnimation.ignoreParentGroups;
        }

        private void CreatePlayTween()
        {
            if (_backwardTween.isAlive)
                _backwardTween.Stop();

            StopTween();
            CheckGeneralSettings();

            if (Mathf.Approximately(target.alpha, settings.endValue)) return;

            _tween = CreateTween(settings, false);
        }

        private void CreateBackwardTween()
        {
            if (_tween.isAlive)
                _tween.Stop();

            StopTween();
            CheckGeneralSettings();

            var newSettings = settings;
            newSettings.startValue = settings.endValue;
            newSettings.endValue = settings.startValue;

            if (Mathf.Approximately(target.alpha, newSettings.endValue)) return;

            _backwardTween = CreateTween(newSettings, true);
        }

        private Tween CreateTween(TweenSettings<float> value, bool isBackwards)
        {
            var interactable = isBackwards
                ? canvasGroupTweenSettings.StartAnimation.interactable
                : canvasGroupTweenSettings.EndAnimation.interactable;

            var blocksRaycasts = isBackwards
                ? canvasGroupTweenSettings.StartAnimation.blocksRaycasts
                : canvasGroupTweenSettings.EndAnimation.blocksRaycasts;

            var ignoreParentGroups = isBackwards
                ? canvasGroupTweenSettings.StartAnimation.ignoreParentGroups
                : canvasGroupTweenSettings.EndAnimation.ignoreParentGroups;

            var tween = Tween.Alpha(target, value);

            tween.OnComplete(() =>
            {
                target.interactable = interactable;
                target.blocksRaycasts = blocksRaycasts;
                target.ignoreParentGroups = ignoreParentGroups;
            });

            return tween;
        }

        private void CheckGeneralSettings()
        {
            if (!canvasGroupTweenSettings.From) return;
            canvasGroupTweenSettings.SetFromValue(target.alpha);
            settings.startValue = canvasGroupTweenSettings.FromValue;
        }

        private void StopTween()
        {
            if (_tween.isAlive)
                _tween.Stop();

            if (_backwardTween.isAlive)
                _backwardTween.Stop();
        }
    }
}