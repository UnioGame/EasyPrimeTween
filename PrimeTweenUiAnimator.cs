namespace Game.Runtime.EasyPrimeTweens
{
    using Cysharp.Threading.Tasks;
    using PrimeTween;
    using UniCore.Runtime.ProfilerTools;
    using UniGame.Core.Runtime;
    using UniGame.UiSystem.Runtime;
    using UniGame.ViewSystem.Runtime;
    using UnityEngine;

    public class PrimeTweenUiAnimator : MonoViewAnimation
    {
        public Transform mainWindow;
        [Space(10)]
        [Header("PrimeTweenUiAnimator Settings")]
        public TweenSettings<float> showTweenSettings;
        public TweenSettings<float> hideTweenSettings;
        public TweenSettings<float> closeTweenSettings;
        
        public override async UniTask Show(IView view, ILifeTime lifeTime)
        {
            CheckTransform();
            await Tween.Scale(mainWindow, showTweenSettings);
        }
        
        public override async UniTask Hide(IView view, ILifeTime lifeTime)
        {
            CheckTransform();
            hideTweenSettings.startFromCurrent = true;
            await Tween.Scale(mainWindow, hideTweenSettings);
        }
        
        public override async UniTask Close(IView view, ILifeTime lifeTime)
        {
            CheckTransform();
            hideTweenSettings.startFromCurrent = true;
            await Tween.Scale(mainWindow, closeTweenSettings);
        }

        private bool CheckTransform()
        {
            Tween.StopAll(this);
            if (mainWindow == null)
            {
                GameLog.LogWarning($"Empty transform for animation {gameObject}. Set main window transform");
                mainWindow = transform;
                return false;
            }
            return true;
        }
    }
}