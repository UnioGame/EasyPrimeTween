namespace Game.Runtime.EasyPrimeTweens.Abstract
{
    using System;
    using Data;
    using Interfaces;
    using PrimeTween;
    using Settings;
    using Sirenix.OdinInspector;
    using UnityEngine;
    using UnityEngine.UI;

    [Serializable]
    public abstract class ColorTweenBase<T> : ITween where T : Graphic
    {
        [TabGroup("General", TextColor = "blue"), SerializeField, HideLabel]
        private ColorTweenSettings colorTweenSettings;

        [TabGroup("Animation", TextColor = "green"), SerializeField]
        private T target;

        [TabGroup("Animation", TextColor = "green"), SerializeField]
        private TweenSettings<Color> settings;

        private Tween _tween;
        private Tween _backwardTween;

        public Tween Tween => _tween;
        public Tween BackwardTween => _backwardTween;
        public PlayInSequenceType PlayInSequenceType => colorTweenSettings.GetPlayInSequenceType();

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
            ResetColor();
        }

        private void ResetColor() => target.color = settings.startValue;

        private void CreatePlayTween()
        {
            if (_backwardTween.isAlive)
                _backwardTween.Stop();

            StopTween();
            CheckGeneralSettings();

            if (target.color == settings.endValue) return;

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

            if (target.color == newSettings.endValue) return;

            _backwardTween = CreateTween(newSettings);
        }

        private Tween CreateTween(TweenSettings<Color> value)
        {
            return Tween.Custom(value, x => target.color = x);
        }

        private void CheckGeneralSettings()
        {
            if (!colorTweenSettings.From) return;
            colorTweenSettings.SetFromValue(target.color);
            settings.startValue = colorTweenSettings.FromValue;
        }

        private void StopTween()
        {
            if (_tween.isAlive)
                _tween.Stop();

            if (_backwardTween.isAlive)
                _backwardTween.Stop();
        }

        public void Dispose()
        {
            
        }
    }
}