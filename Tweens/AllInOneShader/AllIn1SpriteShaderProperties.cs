namespace Game.Runtime.EasyPrimeTweens.Tweens
{
    public static class AllIn1SpriteShaderProperties
    {
        // General Properties
        public const string MainTexture = "_MainTex";
        public const string MainColor = "_Color";
        public const string MainAlpha = "_Alpha";

        // Glow (Needs Post Processing Bloom to work as intended)
        public const string GlowColor = "_GlowColor";
        public const string GlowIntensity = "_Glow";
        public const string GlowGlobal = "_GlowGlobal";
        public const string GlowTextureUsed = "_GlowTexUsed";
        public const string GlowTexture = "_GlowTex";

        // Fade
        public const string FadeTexture = "_FadeTex";
        public const string FadeAmount = "_FadeAmount";
        public const string FadeBurnWidth = "_FadeBurnWidth";
        public const string FadeBurnTransition = "_FadeBurnTransition";
        public const string FadeBurnColor = "_FadeBurnColor";
        public const string FadeBurnTexture = "_FadeBurnTex";
        public const string FadeBurnGlow = "_FadeBurnGlow";

        // Outline
        public const string OutlineColor = "_OutlineColor";
        public const string OutlineAlpha = "_OutlineAlpha";
        public const string OutlineGlow = "_OutlineGlow";
        public const string OutlineHighResolution = "_Outline8Directions";
        public const string OutlinePixelPerfect = "_OutlineIsPixel";
        public const string OutlineWidth = "_OutlineWidth";
        public const string OutlinePixelWidth = "_OutlinePixelWidth";
        public const string OutlineTexture = "_OutlineTex";
        public const string OutlineTextureXSpeed = "_OutlineTexXSpeed";
        public const string OutlineTextureYSpeed = "_OutlineTexYSpeed";
        public const string OutlineTextureGreyscale = "_OutlineTexGrey";
        public const string OutlineDistortionToggle = "_OutlineDistortToggle";
        public const string OutlineDistortionTexture = "_OutlineDistortTex";
        public const string OutlineDistortionAmount = "_OutlineDistortAmount";
        public const string OutlineDistortionXSpeed = "_OutlineDistortTexXSpeed";
        public const string OutlineDistortionYSpeed = "_OutlineDistortTexYSpeed";

        // Alpha Outline
        public const string AlphaOutlineColor = "_AlphaOutlineColor";
        public const string AlphaOutlineGlow = "_AlphaOutlineGlow";
        public const string AlphaOutlinePower = "_AlphaOutlinePower";
        public const string AlphaOutlineMinAlpha = "_AlphaOutlineMinAlpha";
        public const string AlphaOutlineBlend = "_AlphaOutlineBlend";

        // Inner Outline
        public const string InnerOutlineColor = "_InnerOutlineColor";
        public const string InnerOutlineThickness = "_InnerOutlineThickness";
        public const string InnerOutlineAlpha = "_InnerOutlineAlpha";
        public const string InnerOutlineGlow = "_InnerOutlineGlow";

        // Gradient
        public const string GradientBlend = "_GradBlend";
        public const string GradientTopLeftColor = "_GradTopLeftCol";
        public const string GradientTopRightColor = "_GradTopRightCol";
        public const string GradientBottomLeftColor = "_GradBotLeftCol";
        public const string GradientBottomRightColor = "_GradBotRightCol";
        public const string GradientBoostX = "_GradBoostX";
        public const string GradientBoostY = "_GradBoostY";

        // Radial Gradient
        public const string RadialGradientTopColor = "_GradTopLeftCol";
        public const string RadialGradientBottomColor = "_GradBotLeftCol";
        public const string RadialGradientBoostX = "_GradBoostX";

        // Color Swap
        public const string ColorSwapTexture = "_ColorSwapTex";
        public const string ColorSwapRed = "_ColorSwapRed";
        public const string ColorSwapRedLuminosity = "_ColorSwapRedLuminosity";
        public const string ColorSwapGreen = "_ColorSwapGreen";
        public const string ColorSwapGreenLuminosity = "_ColorSwapGreenLuminosity";
        public const string ColorSwapBlue = "_ColorSwapBlue";
        public const string ColorSwapBlueLuminosity = "_ColorSwapBlueLuminosity";
        public const string ColorSwapBlend = "_ColorSwapBlend";

        // Hue Shift
        public const string HsvOn = "HSV_ON";
        public const string HsvShift = "_HsvShift";
        public const string HsvSaturation = "_HsvSaturation";
        public const string HsvBrightness = "_HsvBright";

        // Change 1 Color
        public const string ColorChangeTolerance = "_ColorChangeTolerance";
        public const string ColorChangeTarget = "_ColorChangeTarget";
        public const string ColorChangeNewColor = "_ColorChangeNewCol";

        // Color Ramp
        public const string ColorRampTexture = "_ColorRampTex";
        public const string ColorRampLuminosity = "_ColorRampLuminosity";
        public const string ColorRampAffectsOutline = "_ColorRampOutline";
        public const string ColorRampBlend = "_ColorRampBlend";

        // Hit Effect
        public const string HitEffectColor = "_HitEffectColor";
        public const string HitEffectGlow = "_HitEffectGlow";
        public const string HitEffectBlend = "_HitEffectBlend";

        // Negative
        public const string NegativeAmount = "_NegativeAmount";

        // Pixelate
        public const string PixelateSize = "_PixelateSize";

        // Greyscale
        public const string GreyscaleLuminosity = "_GreyscaleLuminosity";
        public const string GreyscaleAffectsOutline = "_GreyscaleOutline";
        public const string GreyscaleTintColor = "_GreyscaleTintColor";
        public const string GreyscaleBlend = "_Greyscale Blend";

        // Posterize
        public const string PosterizeNumColors = "_PosterizeNumColors";
        public const string PosterizeGamma = "_PosterizeGamma";
        public const string PosterizeAffectsOutline = "_PosterizeOutline";

        // Blur
        public const string BlurIntensity = "_BlurIntensity";
        public const string BlurLowRes = "_BlurHD";

        // Motion Blur
        public const string MotionBlurAngle = "_MotionBlurAngle";
        public const string MotionBlurDistance = "_MotionBlurDist";

        // Ghost
        public const string GhostColorBoost = "_GhostColorBoost";
        public const string GhostTransparency = "_GhostTransparency";
        public const string GhostBlend = "_Ghost Blend";

        // Hologram
        public const string HologramStripesAmount = "_HologramStripesAmount";
        public const string HologramUnmodAmount = "_HologramUnmodAmount";
        public const string HologramStripesSpeed = "_HologramStripesSpeed";
        public const string HologramMinAlpha = "_HologramMinAlpha";
        public const string HologramMaxAlpha = "_HologramMaxAlpha";
        public const string HologramStripeColor = "_HologramStripeColor";
        public const string HologramBlend = "_Hologram Blend";

        // Chromatic Aberration
        public const string ChromaticAberrationAmount = "_ChromAberrAmount";
        public const string ChromaticAberrationAlpha = "_ChromAberrAlpha";

        // Glitch
        public const string GlitchAmount = "_GlitchAmount";
        public const string GlitchSize = "_GlitchSize";

        // Flicker
        public const string FlickerPercent = "_FlickerPercent";
        public const string FlickerFrequency = "_FlickerFreq";
        public const string FlickerAlpha = "_FlickerAlpha";

        // Shadow
        public const string ShadowOn = "SHADOW_ON";
        public const string ShadowX = "_ShadowX";
        public const string ShadowY = "_ShadowY";
        public const string ShadowAlpha = "_ShadowAlpha";
        public const string ShadowColor = "_ShadowColor";

        // Shine
        public const string ShineMask = "_ShineMask";
        public const string ShineColor = "_ShineColor";
        public const string ShineLocation = "_ShineLocation";
        public const string ShineWidth = "_ShineWidth";
        public const string ShineGlow = "_ShineGlow";

        // Contrast & Brightness
        public const string Contrast = "_Contrast";
        public const string Brightness = "_Brightness";

        // Overlay
        public const string OverlayTexture = "_OverlayTex";
        public const string OverlayColor = "_OverlayColor";
        public const string OverlayGlow = "_OverlayGlow";
        public const string OverlayBlend = "_OverlayBlend";
        public const string OverlayTextureScrollXSpeed = "_OverlayTextureScrollXSpeed";
        public const string OverlayTextureScrollYSpeed = "_OverlayTextureScrollYSpeed";

        // Alpha Cutoff
        public const string AlphaCutoffValue = "_AlphaCutoffValue";

        // Alpha Round
        public const string AlphaRoundThreshold = "_AlphaRoundThreshold";

        // Hand Drawn
        public const string HandDrawnAmount = "_HandDrawnAmount";
        public const string HandDrawnSpeed = "_HandDrawnSpeed";

        // Grass Movement / Wind
        public const string GrassSpeed = "_GrassSpeed";
        public const string BendAmount = "_GrassWind";
        public const string RadialBend = "_GrassRadialBend";
        public const string GrassIsManuallyAnimated = "_GrassManualToggle";
        public const string GrassManualAnim = "_GrassManualAnim";

        // Wave
        public const string WaveAmount = "_WaveAmount";
        public const string WaveSpeed = "_WaveSpeed";
        public const string WaveStrength = "_WaveStrength";
        public const string WaveXAxis = "_WaveX";
        public const string WaveYAxis = "_WaveY";

        // Round Wave
        public const string RoundWaveStrength = "_RoundWaveStrength";
        public const string RoundWaveSpeed = "_RoundWaveSpeed";

        // Rect Size
        public const string RectSize = "_RectSize";

        // Offset 
        public const string OffsetXAxis = "_OffsetUvX";
        public const string OffsetYAxis = "_OffsetUvY";

        // Clipping (useful for sliders)
        public const string ClippingLeft = "_ClipUvLeft";
        public const string ClippingRight = "_ClipUvRight";
        public const string ClippingUp = "_ClipUvUp";
        public const string ClippingDown = "_ClipUvDown";

        // Radial Clipping
        public const string RadialClippingOn = "RADIALCLIPPING_ON";
        public const string RadialClipAngle = "_RadialClipAngle";
        public const string RadialClip = "_RadialClip";
        public const string RadialClip2 = "_RadialClip2";

        // Texture Scroll
        public const string TextureScrollSpeedX = "_TextureScrollXSpeed";
        public const string TextureScrollSpeedY = "_TextureScrollYSpeed";

        // Zoom 
        public const string ZoomAmount = "_ZoomUvAmount";

        // Distortion
        public const string DistortionTexture = "_DistortTex";
        public const string DistortionAmount = "_DistortAmount";
        public const string DistortionXSpeed = "_DistortTexXSpeed";
        public const string DistortionYSpeed = "_DistortTexYSpeed";

        // Warp 
        public const string WarpStrength = "_WarpStrength";
        public const string WarpSpeed = "_WarpSpeed";
        public const string WarpScale = "_WarpScale";

        // Twist
        public const string TwistAmount = "_TwistUvAmount";
        public const string TwistPosX = "_TwistUvPosX";
        public const string TwistPosY = "_TwistUvPosY";
        public const string TwistRadius = "_TwistUvRadius";

        // Rotate
        public const string RotateAngle = "_RotateUvAmount";

        // Fish Eye
        public const string FishEyeAmount = "_FishEyeUvAmount";

        // Pinch
        public const string PinchAmount = "_PinchUvAmount";

        // Shake
        public const string ShakeSpeed = "_ShakeUvSpeed";
        public const string ShakeXMultiplier = "_ShakeUvX";
        public const string ShakeYMultiplier = "_ShakeUvY";
    }
}