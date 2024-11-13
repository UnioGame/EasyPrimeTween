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
    public class RotateTween : ITween
    {
        [TabGroup("General", TextColor = "blue"), SerializeField]
        [HideLabel]
        private Vector3TweenSettings vector3TweenSettings;

        [TabGroup("Animation", TextColor = "green"), SerializeField]
        private Transform target;

        [TabGroup("Animation", TextColor = "green"), SerializeField]
        private TweenSettings<Vector3> settings;

        private Tween _tween;
        private Tween _backwardTween;

        public Tween Tween => _tween;
        public Tween BackwardTween => _backwardTween;

        public PlayInSequenceType PlayInSequenceType => vector3TweenSettings.GetPlayInSequenceType();

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
            target.eulerAngles = settings.startValue;
        }

        private void CreatePlayTween()
        {
            if (_backwardTween.isAlive)
                _backwardTween.Stop();

            StopTween();
            CheckGeneralSettings();

            var currentRotation = vector3TweenSettings.LocalOrientation
                ? target.localEulerAngles
                : target.eulerAngles;

            if (currentRotation == settings.endValue) return;

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

            var currentRotation = vector3TweenSettings.LocalOrientation
                ? target.localEulerAngles
                : target.eulerAngles;

            if (currentRotation == newSettings.endValue) return;

            _backwardTween = CreateTween(newSettings);
        }

        private Tween CreateTween(TweenSettings<Vector3> value)
        {
            return vector3TweenSettings.LocalOrientation
                ? Tween.LocalEulerAngles(target, value)
                : Tween.EulerAngles(target, value);
        }

        private void CheckGeneralSettings()
        {
            if (!vector3TweenSettings.From) return;
            vector3TweenSettings.SetFromValue(target.eulerAngles);
            settings.startValue = vector3TweenSettings.FromValue;
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