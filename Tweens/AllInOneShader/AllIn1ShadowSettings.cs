namespace Game.Runtime.EasyPrimeTweens.Tweens
{
    using System;
    using Data;
    using PrimeTween;
    using UniCore.Runtime.ProfilerTools;
    using UniGame.Core.Runtime.Extension;
    using UnityEngine;
    using UnityEngine.UI;
    using Object = UnityEngine.Object;

    [Serializable]
    public class AllIn1ShadowSettings : IAllIn1Settings
    {
        [Header("General Properties")]
        [SerializeField]
        private Image image;
        [SerializeField]
        private PlayInSequenceType playInSequenceType;
        
        [Header("Start Value")]
        [SerializeField, Range(-0.5f, 0.5f)]
        private float startShadowX;
        [SerializeField, Range(-0.5f, 0.5f)]
        private float startShadowY;
        [SerializeField, Range(0f, 1f)]
        private float startShadowAlpha;
        [SerializeField]
        private Color startShadowColor = Color.white;
        
        [Header("End Value")]
        [SerializeField, Range(-0.5f, 0.5f)]
        private float endShadowX;
        [SerializeField, Range(-0.5f, 0.5f)]
        private float endShadowY;
        [SerializeField, Range(0f, 1f)]
        private float endShadowAlpha;
        [SerializeField]
        private Color endShadowColor = Color.white;
        
        public Image Image => image;
        public PlayInSequenceType PlayInSequenceType => playInSequenceType;
        
        private const string Name = "InstanceMaterial";
        private Tween[] _tweens = new Tween[4];
        private Material _materialInstance;

        public void Reset()
        {
            MaterialInstance().SetFloat(AllIn1SpriteShaderProperties.ShadowX, startShadowX);
            MaterialInstance().SetFloat(AllIn1SpriteShaderProperties.ShadowY, startShadowY);
            MaterialInstance().SetFloat(AllIn1SpriteShaderProperties.ShadowAlpha, startShadowAlpha);
            MaterialInstance().SetColor(AllIn1SpriteShaderProperties.ShadowColor, startShadowColor);
        }
        
        public void Play(float elapsedTime)
        {
            foreach (var tween in _tweens)
            {
                if (tween.isAlive)
                {
                    tween.elapsedTime = elapsedTime;
                    Debug.Log($"elapsedTime: {elapsedTime}");
                }
            }
        }
        
        public void Stop()
        {
            foreach (var tween in _tweens)
            {
                if (tween.isAlive)
                    tween.Stop();
            }
        }
        
        public bool CheckEnable()
        {
            return MaterialInstance().IsKeywordEnabled(AllIn1SpriteShaderProperties.ShadowOn);
        }
        
        public void TryCreateTween(float animationTime, bool isForward)
        {
            if (!CheckEnable()) return;
            if (_tweens.IsNullOrEmpty()) return;
            
            _tweens[0] = isForward 
                ? CreateTween(startShadowX, endShadowX, AllIn1SpriteShaderProperties.ShadowX, animationTime)
                : CreateTween(endShadowX, startShadowX, AllIn1SpriteShaderProperties.ShadowX, animationTime);
            _tweens[1] = isForward
                ? CreateTween(startShadowY, endShadowY, AllIn1SpriteShaderProperties.ShadowY, animationTime)
                : CreateTween(endShadowY, startShadowY, AllIn1SpriteShaderProperties.ShadowY, animationTime);
            _tweens[2] = isForward
                ? CreateTween(startShadowAlpha, endShadowAlpha, AllIn1SpriteShaderProperties.ShadowAlpha, animationTime)
                : CreateTween(endShadowAlpha, startShadowAlpha, AllIn1SpriteShaderProperties.ShadowAlpha, animationTime);
            _tweens[3]  = isForward
                ? CreateTween(startShadowColor, endShadowColor, AllIn1SpriteShaderProperties.ShadowColor,animationTime)
                : CreateTween(endShadowColor, startShadowColor, AllIn1SpriteShaderProperties.ShadowColor, animationTime); 
        }
        
        private Tween CreateTween(float startValue, float endValue, string propertyName, float animationTime)
        {
            if (startValue.Equals(endValue)) return default;

            return Tween.Custom(
                startValue: startValue,
                endValue: endValue,
                duration: animationTime,
                onValueChange: x =>
                {
                    MaterialInstance().SetFloat(propertyName, x);
                });
        }

        private Tween CreateTween(Color startValue, Color endValue, string propertyName, float animationTime)
        {
            if (startValue.Equals(endValue)) return default;

            return Tween.Custom(
                startValue: startValue,
                endValue: endValue,
                duration: animationTime,
                onValueChange: x =>
                { 
                    MaterialInstance().SetColor(propertyName, x);
                });
        }

        private Material MaterialInstance()
        {
            if (!image || !image.material)
            {
                GameLog.LogError("Image or Material is null");
                return null;
            }
            
            if (image.material.name.Equals(Name)) return image.material;
            if (_materialInstance) return _materialInstance;
            
            _materialInstance = new Material(image.material)
            {
                name = Name
            };
            image.material = _materialInstance;

            return _materialInstance;
        }

        public void Dispose()
        {
            if (!_materialInstance) return;
            Object.Destroy(_materialInstance);
            GameLog.Log($"Dispose {nameof(AllIn1ShadowSettings)}");
        }
    }
}