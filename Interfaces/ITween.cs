namespace Game.Runtime.EasyPrimeTweens.Interfaces
{
    using System;
    using Data;
    using PrimeTween;

    public interface ITween : IDisposable
    {
        Tween Tween { get; }
        Tween BackwardTween { get; }
        PlayInSequenceType PlayInSequenceType { get; }
        void Play();
        void Backward();
        void Stop();
        void Reset();
    }
}