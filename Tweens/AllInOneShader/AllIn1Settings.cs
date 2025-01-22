namespace Game.Runtime.EasyPrimeTweens.Tweens
{
    using System;
    using Data;
    using UnityEngine.UI;

    public interface IAllIn1Settings : IDisposable
    {
        public Image Image { get; }
        public PlayInSequenceType PlayInSequenceType { get; }
        
        public void Reset();
        public void Play(float elapsedTime);
        public void Stop();
        public void TryCreateTween(float animationTime, bool isForward);
    }
}