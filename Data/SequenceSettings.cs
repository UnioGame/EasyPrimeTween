namespace Game.Runtime.EasyPrimeTweens.Data
{
    using System;
    using PrimeTween;
    using Sirenix.OdinInspector;

    [Serializable]
    public class SequenceSettings
    {
        public int cycles = 1;
        [ShowIf(nameof(ShowCycleMode))]
        public CycleMode cycleMode = CycleMode.Restart;
        public Ease sequenceEase = Ease.Linear;
        public bool useUnscaledTime = false;
        public bool useFixedUpdate = false;
        
        private bool ShowCycleMode()
        {
#if UNITY_EDITOR
            return cycles < 0;
#else
            return true;
#endif
        } 
    }
}