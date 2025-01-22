namespace Game.Runtime.EasyPrimeTweens.Tweens
{
    using System;
    using Data;
    using Interfaces;
    using PrimeTween;
    using Sirenix.OdinInspector;
    using UnityEngine;

    [Serializable]
    public class AllIn1ShaderTween : ITween
    {
        [TabGroup("General", TextColor = "blue"), SerializeReference]
        [HideLabel]
        private IAllIn1Settings allIn1Settings;

        [TabGroup("Animation", TextColor = "green"), SerializeField]
        private TweenSettings<float> settings;

        private Tween _tween;
        private Tween _backwardTween;

        public Tween Tween => _tween;
        public Tween BackwardTween => _backwardTween;
        public PlayInSequenceType PlayInSequenceType => allIn1Settings.PlayInSequenceType;

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
            ResetPositionScale();
        }

        private void ResetPositionScale()
        {
            allIn1Settings.Reset();
        }

        private void CreatePlayTween()
        {
            if (_backwardTween.isAlive)
                _backwardTween.Stop();

            StopTween();
            
            allIn1Settings.TryCreateTween(settings.settings.duration, true);
            _tween = CreateTween(settings);
        }

        private void CreateBackwardTween()
        {
            if (_tween.isAlive)
                _tween.Stop();

            StopTween();

            var newSettings = settings;
            newSettings.startValue = settings.endValue;
            newSettings.endValue = settings.startValue;
            
            allIn1Settings.TryCreateTween(newSettings.settings.duration, false);
            _backwardTween = CreateTween(newSettings);
        }

        private Tween CreateTween(TweenSettings<float> value)
        {
            var mockValue = 0f;
            var tween = Tween.Custom(value, x => mockValue = x);

            return tween;
        }

        private void StopTween()
        {
            if (_tween.isAlive)
                _tween.Stop();

            if (_backwardTween.isAlive)
                _backwardTween.Stop();

            allIn1Settings.Stop();
        }

        public void Dispose()
        {
            allIn1Settings?.Dispose();
        }
    }
}