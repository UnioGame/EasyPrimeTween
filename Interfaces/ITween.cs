namespace Game.Runtime.EasyPrimeTweens.Interfaces
{
    using Data;
    using PrimeTween;

    public interface ITween
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