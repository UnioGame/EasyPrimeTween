namespace Game.Runtime.EasyPrimeTweens
{
    using System;
    using Data;
    using Interfaces;
    using PrimeTween;
    using Sirenix.OdinInspector;
    using UnityEngine;

    public class EasyPrimeSequence : MonoBehaviour, IEasyPrimeSequence
    {
        [BoxGroup("Settings"), HideLabel]
        [SerializeField]
        private SequenceSettings sequenceSettings;

        [SerializeField, BoxGroup("Settings")]
        private bool playOnEnable;

        [SerializeReference]
        public ITween[] tweens;

        private Sequence _sequence;
        private Sequence _backwardsSequence;

        public Sequence Sequence => _sequence;
        public Sequence BackwardSequence => _backwardsSequence;

        public void OnEnable()
        {
            if (playOnEnable)
                Play();
        }

        [ButtonGroup]
        public void Play()
        {
            if (_backwardsSequence.isAlive)
                _backwardsSequence.Stop();

            if (_sequence.isAlive) return;

            _sequence = Sequence.Create(
                sequenceSettings.cycles,
                sequenceSettings.cycleMode,
                sequenceSettings.sequenceEase,
                sequenceSettings.useUnscaledTime,
                sequenceSettings.useFixedUpdate
            );

            foreach (var tween in tweens)
            {
                tween.Play();
                if (!tween.Tween.isAlive) continue;
                switch (tween.PlayInSequenceType)
                {
                    case PlayInSequenceType.Chain:
                        _sequence.Chain(tween.Tween);
                        break;
                    case PlayInSequenceType.Group:
                        _sequence.Group(tween.Tween);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        [ButtonGroup]
        public void Backwards()
        {
            if (_sequence.isAlive)
                _sequence.Stop();

            if (_backwardsSequence.isAlive) return;

            _backwardsSequence = Sequence.Create();

            for (var i = tweens.Length - 1; i >= 0; i--)
            {
                var tween = tweens[i];
                tween.Backward();

                if (!tween.Tween.isAlive) continue;

                switch (tween.PlayInSequenceType)
                {
                    case PlayInSequenceType.Chain:
                        _backwardsSequence.Chain(tween.BackwardTween);
                        break;
                    case PlayInSequenceType.Group:
                        _backwardsSequence.Group(tween.BackwardTween);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        [ButtonGroup]
        public void Stop()
        {
            if (_sequence.isAlive)
                _sequence.Stop();

            if (_backwardsSequence.isAlive)
                _backwardsSequence.Stop();
        }

        [ButtonGroup]
        public void Reset()
        {
            Stop();

            foreach (var tween in tweens)
            {
                tween.Reset();
            }
        }

        public void Restart()
        {
            Reset();
            Play();
        }

        private void OnDisable() => Stop();
    }
}