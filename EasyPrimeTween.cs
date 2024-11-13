namespace Game.Runtime.EasyPrimeTweens
{
    using Interfaces;
    using PrimeTween;
    using Sirenix.OdinInspector;
    using UnityEngine;

    public class EasyPrimeTween : MonoBehaviour, IEasyPrimeTween
    {
        [SerializeField, BoxGroup("Settings")]
        private bool playOnEnable;
        
        [SerializeReference]
        public ITween tween;

        public Tween Tween => tween.Tween;
        public Tween BackwardTween => tween.BackwardTween;
        
        public void OnEnable()
        {
            if(playOnEnable)
                Play();
        }
        
        public void Play()
        {
            if (tween.BackwardTween.isAlive)
                tween.BackwardTween.Stop();

            if (tween.Tween.isAlive) return;

            tween.Play();
        }
        
        public void Backwards()
        {
            if (tween.Tween.isAlive)
                tween.Tween.Stop();

            if (tween.BackwardTween.isAlive) return;

            tween.Backward();
        }
        
        public void Stop()
        {
            if (tween.Tween.isAlive)
                tween.Tween.Stop();

            if (tween.BackwardTween.isAlive)
                tween.BackwardTween.Stop();
        }
        
        public void Reset()
        {
            Stop();
            
            tween.Reset();
        }

        public void Restart()
        {
            Reset();
            Play();
        }

        private void OnDisable() =>  Stop();
    }
}