namespace Game.Runtime.EasyPrimeTweens.Interfaces
{
    using PrimeTween;

    public interface IEasyPrimeSequence
    {
        Sequence Sequence { get; }
        Sequence BackwardSequence { get; }
        void Play();
        void Backwards();
        void Stop();
        void Reset();
    }
}