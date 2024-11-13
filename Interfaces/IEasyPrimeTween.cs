namespace Game.Runtime.EasyPrimeTweens.Interfaces
{
    using PrimeTween;

    public interface IEasyPrimeTween
    {
        Tween Tween { get; }
        Tween BackwardTween { get; }
        void Play();
        void Backwards();
        void Stop();
        void Reset();
        void Restart();
    }
}