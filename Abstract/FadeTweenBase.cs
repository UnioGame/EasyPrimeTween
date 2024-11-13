namespace Game.Runtime.EasyPrimeTweens.Abstract
{
    using Data;
    using Interfaces;
    using PrimeTween;
    using Settings;
    using Sirenix.OdinInspector;
    using UnityEngine;
    using UnityEngine.UI;

    public class FadeTweenBase<T> : ITween where T : Graphic
    {
        [TabGroup("General", TextColor = "blue"), SerializeField, HideLabel]
        private FloatTweenSettings floatTweenSettings;

        [TabGroup("Animation", TextColor = "green"), SerializeField]
        private T target;

        [TabGroup("Animation", TextColor = "green"), SerializeField]
        private TweenSettings<float> settings;

        private Tween _tween;
        private Tween _backwardTween;

        public Tween Tween => _tween;
        public Tween BackwardTween => _backwardTween;
        public PlayInSequenceType PlayInSequenceType => floatTweenSettings.GetPlayInSequenceType();

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
            ResetAlpha();
        }

        private void ResetAlpha()
        {
            var tempColor = target.color;
            tempColor.a = settings.startValue;
            target.color = tempColor;
        }

        private void CreatePlayTween()
        {
            if (_backwardTween.isAlive)
                _backwardTween.Stop();

            StopTween();
            CheckGeneralSettings();

            if (Mathf.Approximately(target.color.a, settings.endValue)) return;

            _tween = CreateTween(settings);
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

            if (Mathf.Approximately(target.color.a, newSettings.endValue)) return;

            _backwardTween = CreateTween(newSettings);
        }

        private Tween CreateTween(TweenSettings<float> value)
        {
            return Tween.Alpha(target, value);
        }

        private void CheckGeneralSettings()
        {
            if (!floatTweenSettings.From) return;
            floatTweenSettings.SetFromValue(target.color.a);
            settings.startValue = floatTweenSettings.FromValue;
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