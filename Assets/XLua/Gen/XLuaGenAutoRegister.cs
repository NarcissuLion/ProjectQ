#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using System;
using System.Collections.Generic;
using System.Reflection;


namespace XLua.CSObjectWrap
{
    public class XLua_Gen_Initer_Register__
	{
        
        
        static void wrapInit0(LuaEnv luaenv, ObjectTranslator translator)
        {
        
            translator.DelayWrapLoader(typeof(object), SystemObjectWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Object), UnityEngineObjectWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Vector2), UnityEngineVector2Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Vector3), UnityEngineVector3Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Vector4), UnityEngineVector4Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Quaternion), UnityEngineQuaternionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Color), UnityEngineColorWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Ray), UnityEngineRayWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Bounds), UnityEngineBoundsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Ray2D), UnityEngineRay2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Time), UnityEngineTimeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.GameObject), UnityEngineGameObjectWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Component), UnityEngineComponentWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Behaviour), UnityEngineBehaviourWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Transform), UnityEngineTransformWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Resources), UnityEngineResourcesWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.TextAsset), UnityEngineTextAssetWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Keyframe), UnityEngineKeyframeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AnimationCurve), UnityEngineAnimationCurveWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AnimationClip), UnityEngineAnimationClipWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.MonoBehaviour), UnityEngineMonoBehaviourWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ParticleSystem), UnityEngineParticleSystemWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.SkinnedMeshRenderer), UnityEngineSkinnedMeshRendererWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Renderer), UnityEngineRendererWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Light), UnityEngineLightWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Mathf), UnityEngineMathfWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(System.Collections.Generic.List<int>), SystemCollectionsGenericList_1_SystemInt32_Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Debug), UnityEngineDebugWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Tutorial.BaseClass), TutorialBaseClassWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Tutorial.TestEnum), TutorialTestEnumWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Tutorial.DerivedClass), TutorialDerivedClassWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Tutorial.ICalc), TutorialICalcWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Tutorial.DerivedClassExtensions), TutorialDerivedClassExtensionsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(XLuaTest.LuaBehaviour), XLuaTestLuaBehaviourWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(XLuaTest.Pedding), XLuaTestPeddingWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(XLuaTest.MyStruct), XLuaTestMyStructWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(XLuaTest.MyEnum), XLuaTestMyEnumWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(XLuaTest.NoGc), XLuaTestNoGcWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.WaitForSeconds), UnityEngineWaitForSecondsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(XLuaTest.BaseTest), XLuaTestBaseTestWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(XLuaTest.Foo1Parent), XLuaTestFoo1ParentWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(XLuaTest.Foo2Parent), XLuaTestFoo2ParentWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(XLuaTest.Foo1Child), XLuaTestFoo1ChildWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(XLuaTest.Foo2Child), XLuaTestFoo2ChildWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(XLuaTest.Foo), XLuaTestFooWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(XLuaTest.FooExtension), XLuaTestFooExtensionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Tutorial.DerivedClass.TestEnumInner), TutorialDerivedClassTestEnumInnerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Application), UnityEngineApplicationWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Screen), UnityEngineScreenWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.SystemInfo), UnityEngineSystemInfoWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.SleepTimeout), UnityEngineSleepTimeoutWrap.__Register);
        
        }
        
        static void wrapInit1(LuaEnv luaenv, ObjectTranslator translator)
        {
        
            translator.DelayWrapLoader(typeof(UnityEngine.RectTransform), UnityEngineRectTransformWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.Text), UnityEngineUITextWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.Image), UnityEngineUIImageWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.RawImage), UnityEngineUIRawImageWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.ScrollRect), UnityEngineUIScrollRectWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Sprite), UnityEngineSpriteWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Texture), UnityEngineTextureWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Material), UnityEngineMaterialWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.MeshRenderer), UnityEngineMeshRendererWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(CommonUtil), CommonUtilWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(GameUtil), GameUtilWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(ResourcesLoader), ResourcesLoaderWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(CoroutineHelper), CoroutineHelperWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DebugStopwatch), DebugStopwatchWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(HttpManager), HttpManagerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(GridView), GridViewWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(HotfixDownloader), HotfixDownloaderWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(HotfixManager), HotfixManagerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(HotfixUtil), HotfixUtilWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(SceneHandler), SceneHandlerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(LuaDebugger), LuaDebuggerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(ConfigManager), ConfigManagerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(TextConfig), TextConfigWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(SDKInterface), SDKInterfaceWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(SDKDefault), SDKDefaultWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(SDKAndroid), SDKAndroidWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(SDKIOS), SDKIOSWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DG.Tweening.ShortcutExtensions), DGTweeningShortcutExtensionsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DG.Tweening.ShortcutExtensions46), DGTweeningShortcutExtensions46Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DG.Tweening.Tweener), DGTweeningTweenerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DG.Tweening.Ease), DGTweeningEaseWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DG.Tweening.AutoPlay), DGTweeningAutoPlayWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DG.Tweening.AxisConstraint), DGTweeningAxisConstraintWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DG.Tweening.LogBehaviour), DGTweeningLogBehaviourWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DG.Tweening.LoopType), DGTweeningLoopTypeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DG.Tweening.PathMode), DGTweeningPathModeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DG.Tweening.PathType), DGTweeningPathTypeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DG.Tweening.RotateMode), DGTweeningRotateModeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DG.Tweening.ScrambleMode), DGTweeningScrambleModeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DG.Tweening.TweenType), DGTweeningTweenTypeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DG.Tweening.UpdateType), DGTweeningUpdateTypeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DG.Tweening.DOTween), DGTweeningDOTweenWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DG.Tweening.DOVirtual), DGTweeningDOVirtualWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DG.Tweening.EaseFactory), DGTweeningEaseFactoryWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DG.Tweening.Tween), DGTweeningTweenWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DG.Tweening.Sequence), DGTweeningSequenceWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DG.Tweening.TweenParams), DGTweeningTweenParamsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DG.Tweening.Core.ABSSequentiable), DGTweeningCoreABSSequentiableWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>), DGTweeningCoreTweenerCore_3_UnityEngineVector3UnityEngineVector3DGTweeningPluginsOptionsVectorOptions_Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DG.Tweening.TweenExtensions), DGTweeningTweenExtensionsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DG.Tweening.TweenSettingsExtensions), DGTweeningTweenSettingsExtensionsWrap.__Register);
        
        }
        
        static void wrapInit2(LuaEnv luaenv, ObjectTranslator translator)
        {
        
            translator.DelayWrapLoader(typeof(DG.Tweening.ShortcutExtensions43), DGTweeningShortcutExtensions43Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DG.Tweening.ShortcutExtensions50), DGTweeningShortcutExtensions50Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Animator), UnityEngineAnimatorWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.StateMachineBehaviour), UnityEngineStateMachineBehaviourWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Animation), UnityEngineAnimationWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AnimationState), UnityEngineAnimationStateWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AnimationEvent), UnityEngineAnimationEventWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AnimatorClipInfo), UnityEngineAnimatorClipInfoWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AnimatorStateInfo), UnityEngineAnimatorStateInfoWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AnimatorTransitionInfo), UnityEngineAnimatorTransitionInfoWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.MatchTargetWeightMask), UnityEngineMatchTargetWeightMaskWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AnimatorControllerParameter), UnityEngineAnimatorControllerParameterWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AnimatorOverrideController), UnityEngineAnimatorOverrideControllerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AnimatorUtility), UnityEngineAnimatorUtilityWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Avatar), UnityEngineAvatarWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.SkeletonBone), UnityEngineSkeletonBoneWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.HumanLimit), UnityEngineHumanLimitWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.HumanBone), UnityEngineHumanBoneWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.HumanDescription), UnityEngineHumanDescriptionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AvatarBuilder), UnityEngineAvatarBuilderWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AvatarMask), UnityEngineAvatarMaskWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.HumanPose), UnityEngineHumanPoseWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.HumanPoseHandler), UnityEngineHumanPoseHandlerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.HumanTrait), UnityEngineHumanTraitWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.RuntimeAnimatorController), UnityEngineRuntimeAnimatorControllerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AssetBundle), UnityEngineAssetBundleWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AssetBundleCreateRequest), UnityEngineAssetBundleCreateRequestWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AssetBundleManifest), UnityEngineAssetBundleManifestWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AssetBundleRecompressOperation), UnityEngineAssetBundleRecompressOperationWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AssetBundleRequest), UnityEngineAssetBundleRequestWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.BuildCompression), UnityEngineBuildCompressionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AudioSettings), UnityEngineAudioSettingsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AudioSettings.Mobile), UnityEngineAudioSettingsMobileWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AudioSource), UnityEngineAudioSourceWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AudioLowPassFilter), UnityEngineAudioLowPassFilterWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AudioHighPassFilter), UnityEngineAudioHighPassFilterWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AudioReverbFilter), UnityEngineAudioReverbFilterWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AudioConfiguration), UnityEngineAudioConfigurationWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AudioClip), UnityEngineAudioClipWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AudioBehaviour), UnityEngineAudioBehaviourWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AudioListener), UnityEngineAudioListenerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AudioReverbZone), UnityEngineAudioReverbZoneWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AudioDistortionFilter), UnityEngineAudioDistortionFilterWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AudioEchoFilter), UnityEngineAudioEchoFilterWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AudioChorusFilter), UnityEngineAudioChorusFilterWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Microphone), UnityEngineMicrophoneWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AudioRenderer), UnityEngineAudioRendererWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.WebCamDevice), UnityEngineWebCamDeviceWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.WebCamTexture), UnityEngineWebCamTextureWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ClothSphereColliderPair), UnityEngineClothSphereColliderPairWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ClothSkinningCoefficient), UnityEngineClothSkinningCoefficientWrap.__Register);
        
        }
        
        static void wrapInit3(LuaEnv luaenv, ObjectTranslator translator)
        {
        
            translator.DelayWrapLoader(typeof(UnityEngine.Cloth), UnityEngineClothWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ClusterSerialization), UnityEngineClusterSerializationWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.SortingLayer), UnityEngineSortingLayerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.CachedAssetBundle), UnityEngineCachedAssetBundleWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Cache), UnityEngineCacheWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Caching), UnityEngineCachingWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Camera), UnityEngineCameraWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Camera.GateFitParameters), UnityEngineCameraGateFitParametersWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Camera.RenderRequest), UnityEngineCameraRenderRequestWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.BoundingSphere), UnityEngineBoundingSphereWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.CullingGroupEvent), UnityEngineCullingGroupEventWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.CullingGroup), UnityEngineCullingGroupWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.FlareLayer), UnityEngineFlareLayerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ReflectionProbe), UnityEngineReflectionProbeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.CrashReport), UnityEngineCrashReportWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ExposedPropertyResolver), UnityEngineExposedPropertyResolverWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.BoundsInt), UnityEngineBoundsIntWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.GeometryUtility), UnityEngineGeometryUtilityWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Plane), UnityEnginePlaneWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Rect), UnityEngineRectWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.RectInt), UnityEngineRectIntWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.RectOffset), UnityEngineRectOffsetWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.DynamicGI), UnityEngineDynamicGIWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.LightingSettings), UnityEngineLightingSettingsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.BillboardAsset), UnityEngineBillboardAssetWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.BillboardRenderer), UnityEngineBillboardRendererWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.CustomRenderTextureManager), UnityEngineCustomRenderTextureManagerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Display), UnityEngineDisplayWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.RefreshRate), UnityEngineRefreshRateWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.DisplayInfo), UnityEngineDisplayInfoWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.RenderBuffer), UnityEngineRenderBufferWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Graphics), UnityEngineGraphicsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.GL), UnityEngineGLWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ScalableBufferManager), UnityEngineScalableBufferManagerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.FrameTiming), UnityEngineFrameTimingWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.FrameTimingManager), UnityEngineFrameTimingManagerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.LightmapData), UnityEngineLightmapDataWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.LightmapSettings), UnityEngineLightmapSettingsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.LightProbes), UnityEngineLightProbesWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.HDROutputSettings), UnityEngineHDROutputSettingsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Resolution), UnityEngineResolutionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.RenderTargetSetup), UnityEngineRenderTargetSetupWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.RenderParams), UnityEngineRenderParamsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.QualitySettings), UnityEngineQualitySettingsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.RendererExtensions), UnityEngineRendererExtensionsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ImageEffectTransformsToLDR), UnityEngineImageEffectTransformsToLDRWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ImageEffectAllowedInSceneView), UnityEngineImageEffectAllowedInSceneViewWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ImageEffectOpaque), UnityEngineImageEffectOpaqueWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ImageEffectAfterScale), UnityEngineImageEffectAfterScaleWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ImageEffectUsesCommandBuffer), UnityEngineImageEffectUsesCommandBufferWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Mesh), UnityEngineMeshWrap.__Register);
        
        }
        
        static void wrapInit4(LuaEnv luaenv, ObjectTranslator translator)
        {
        
            translator.DelayWrapLoader(typeof(UnityEngine.Mesh.MeshData), UnityEngineMeshMeshDataWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Mesh.MeshDataArray), UnityEngineMeshMeshDataArrayWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Projector), UnityEngineProjectorWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Shader), UnityEngineShaderWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.TrailRenderer), UnityEngineTrailRendererWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.LineRenderer), UnityEngineLineRendererWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.MaterialPropertyBlock), UnityEngineMaterialPropertyBlockWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.RenderSettings), UnityEngineRenderSettingsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.GraphicsBuffer), UnityEngineGraphicsBufferWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.GraphicsBuffer.IndirectDrawArgs), UnityEngineGraphicsBufferIndirectDrawArgsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.GraphicsBuffer.IndirectDrawIndexedArgs), UnityEngineGraphicsBufferIndirectDrawIndexedArgsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.OcclusionPortal), UnityEngineOcclusionPortalWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.OcclusionArea), UnityEngineOcclusionAreaWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Flare), UnityEngineFlareWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.LensFlare), UnityEngineLensFlareWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.LightBakingOutput), UnityEngineLightBakingOutputWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Skybox), UnityEngineSkyboxWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.MeshFilter), UnityEngineMeshFilterWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.LightProbeProxyVolume), UnityEngineLightProbeProxyVolumeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.LightProbeGroup), UnityEngineLightProbeGroupWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.LineUtility), UnityEngineLineUtilityWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.LOD), UnityEngineLODWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.LODGroup), UnityEngineLODGroupWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.BoneWeight), UnityEngineBoneWeightWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.BoneWeight1), UnityEngineBoneWeight1Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.CombineInstance), UnityEngineCombineInstanceWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Texture2D), UnityEngineTexture2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Cubemap), UnityEngineCubemapWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Texture3D), UnityEngineTexture3DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Texture2DArray), UnityEngineTexture2DArrayWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.CubemapArray), UnityEngineCubemapArrayWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.SparseTexture), UnityEngineSparseTextureWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.RenderTexture), UnityEngineRenderTextureWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.CustomRenderTextureUpdateZone), UnityEngineCustomRenderTextureUpdateZoneWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.CustomRenderTexture), UnityEngineCustomRenderTextureWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.RenderTextureDescriptor), UnityEngineRenderTextureDescriptorWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Hash128), UnityEngineHash128Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.HashUtilities), UnityEngineHashUtilitiesWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.HashUnsafeUtilities), UnityEngineHashUnsafeUtilitiesWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Logger), UnityEngineLoggerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Color32), UnityEngineColor32Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ColorUtility), UnityEngineColorUtilityWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.GradientColorKey), UnityEngineGradientColorKeyWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.GradientAlphaKey), UnityEngineGradientAlphaKeyWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Gradient), UnityEngineGradientWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.FrustumPlanes), UnityEngineFrustumPlanesWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Matrix4x4), UnityEngineMatrix4x4Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Vector2Int), UnityEngineVector2IntWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Vector3Int), UnityEngineVector3IntWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.PlayerPrefsException), UnityEnginePlayerPrefsExceptionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.PlayerPrefs), UnityEnginePlayerPrefsWrap.__Register);
        
        }
        
        static void wrapInit5(LuaEnv luaenv, ObjectTranslator translator)
        {
        
            translator.DelayWrapLoader(typeof(UnityEngine.PropertyName), UnityEnginePropertyNameWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Random), UnityEngineRandomWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Random.State), UnityEngineRandomStateWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ResourceRequest), UnityEngineResourceRequestWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ResourcesAPI), UnityEngineResourcesAPIWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AsyncOperation), UnityEngineAsyncOperationWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ExecuteAlways), UnityEngineExecuteAlwaysWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.DefaultExecutionOrder), UnityEngineDefaultExecutionOrderWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Coroutine), UnityEngineCoroutineWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.CustomYieldInstruction), UnityEngineCustomYieldInstructionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.LayerMask), UnityEngineLayerMaskWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.RangeInt), UnityEngineRangeIntWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ScriptableObject), UnityEngineScriptableObjectWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.StackTraceUtility), UnityEngineStackTraceUtilityWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UnityException), UnityEngineUnityExceptionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.MissingComponentException), UnityEngineMissingComponentExceptionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UnassignedReferenceException), UnityEngineUnassignedReferenceExceptionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.MissingReferenceException), UnityEngineMissingReferenceExceptionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.WaitForEndOfFrame), UnityEngineWaitForEndOfFrameWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.WaitForFixedUpdate), UnityEngineWaitForFixedUpdateWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.WaitForSecondsRealtime), UnityEngineWaitForSecondsRealtimeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.WaitUntil), UnityEngineWaitUntilWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.WaitWhile), UnityEngineWaitWhileWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.YieldInstruction), UnityEngineYieldInstructionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Security), UnityEngineSecurityWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.SerializeReference), UnityEngineSerializeReferenceWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.PreferBinarySerialization), UnityEnginePreferBinarySerializationWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ComputeBuffer), UnityEngineComputeBufferWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ComputeShader), UnityEngineComputeShaderWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Snapping), UnityEngineSnappingWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.StaticBatchingUtility), UnityEngineStaticBatchingUtilityWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UnityEventQueueSystem), UnityEngineUnityEventQueueSystemWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Pose), UnityEnginePoseWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.FrameDebugger), UnityEngineFrameDebuggerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.DrivenRectTransformTracker), UnityEngineDrivenRectTransformTrackerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.SpriteRenderer), UnityEngineSpriteRendererWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.SecondarySpriteTexture), UnityEngineSecondarySpriteTextureWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Grid), UnityEngineGridWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.GridLayout), UnityEngineGridLayoutWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Event), UnityEngineEventWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ImageConversion), UnityEngineImageConversionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Touch), UnityEngineTouchWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AccelerationEvent), UnityEngineAccelerationEventWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Gyroscope), UnityEngineGyroscopeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.LocationInfo), UnityEngineLocationInfoWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.LocationService), UnityEngineLocationServiceWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Compass), UnityEngineCompassWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Input), UnityEngineInputWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.JsonUtility), UnityEngineJsonUtilityWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.LocalizationAsset), UnityEngineLocalizationAssetWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ParticleSystem.MinMaxCurve), UnityEngineParticleSystemMinMaxCurveWrap.__Register);
        
        }
        
        static void wrapInit6(LuaEnv luaenv, ObjectTranslator translator)
        {
        
            translator.DelayWrapLoader(typeof(UnityEngine.ParticleSystem.MainModule), UnityEngineParticleSystemMainModuleWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ParticleSystem.EmissionModule), UnityEngineParticleSystemEmissionModuleWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ParticleSystem.ShapeModule), UnityEngineParticleSystemShapeModuleWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ParticleSystem.CollisionModule), UnityEngineParticleSystemCollisionModuleWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ParticleSystem.TriggerModule), UnityEngineParticleSystemTriggerModuleWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ParticleSystem.SubEmittersModule), UnityEngineParticleSystemSubEmittersModuleWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ParticleSystem.TextureSheetAnimationModule), UnityEngineParticleSystemTextureSheetAnimationModuleWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ParticleSystem.Particle), UnityEngineParticleSystemParticleWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ParticleSystem.Burst), UnityEngineParticleSystemBurstWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ParticleSystem.MinMaxGradient), UnityEngineParticleSystemMinMaxGradientWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ParticleSystem.EmitParams), UnityEngineParticleSystemEmitParamsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ParticleSystem.PlaybackState), UnityEngineParticleSystemPlaybackStateWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ParticleSystem.Trails), UnityEngineParticleSystemTrailsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ParticleSystem.ColliderData), UnityEngineParticleSystemColliderDataWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ParticleSystem.VelocityOverLifetimeModule), UnityEngineParticleSystemVelocityOverLifetimeModuleWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule), UnityEngineParticleSystemLimitVelocityOverLifetimeModuleWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ParticleSystem.InheritVelocityModule), UnityEngineParticleSystemInheritVelocityModuleWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ParticleSystem.LifetimeByEmitterSpeedModule), UnityEngineParticleSystemLifetimeByEmitterSpeedModuleWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ParticleSystem.ForceOverLifetimeModule), UnityEngineParticleSystemForceOverLifetimeModuleWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ParticleSystem.ColorOverLifetimeModule), UnityEngineParticleSystemColorOverLifetimeModuleWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ParticleSystem.ColorBySpeedModule), UnityEngineParticleSystemColorBySpeedModuleWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ParticleSystem.SizeOverLifetimeModule), UnityEngineParticleSystemSizeOverLifetimeModuleWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ParticleSystem.SizeBySpeedModule), UnityEngineParticleSystemSizeBySpeedModuleWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ParticleSystem.RotationOverLifetimeModule), UnityEngineParticleSystemRotationOverLifetimeModuleWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ParticleSystem.RotationBySpeedModule), UnityEngineParticleSystemRotationBySpeedModuleWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ParticleSystem.ExternalForcesModule), UnityEngineParticleSystemExternalForcesModuleWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ParticleSystem.NoiseModule), UnityEngineParticleSystemNoiseModuleWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ParticleSystem.LightsModule), UnityEngineParticleSystemLightsModuleWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ParticleSystem.TrailModule), UnityEngineParticleSystemTrailModuleWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ParticleSystem.CustomDataModule), UnityEngineParticleSystemCustomDataModuleWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ParticlePhysicsExtensions), UnityEngineParticlePhysicsExtensionsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ParticleCollisionEvent), UnityEngineParticleCollisionEventWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ParticleSystemRenderer), UnityEngineParticleSystemRendererWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ParticleSystemForceField), UnityEngineParticleSystemForceFieldWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.WheelFrictionCurve), UnityEngineWheelFrictionCurveWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.SoftJointLimit), UnityEngineSoftJointLimitWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.SoftJointLimitSpring), UnityEngineSoftJointLimitSpringWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.JointDrive), UnityEngineJointDriveWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.JointMotor), UnityEngineJointMotorWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.JointSpring), UnityEngineJointSpringWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.JointLimits), UnityEngineJointLimitsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ControllerColliderHit), UnityEngineControllerColliderHitWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Collision), UnityEngineCollisionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ArticulationDrive), UnityEngineArticulationDriveWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ArticulationReducedSpace), UnityEngineArticulationReducedSpaceWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ArticulationJacobian), UnityEngineArticulationJacobianWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ArticulationBody), UnityEngineArticulationBodyWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Physics), UnityEnginePhysicsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ModifiableContactPair), UnityEngineModifiableContactPairWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ModifiableMassProperties), UnityEngineModifiableMassPropertiesWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.PhysicMaterial), UnityEnginePhysicMaterialWrap.__Register);
        
        }
        
        static void wrapInit7(LuaEnv luaenv, ObjectTranslator translator)
        {
        
            translator.DelayWrapLoader(typeof(UnityEngine.RaycastHit), UnityEngineRaycastHitWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Rigidbody), UnityEngineRigidbodyWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Collider), UnityEngineColliderWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.CharacterController), UnityEngineCharacterControllerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.MeshCollider), UnityEngineMeshColliderWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.CapsuleCollider), UnityEngineCapsuleColliderWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.BoxCollider), UnityEngineBoxColliderWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.SphereCollider), UnityEngineSphereColliderWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ConstantForce), UnityEngineConstantForceWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Joint), UnityEngineJointWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.HingeJoint), UnityEngineHingeJointWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.SpringJoint), UnityEngineSpringJointWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.FixedJoint), UnityEngineFixedJointWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.CharacterJoint), UnityEngineCharacterJointWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ConfigurableJoint), UnityEngineConfigurableJointWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ContactPoint), UnityEngineContactPointWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.PhysicsScene), UnityEnginePhysicsSceneWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.PhysicsSceneExtensions), UnityEnginePhysicsSceneExtensionsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.RaycastCommand), UnityEngineRaycastCommandWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.SpherecastCommand), UnityEngineSpherecastCommandWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.CapsulecastCommand), UnityEngineCapsulecastCommandWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.BoxcastCommand), UnityEngineBoxcastCommandWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.PhysicsScene2D), UnityEnginePhysicsScene2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.PhysicsSceneExtensions2D), UnityEnginePhysicsSceneExtensions2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Physics2D), UnityEnginePhysics2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.PhysicsShape2D), UnityEnginePhysicsShape2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.PhysicsShapeGroup2D), UnityEnginePhysicsShapeGroup2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ColliderDistance2D), UnityEngineColliderDistance2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ContactFilter2D), UnityEngineContactFilter2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Collision2D), UnityEngineCollision2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ContactPoint2D), UnityEngineContactPoint2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.JointAngleLimits2D), UnityEngineJointAngleLimits2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.JointTranslationLimits2D), UnityEngineJointTranslationLimits2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.JointMotor2D), UnityEngineJointMotor2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.JointSuspension2D), UnityEngineJointSuspension2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.RaycastHit2D), UnityEngineRaycastHit2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.PhysicsJobOptions2D), UnityEnginePhysicsJobOptions2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Rigidbody2D), UnityEngineRigidbody2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Collider2D), UnityEngineCollider2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.CustomCollider2D), UnityEngineCustomCollider2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.CircleCollider2D), UnityEngineCircleCollider2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.CapsuleCollider2D), UnityEngineCapsuleCollider2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.EdgeCollider2D), UnityEngineEdgeCollider2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.BoxCollider2D), UnityEngineBoxCollider2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.PolygonCollider2D), UnityEnginePolygonCollider2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.CompositeCollider2D), UnityEngineCompositeCollider2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Joint2D), UnityEngineJoint2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AnchoredJoint2D), UnityEngineAnchoredJoint2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.SpringJoint2D), UnityEngineSpringJoint2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.DistanceJoint2D), UnityEngineDistanceJoint2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.FrictionJoint2D), UnityEngineFrictionJoint2DWrap.__Register);
        
        }
        
        static void wrapInit8(LuaEnv luaenv, ObjectTranslator translator)
        {
        
            translator.DelayWrapLoader(typeof(UnityEngine.HingeJoint2D), UnityEngineHingeJoint2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.RelativeJoint2D), UnityEngineRelativeJoint2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.SliderJoint2D), UnityEngineSliderJoint2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.TargetJoint2D), UnityEngineTargetJoint2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.FixedJoint2D), UnityEngineFixedJoint2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.WheelJoint2D), UnityEngineWheelJoint2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Effector2D), UnityEngineEffector2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AreaEffector2D), UnityEngineAreaEffector2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.BuoyancyEffector2D), UnityEngineBuoyancyEffector2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.PointEffector2D), UnityEnginePointEffector2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.PlatformEffector2D), UnityEnginePlatformEffector2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.SurfaceEffector2D), UnityEngineSurfaceEffector2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.PhysicsUpdateBehaviour2D), UnityEnginePhysicsUpdateBehaviour2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ConstantForce2D), UnityEngineConstantForce2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.PhysicsMaterial2D), UnityEnginePhysicsMaterial2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ScreenCapture), UnityEngineScreenCaptureWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.SpriteMask), UnityEngineSpriteMaskWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.StreamingController), UnityEngineStreamingControllerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.IntegratedSubsystem), UnityEngineIntegratedSubsystemWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.IntegratedSubsystemDescriptor), UnityEngineIntegratedSubsystemDescriptorWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Subsystem), UnityEngineSubsystemWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.SubsystemDescriptor), UnityEngineSubsystemDescriptorWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.SubsystemManager), UnityEngineSubsystemManagerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.PatchExtents), UnityEnginePatchExtentsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.DetailInstanceTransform), UnityEngineDetailInstanceTransformWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.TextGenerationSettings), UnityEngineTextGenerationSettingsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.TextMesh), UnityEngineTextMeshWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.CharacterInfo), UnityEngineCharacterInfoWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UICharInfo), UnityEngineUICharInfoWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UILineInfo), UnityEngineUILineInfoWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UIVertex), UnityEngineUIVertexWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Font), UnityEngineFontWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.GridBrushBase), UnityEngineGridBrushBaseWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.CanvasGroup), UnityEngineCanvasGroupWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.CanvasRenderer), UnityEngineCanvasRendererWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.RectTransformUtility), UnityEngineRectTransformUtilityWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Canvas), UnityEngineCanvasWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UISystemProfilerApi), UnityEngineUISystemProfilerApiWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UIWidgetsInternal), UnityEngineUIWidgetsInternalWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.RemoteSettings), UnityEngineRemoteSettingsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.RemoteConfigSettings), UnityEngineRemoteConfigSettingsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.WWWForm), UnityEngineWWWFormWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.WheelHit), UnityEngineWheelHitWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.WheelCollider), UnityEngineWheelColliderWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.WindZone), UnityEngineWindZoneWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.AnimationTriggers), UnityEngineUIAnimationTriggersWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.Button), UnityEngineUIButtonWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.CanvasUpdateRegistry), UnityEngineUICanvasUpdateRegistryWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.ColorBlock), UnityEngineUIColorBlockWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.ClipperRegistry), UnityEngineUIClipperRegistryWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.Clipping), UnityEngineUIClippingWrap.__Register);
        
        }
        
        static void wrapInit9(LuaEnv luaenv, ObjectTranslator translator)
        {
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.DefaultControls), UnityEngineUIDefaultControlsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.Dropdown), UnityEngineUIDropdownWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.FontData), UnityEngineUIFontDataWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.FontUpdateTracker), UnityEngineUIFontUpdateTrackerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.Graphic), UnityEngineUIGraphicWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.GraphicRaycaster), UnityEngineUIGraphicRaycasterWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.GraphicRegistry), UnityEngineUIGraphicRegistryWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.InputField), UnityEngineUIInputFieldWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.AspectRatioFitter), UnityEngineUIAspectRatioFitterWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.CanvasScaler), UnityEngineUICanvasScalerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.ContentSizeFitter), UnityEngineUIContentSizeFitterWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.GridLayoutGroup), UnityEngineUIGridLayoutGroupWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.HorizontalLayoutGroup), UnityEngineUIHorizontalLayoutGroupWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.HorizontalOrVerticalLayoutGroup), UnityEngineUIHorizontalOrVerticalLayoutGroupWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.LayoutElement), UnityEngineUILayoutElementWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.LayoutGroup), UnityEngineUILayoutGroupWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.LayoutRebuilder), UnityEngineUILayoutRebuilderWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.LayoutUtility), UnityEngineUILayoutUtilityWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.VerticalLayoutGroup), UnityEngineUIVerticalLayoutGroupWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.Mask), UnityEngineUIMaskWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.MaskableGraphic), UnityEngineUIMaskableGraphicWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.MaskUtilities), UnityEngineUIMaskUtilitiesWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.Navigation), UnityEngineUINavigationWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.RectMask2D), UnityEngineUIRectMask2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.Scrollbar), UnityEngineUIScrollbarWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.Selectable), UnityEngineUISelectableWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.Slider), UnityEngineUISliderWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.SpriteState), UnityEngineUISpriteStateWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.StencilMaterial), UnityEngineUIStencilMaterialWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.Toggle), UnityEngineUIToggleWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.ToggleGroup), UnityEngineUIToggleGroupWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.VertexHelper), UnityEngineUIVertexHelperWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.BaseMeshEffect), UnityEngineUIBaseMeshEffectWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.Outline), UnityEngineUIOutlineWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.PositionAsUV1), UnityEngineUIPositionAsUV1Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.Shadow), UnityEngineUIShadowWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.Button.ButtonClickedEvent), UnityEngineUIButtonButtonClickedEventWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.DefaultControls.Resources), UnityEngineUIDefaultControlsResourcesWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.Dropdown.OptionData), UnityEngineUIDropdownOptionDataWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.Dropdown.OptionDataList), UnityEngineUIDropdownOptionDataListWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.Dropdown.DropdownEvent), UnityEngineUIDropdownDropdownEventWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.InputField.SubmitEvent), UnityEngineUIInputFieldSubmitEventWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.InputField.EndEditEvent), UnityEngineUIInputFieldEndEditEventWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.InputField.OnChangeEvent), UnityEngineUIInputFieldOnChangeEventWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.MaskableGraphic.CullStateChangedEvent), UnityEngineUIMaskableGraphicCullStateChangedEventWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.Scrollbar.ScrollEvent), UnityEngineUIScrollbarScrollEventWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.ScrollRect.ScrollRectEvent), UnityEngineUIScrollRectScrollRectEventWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.Slider.SliderEvent), UnityEngineUISliderSliderEventWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.UI.Toggle.ToggleEvent), UnityEngineUIToggleToggleEventWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Demo), DemoWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(EditorConst), EditorConstWrap.__Register);
        
        }
        
        static void wrapInit10(LuaEnv luaenv, ObjectTranslator translator)
        {
        
            translator.DelayWrapLoader(typeof(ResPathes), ResPathesWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(AssetBundleHelper), AssetBundleHelperWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(AssetCounter), AssetCounterWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(CoroutineQueue), CoroutineQueueWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(HotfixDownloadList), HotfixDownloadListWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(HotfixHashList), HotfixHashListWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(HotfixList), HotfixListWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(ResourceConfig), ResourceConfigWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(ResourceCachePool), ResourceCachePoolWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(LuaClient), LuaClientWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(BestHttpHandler), BestHttpHandlerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(IHttpHandler), IHttpHandlerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityHttpHandler), UnityHttpHandlerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Gradient), GradientWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(SafeAreaView), SafeAreaViewWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(AESHelper), AESHelperWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DebugUIRaycast), DebugUIRaycastWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(GZipHelper), GZipHelperWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(ImageAspectRatioFitter), ImageAspectRatioFitterWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(JsonUtil), JsonUtilWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PrefabYaml), PrefabYamlWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(RealtimeTextTimer), RealtimeTextTimerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(RealtimeTimer), RealtimeTimerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(ShowFPS), ShowFPSWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(TEAHelper), TEAHelperWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(ExampleGenConfig), ExampleGenConfigWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(LuaCallCs), LuaCallCsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Tutorial.CSCallLua), TutorialCSCallLuaWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Tutorial.ByFile), TutorialByFileWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Tutorial.ByString), TutorialByStringWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Tutorial.CustomLoader), TutorialCustomLoaderWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Tutorial.Param1), TutorialParam1Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(AssetCounter.ChangeListener), AssetCounterChangeListenerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(HotfixUtil.DecompressOption), HotfixUtilDecompressOptionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(HotfixDownloadList.File), HotfixDownloadListFileWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(HotfixList.File), HotfixListFileWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(ResourceCachePool.Cache), ResourceCachePoolCacheWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(ImageAspectRatioFitter.AspectMode), ImageAspectRatioFitterAspectModeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PrefabYaml.Node), PrefabYamlNodeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Tutorial.CSCallLua.DClass), TutorialCSCallLuaDClassWrap.__Register);
        
        
        
        }
        
        static void Init(LuaEnv luaenv, ObjectTranslator translator)
        {
            
            wrapInit0(luaenv, translator);
            
            wrapInit1(luaenv, translator);
            
            wrapInit2(luaenv, translator);
            
            wrapInit3(luaenv, translator);
            
            wrapInit4(luaenv, translator);
            
            wrapInit5(luaenv, translator);
            
            wrapInit6(luaenv, translator);
            
            wrapInit7(luaenv, translator);
            
            wrapInit8(luaenv, translator);
            
            wrapInit9(luaenv, translator);
            
            wrapInit10(luaenv, translator);
            
            
            translator.AddInterfaceBridgeCreator(typeof(System.Collections.IEnumerator), SystemCollectionsIEnumeratorBridge.__Create);
            
            translator.AddInterfaceBridgeCreator(typeof(XLuaTest.IExchanger), XLuaTestIExchangerBridge.__Create);
            
            translator.AddInterfaceBridgeCreator(typeof(Tutorial.CSCallLua.ItfD), TutorialCSCallLuaItfDBridge.__Create);
            
            translator.AddInterfaceBridgeCreator(typeof(XLuaTest.InvokeLua.ICalc), XLuaTestInvokeLuaICalcBridge.__Create);
            
        }
        
	    static XLua_Gen_Initer_Register__()
        {
		    XLua.LuaEnv.AddIniter(Init);
		}
		
		
	}
	
}
namespace XLua
{
	public partial class ObjectTranslator
	{
		static XLua.CSObjectWrap.XLua_Gen_Initer_Register__ s_gen_reg_dumb_obj = new XLua.CSObjectWrap.XLua_Gen_Initer_Register__();
		static XLua.CSObjectWrap.XLua_Gen_Initer_Register__ gen_reg_dumb_obj {get{return s_gen_reg_dumb_obj;}}
	}
	
	internal partial class InternalGlobals
    {
	    
		delegate void __GEN_DELEGATE0( DG.Tweening.Tween t);
		
		delegate void __GEN_DELEGATE1( DG.Tweening.Tween t,  bool withCallbacks);
		
		delegate void __GEN_DELEGATE2( DG.Tweening.Tween t);
		
		delegate void __GEN_DELEGATE3( DG.Tweening.Tween t);
		
		delegate void __GEN_DELEGATE4( DG.Tweening.Tween t,  float to,  bool andPlay);
		
		delegate void __GEN_DELEGATE5( DG.Tweening.Tween t,  bool complete);
		
		delegate DG.Tweening.Tween __GEN_DELEGATE6( DG.Tweening.Tween t);
		
		delegate DG.Tweening.Tween __GEN_DELEGATE7( DG.Tweening.Tween t);
		
		delegate void __GEN_DELEGATE8( DG.Tweening.Tween t);
		
		delegate void __GEN_DELEGATE9( DG.Tweening.Tween t);
		
		delegate void __GEN_DELEGATE10( DG.Tweening.Tween t,  bool includeDelay,  float changeDelayTo);
		
		delegate void __GEN_DELEGATE11( DG.Tweening.Tween t,  bool includeDelay);
		
		delegate void __GEN_DELEGATE12( DG.Tweening.Tween t);
		
		delegate void __GEN_DELEGATE13( DG.Tweening.Tween t);
		
		delegate void __GEN_DELEGATE14( DG.Tweening.Tween t,  int waypointIndex,  bool andPlay);
		
		delegate UnityEngine.YieldInstruction __GEN_DELEGATE15( DG.Tweening.Tween t);
		
		delegate UnityEngine.YieldInstruction __GEN_DELEGATE16( DG.Tweening.Tween t);
		
		delegate UnityEngine.YieldInstruction __GEN_DELEGATE17( DG.Tweening.Tween t);
		
		delegate UnityEngine.YieldInstruction __GEN_DELEGATE18( DG.Tweening.Tween t,  int elapsedLoops);
		
		delegate UnityEngine.YieldInstruction __GEN_DELEGATE19( DG.Tweening.Tween t,  float position);
		
		delegate UnityEngine.Coroutine __GEN_DELEGATE20( DG.Tweening.Tween t);
		
		delegate int __GEN_DELEGATE21( DG.Tweening.Tween t);
		
		delegate float __GEN_DELEGATE22( DG.Tweening.Tween t);
		
		delegate float __GEN_DELEGATE23( DG.Tweening.Tween t,  bool includeLoops);
		
		delegate float __GEN_DELEGATE24( DG.Tweening.Tween t,  bool includeLoops);
		
		delegate float __GEN_DELEGATE25( DG.Tweening.Tween t,  bool includeLoops);
		
		delegate float __GEN_DELEGATE26( DG.Tweening.Tween t);
		
		delegate bool __GEN_DELEGATE27( DG.Tweening.Tween t);
		
		delegate bool __GEN_DELEGATE28( DG.Tweening.Tween t);
		
		delegate bool __GEN_DELEGATE29( DG.Tweening.Tween t);
		
		delegate bool __GEN_DELEGATE30( DG.Tweening.Tween t);
		
		delegate bool __GEN_DELEGATE31( DG.Tweening.Tween t);
		
		delegate int __GEN_DELEGATE32( DG.Tweening.Tween t);
		
		delegate UnityEngine.Vector3 __GEN_DELEGATE33( DG.Tweening.Tween t,  float pathPercentage);
		
		delegate UnityEngine.Vector3[] __GEN_DELEGATE34( DG.Tweening.Tween t,  int subdivisionsXSegment);
		
		delegate float __GEN_DELEGATE35( DG.Tweening.Tween t);
		
		delegate DG.Tweening.Tween __GEN_DELEGATE36( DG.Tweening.Tween t);
		
		delegate DG.Tweening.Tween __GEN_DELEGATE37( DG.Tweening.Tween t,  bool autoKillOnCompletion);
		
		delegate DG.Tweening.Tween __GEN_DELEGATE38( DG.Tweening.Tween t,  object id);
		
		delegate DG.Tweening.Tween __GEN_DELEGATE39( DG.Tweening.Tween t,  object target);
		
		delegate DG.Tweening.Tween __GEN_DELEGATE40( DG.Tweening.Tween t,  int loops);
		
		delegate DG.Tweening.Tween __GEN_DELEGATE41( DG.Tweening.Tween t,  int loops,  DG.Tweening.LoopType loopType);
		
		delegate DG.Tweening.Tween __GEN_DELEGATE42( DG.Tweening.Tween t,  DG.Tweening.Ease ease);
		
		delegate DG.Tweening.Tween __GEN_DELEGATE43( DG.Tweening.Tween t,  DG.Tweening.Ease ease,  float overshoot);
		
		delegate DG.Tweening.Tween __GEN_DELEGATE44( DG.Tweening.Tween t,  DG.Tweening.Ease ease,  float amplitude,  float period);
		
		delegate DG.Tweening.Tween __GEN_DELEGATE45( DG.Tweening.Tween t,  UnityEngine.AnimationCurve animCurve);
		
		delegate DG.Tweening.Tween __GEN_DELEGATE46( DG.Tweening.Tween t,  DG.Tweening.EaseFunction customEase);
		
		delegate DG.Tweening.Tween __GEN_DELEGATE47( DG.Tweening.Tween t);
		
		delegate DG.Tweening.Tween __GEN_DELEGATE48( DG.Tweening.Tween t,  bool recyclable);
		
		delegate DG.Tweening.Tween __GEN_DELEGATE49( DG.Tweening.Tween t,  bool isIndependentUpdate);
		
		delegate DG.Tweening.Tween __GEN_DELEGATE50( DG.Tweening.Tween t,  DG.Tweening.UpdateType updateType);
		
		delegate DG.Tweening.Tween __GEN_DELEGATE51( DG.Tweening.Tween t,  DG.Tweening.UpdateType updateType,  bool isIndependentUpdate);
		
		delegate DG.Tweening.Tween __GEN_DELEGATE52( DG.Tweening.Tween t,  DG.Tweening.TweenCallback action);
		
		delegate DG.Tweening.Tween __GEN_DELEGATE53( DG.Tweening.Tween t,  DG.Tweening.TweenCallback action);
		
		delegate DG.Tweening.Tween __GEN_DELEGATE54( DG.Tweening.Tween t,  DG.Tweening.TweenCallback action);
		
		delegate DG.Tweening.Tween __GEN_DELEGATE55( DG.Tweening.Tween t,  DG.Tweening.TweenCallback action);
		
		delegate DG.Tweening.Tween __GEN_DELEGATE56( DG.Tweening.Tween t,  DG.Tweening.TweenCallback action);
		
		delegate DG.Tweening.Tween __GEN_DELEGATE57( DG.Tweening.Tween t,  DG.Tweening.TweenCallback action);
		
		delegate DG.Tweening.Tween __GEN_DELEGATE58( DG.Tweening.Tween t,  DG.Tweening.TweenCallback action);
		
		delegate DG.Tweening.Tween __GEN_DELEGATE59( DG.Tweening.Tween t,  DG.Tweening.TweenCallback action);
		
		delegate DG.Tweening.Tween __GEN_DELEGATE60( DG.Tweening.Tween t,  DG.Tweening.TweenCallback<int> action);
		
		delegate DG.Tweening.Tween __GEN_DELEGATE61( DG.Tweening.Tween t,  DG.Tweening.Tween asTween);
		
		delegate DG.Tweening.Tween __GEN_DELEGATE62( DG.Tweening.Tween t,  DG.Tweening.TweenParams tweenParams);
		
		delegate DG.Tweening.Sequence __GEN_DELEGATE63( DG.Tweening.Sequence s,  DG.Tweening.Tween t);
		
		delegate DG.Tweening.Sequence __GEN_DELEGATE64( DG.Tweening.Sequence s,  DG.Tweening.Tween t);
		
		delegate DG.Tweening.Sequence __GEN_DELEGATE65( DG.Tweening.Sequence s,  DG.Tweening.Tween t);
		
		delegate DG.Tweening.Sequence __GEN_DELEGATE66( DG.Tweening.Sequence s,  float atPosition,  DG.Tweening.Tween t);
		
		delegate DG.Tweening.Sequence __GEN_DELEGATE67( DG.Tweening.Sequence s,  float interval);
		
		delegate DG.Tweening.Sequence __GEN_DELEGATE68( DG.Tweening.Sequence s,  float interval);
		
		delegate DG.Tweening.Sequence __GEN_DELEGATE69( DG.Tweening.Sequence s,  DG.Tweening.TweenCallback callback);
		
		delegate DG.Tweening.Sequence __GEN_DELEGATE70( DG.Tweening.Sequence s,  DG.Tweening.TweenCallback callback);
		
		delegate DG.Tweening.Sequence __GEN_DELEGATE71( DG.Tweening.Sequence s,  float atPosition,  DG.Tweening.TweenCallback callback);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE72( DG.Tweening.Tweener t);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE73( DG.Tweening.Tweener t,  bool isRelative);
		
		delegate DG.Tweening.Tween __GEN_DELEGATE74( DG.Tweening.Tween t,  float delay);
		
		delegate DG.Tweening.Tween __GEN_DELEGATE75( DG.Tweening.Tween t);
		
		delegate DG.Tweening.Tween __GEN_DELEGATE76( DG.Tweening.Tween t,  bool isRelative);
		
		delegate DG.Tweening.Tween __GEN_DELEGATE77( DG.Tweening.Tween t);
		
		delegate DG.Tweening.Tween __GEN_DELEGATE78( DG.Tweening.Tween t,  bool isSpeedBased);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE79( DG.Tweening.Core.TweenerCore<float, float, DG.Tweening.Plugins.Options.FloatOptions> t,  bool snapping);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE80( DG.Tweening.Core.TweenerCore<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions> t,  bool snapping);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE81( DG.Tweening.Core.TweenerCore<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions> t,  DG.Tweening.AxisConstraint axisConstraint,  bool snapping);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE82( DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> t,  bool snapping);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE83( DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions> t,  DG.Tweening.AxisConstraint axisConstraint,  bool snapping);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE84( DG.Tweening.Core.TweenerCore<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions> t,  bool snapping);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE85( DG.Tweening.Core.TweenerCore<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions> t,  DG.Tweening.AxisConstraint axisConstraint,  bool snapping);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE86( DG.Tweening.Core.TweenerCore<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions> t,  bool useShortest360Route);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE87( DG.Tweening.Core.TweenerCore<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions> t,  bool alphaOnly);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE88( DG.Tweening.Core.TweenerCore<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions> t,  bool snapping);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE89( DG.Tweening.Core.TweenerCore<string, string, DG.Tweening.Plugins.Options.StringOptions> t,  bool richTextEnabled,  DG.Tweening.ScrambleMode scrambleMode,  string scrambleChars);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE90( DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3[], DG.Tweening.Plugins.Options.Vector3ArrayOptions> t,  bool snapping);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE91( DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3[], DG.Tweening.Plugins.Options.Vector3ArrayOptions> t,  DG.Tweening.AxisConstraint axisConstraint,  bool snapping);
		
		delegate DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions> __GEN_DELEGATE92( DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions> t,  DG.Tweening.AxisConstraint lockPosition,  DG.Tweening.AxisConstraint lockRotation);
		
		delegate DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions> __GEN_DELEGATE93( DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions> t,  bool closePath,  DG.Tweening.AxisConstraint lockPosition,  DG.Tweening.AxisConstraint lockRotation);
		
		delegate DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions> __GEN_DELEGATE94( DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions> t,  UnityEngine.Vector3 lookAtPosition,  System.Nullable<UnityEngine.Vector3> forwardDirection,  System.Nullable<UnityEngine.Vector3> up);
		
		delegate DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions> __GEN_DELEGATE95( DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions> t,  UnityEngine.Transform lookAtTransform,  System.Nullable<UnityEngine.Vector3> forwardDirection,  System.Nullable<UnityEngine.Vector3> up);
		
		delegate DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions> __GEN_DELEGATE96( DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions> t,  float lookAhead,  System.Nullable<UnityEngine.Vector3> forwardDirection,  System.Nullable<UnityEngine.Vector3> up);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE97( UnityEngine.AudioSource target,  float endValue,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE98( UnityEngine.AudioSource target,  float endValue,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE99( UnityEngine.Camera target,  float endValue,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE100( UnityEngine.Camera target,  UnityEngine.Color endValue,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE101( UnityEngine.Camera target,  float endValue,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE102( UnityEngine.Camera target,  float endValue,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE103( UnityEngine.Camera target,  float endValue,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE104( UnityEngine.Camera target,  float endValue,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE105( UnityEngine.Camera target,  UnityEngine.Rect endValue,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE106( UnityEngine.Camera target,  UnityEngine.Rect endValue,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE107( UnityEngine.Camera target,  float duration,  float strength,  int vibrato,  float randomness,  bool fadeOut);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE108( UnityEngine.Camera target,  float duration,  UnityEngine.Vector3 strength,  int vibrato,  float randomness,  bool fadeOut);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE109( UnityEngine.Camera target,  float duration,  float strength,  int vibrato,  float randomness,  bool fadeOut);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE110( UnityEngine.Camera target,  float duration,  UnityEngine.Vector3 strength,  int vibrato,  float randomness,  bool fadeOut);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE111( UnityEngine.Light target,  UnityEngine.Color endValue,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE112( UnityEngine.Light target,  float endValue,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE113( UnityEngine.Light target,  float endValue,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE114( UnityEngine.LineRenderer target,  DG.Tweening.Color2 startValue,  DG.Tweening.Color2 endValue,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE115( UnityEngine.Material target,  UnityEngine.Color endValue,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE116( UnityEngine.Material target,  UnityEngine.Color endValue,  string property,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE117( UnityEngine.Material target,  float endValue,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE118( UnityEngine.Material target,  float endValue,  string property,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE119( UnityEngine.Material target,  float endValue,  string property,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE120( UnityEngine.Material target,  UnityEngine.Vector2 endValue,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE121( UnityEngine.Material target,  UnityEngine.Vector2 endValue,  string property,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE122( UnityEngine.Material target,  UnityEngine.Vector2 endValue,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE123( UnityEngine.Material target,  UnityEngine.Vector2 endValue,  string property,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE124( UnityEngine.Material target,  UnityEngine.Vector4 endValue,  string property,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE125( UnityEngine.Rigidbody target,  UnityEngine.Vector3 endValue,  float duration,  bool snapping);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE126( UnityEngine.Rigidbody target,  float endValue,  float duration,  bool snapping);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE127( UnityEngine.Rigidbody target,  float endValue,  float duration,  bool snapping);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE128( UnityEngine.Rigidbody target,  float endValue,  float duration,  bool snapping);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE129( UnityEngine.Rigidbody target,  UnityEngine.Vector3 endValue,  float duration,  DG.Tweening.RotateMode mode);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE130( UnityEngine.Rigidbody target,  UnityEngine.Vector3 towards,  float duration,  DG.Tweening.AxisConstraint axisConstraint,  System.Nullable<UnityEngine.Vector3> up);
		
		delegate DG.Tweening.Sequence __GEN_DELEGATE131( UnityEngine.Rigidbody target,  UnityEngine.Vector3 endValue,  float jumpPower,  int numJumps,  float duration,  bool snapping);
		
		delegate DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions> __GEN_DELEGATE132( UnityEngine.Rigidbody target,  UnityEngine.Vector3[] path,  float duration,  DG.Tweening.PathType pathType,  DG.Tweening.PathMode pathMode,  int resolution,  System.Nullable<UnityEngine.Color> gizmoColor);
		
		delegate DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions> __GEN_DELEGATE133( UnityEngine.Rigidbody target,  UnityEngine.Vector3[] path,  float duration,  DG.Tweening.PathType pathType,  DG.Tweening.PathMode pathMode,  int resolution,  System.Nullable<UnityEngine.Color> gizmoColor);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE134( UnityEngine.TrailRenderer target,  float toStartWidth,  float toEndWidth,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE135( UnityEngine.TrailRenderer target,  float endValue,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE136( UnityEngine.Transform target,  UnityEngine.Vector3 endValue,  float duration,  bool snapping);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE137( UnityEngine.Transform target,  float endValue,  float duration,  bool snapping);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE138( UnityEngine.Transform target,  float endValue,  float duration,  bool snapping);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE139( UnityEngine.Transform target,  float endValue,  float duration,  bool snapping);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE140( UnityEngine.Transform target,  UnityEngine.Vector3 endValue,  float duration,  bool snapping);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE141( UnityEngine.Transform target,  float endValue,  float duration,  bool snapping);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE142( UnityEngine.Transform target,  float endValue,  float duration,  bool snapping);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE143( UnityEngine.Transform target,  float endValue,  float duration,  bool snapping);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE144( UnityEngine.Transform target,  UnityEngine.Vector3 endValue,  float duration,  DG.Tweening.RotateMode mode);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE145( UnityEngine.Transform target,  UnityEngine.Quaternion endValue,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE146( UnityEngine.Transform target,  UnityEngine.Vector3 endValue,  float duration,  DG.Tweening.RotateMode mode);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE147( UnityEngine.Transform target,  UnityEngine.Quaternion endValue,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE148( UnityEngine.Transform target,  UnityEngine.Vector3 endValue,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE149( UnityEngine.Transform target,  float endValue,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE150( UnityEngine.Transform target,  float endValue,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE151( UnityEngine.Transform target,  float endValue,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE152( UnityEngine.Transform target,  float endValue,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE153( UnityEngine.Transform target,  UnityEngine.Vector3 towards,  float duration,  DG.Tweening.AxisConstraint axisConstraint,  System.Nullable<UnityEngine.Vector3> up);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE154( UnityEngine.Transform target,  UnityEngine.Vector3 punch,  float duration,  int vibrato,  float elasticity,  bool snapping);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE155( UnityEngine.Transform target,  UnityEngine.Vector3 punch,  float duration,  int vibrato,  float elasticity);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE156( UnityEngine.Transform target,  UnityEngine.Vector3 punch,  float duration,  int vibrato,  float elasticity);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE157( UnityEngine.Transform target,  float duration,  float strength,  int vibrato,  float randomness,  bool snapping,  bool fadeOut);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE158( UnityEngine.Transform target,  float duration,  UnityEngine.Vector3 strength,  int vibrato,  float randomness,  bool snapping,  bool fadeOut);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE159( UnityEngine.Transform target,  float duration,  float strength,  int vibrato,  float randomness,  bool fadeOut);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE160( UnityEngine.Transform target,  float duration,  UnityEngine.Vector3 strength,  int vibrato,  float randomness,  bool fadeOut);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE161( UnityEngine.Transform target,  float duration,  float strength,  int vibrato,  float randomness,  bool fadeOut);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE162( UnityEngine.Transform target,  float duration,  UnityEngine.Vector3 strength,  int vibrato,  float randomness,  bool fadeOut);
		
		delegate DG.Tweening.Sequence __GEN_DELEGATE163( UnityEngine.Transform target,  UnityEngine.Vector3 endValue,  float jumpPower,  int numJumps,  float duration,  bool snapping);
		
		delegate DG.Tweening.Sequence __GEN_DELEGATE164( UnityEngine.Transform target,  UnityEngine.Vector3 endValue,  float jumpPower,  int numJumps,  float duration,  bool snapping);
		
		delegate DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions> __GEN_DELEGATE165( UnityEngine.Transform target,  UnityEngine.Vector3[] path,  float duration,  DG.Tweening.PathType pathType,  DG.Tweening.PathMode pathMode,  int resolution,  System.Nullable<UnityEngine.Color> gizmoColor);
		
		delegate DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions> __GEN_DELEGATE166( UnityEngine.Transform target,  UnityEngine.Vector3[] path,  float duration,  DG.Tweening.PathType pathType,  DG.Tweening.PathMode pathMode,  int resolution,  System.Nullable<UnityEngine.Color> gizmoColor);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE167( DG.Tweening.Tween target,  float endValue,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE168( UnityEngine.Light target,  UnityEngine.Color endValue,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE169( UnityEngine.Material target,  UnityEngine.Color endValue,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE170( UnityEngine.Material target,  UnityEngine.Color endValue,  string property,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE171( UnityEngine.Transform target,  UnityEngine.Vector3 byValue,  float duration,  bool snapping);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE172( UnityEngine.Transform target,  UnityEngine.Vector3 byValue,  float duration,  bool snapping);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE173( UnityEngine.Transform target,  UnityEngine.Vector3 byValue,  float duration,  DG.Tweening.RotateMode mode);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE174( UnityEngine.Transform target,  UnityEngine.Vector3 byValue,  float duration,  DG.Tweening.RotateMode mode);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE175( UnityEngine.Transform target,  UnityEngine.Vector3 byValue,  float duration);
		
		delegate int __GEN_DELEGATE176( UnityEngine.Component target,  bool withCallbacks);
		
		delegate int __GEN_DELEGATE177( UnityEngine.Material target,  bool withCallbacks);
		
		delegate int __GEN_DELEGATE178( UnityEngine.Component target,  bool complete);
		
		delegate int __GEN_DELEGATE179( UnityEngine.Material target,  bool complete);
		
		delegate int __GEN_DELEGATE180( UnityEngine.Component target);
		
		delegate int __GEN_DELEGATE181( UnityEngine.Material target);
		
		delegate int __GEN_DELEGATE182( UnityEngine.Component target,  float to,  bool andPlay);
		
		delegate int __GEN_DELEGATE183( UnityEngine.Material target,  float to,  bool andPlay);
		
		delegate int __GEN_DELEGATE184( UnityEngine.Component target);
		
		delegate int __GEN_DELEGATE185( UnityEngine.Material target);
		
		delegate int __GEN_DELEGATE186( UnityEngine.Component target);
		
		delegate int __GEN_DELEGATE187( UnityEngine.Material target);
		
		delegate int __GEN_DELEGATE188( UnityEngine.Component target);
		
		delegate int __GEN_DELEGATE189( UnityEngine.Material target);
		
		delegate int __GEN_DELEGATE190( UnityEngine.Component target);
		
		delegate int __GEN_DELEGATE191( UnityEngine.Material target);
		
		delegate int __GEN_DELEGATE192( UnityEngine.Component target,  bool includeDelay);
		
		delegate int __GEN_DELEGATE193( UnityEngine.Material target,  bool includeDelay);
		
		delegate int __GEN_DELEGATE194( UnityEngine.Component target,  bool includeDelay);
		
		delegate int __GEN_DELEGATE195( UnityEngine.Material target,  bool includeDelay);
		
		delegate int __GEN_DELEGATE196( UnityEngine.Component target);
		
		delegate int __GEN_DELEGATE197( UnityEngine.Material target);
		
		delegate int __GEN_DELEGATE198( UnityEngine.Component target);
		
		delegate int __GEN_DELEGATE199( UnityEngine.Material target);
		
		delegate DG.Tweening.Sequence __GEN_DELEGATE200( UnityEngine.Material target,  UnityEngine.Gradient gradient,  float duration);
		
		delegate DG.Tweening.Sequence __GEN_DELEGATE201( UnityEngine.Material target,  UnityEngine.Gradient gradient,  string property,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE202( UnityEngine.SpriteRenderer target,  UnityEngine.Color endValue,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE203( UnityEngine.SpriteRenderer target,  float endValue,  float duration);
		
		delegate DG.Tweening.Sequence __GEN_DELEGATE204( UnityEngine.SpriteRenderer target,  UnityEngine.Gradient gradient,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE205( UnityEngine.Rigidbody2D target,  UnityEngine.Vector2 endValue,  float duration,  bool snapping);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE206( UnityEngine.Rigidbody2D target,  float endValue,  float duration,  bool snapping);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE207( UnityEngine.Rigidbody2D target,  float endValue,  float duration,  bool snapping);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE208( UnityEngine.Rigidbody2D target,  float endValue,  float duration);
		
		delegate DG.Tweening.Sequence __GEN_DELEGATE209( UnityEngine.Rigidbody2D target,  UnityEngine.Vector2 endValue,  float jumpPower,  int numJumps,  float duration,  bool snapping);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE210( UnityEngine.SpriteRenderer target,  UnityEngine.Color endValue,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE211( UnityEngine.CanvasGroup target,  float endValue,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE212( UnityEngine.UI.Graphic target,  UnityEngine.Color endValue,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE213( UnityEngine.UI.Graphic target,  float endValue,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE214( UnityEngine.UI.Image target,  UnityEngine.Color endValue,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE215( UnityEngine.UI.Image target,  float endValue,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE216( UnityEngine.UI.Image target,  float endValue,  float duration);
		
		delegate DG.Tweening.Sequence __GEN_DELEGATE217( UnityEngine.UI.Image target,  UnityEngine.Gradient gradient,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE218( UnityEngine.UI.LayoutElement target,  UnityEngine.Vector2 endValue,  float duration,  bool snapping);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE219( UnityEngine.UI.LayoutElement target,  UnityEngine.Vector2 endValue,  float duration,  bool snapping);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE220( UnityEngine.UI.LayoutElement target,  UnityEngine.Vector2 endValue,  float duration,  bool snapping);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE221( UnityEngine.UI.Outline target,  UnityEngine.Color endValue,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE222( UnityEngine.UI.Outline target,  float endValue,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE223( UnityEngine.UI.Outline target,  UnityEngine.Vector2 endValue,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE224( UnityEngine.RectTransform target,  UnityEngine.Vector2 endValue,  float duration,  bool snapping);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE225( UnityEngine.RectTransform target,  float endValue,  float duration,  bool snapping);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE226( UnityEngine.RectTransform target,  float endValue,  float duration,  bool snapping);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE227( UnityEngine.RectTransform target,  UnityEngine.Vector3 endValue,  float duration,  bool snapping);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE228( UnityEngine.RectTransform target,  UnityEngine.Vector2 endValue,  float duration,  bool snapping);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE229( UnityEngine.RectTransform target,  UnityEngine.Vector2 endValue,  float duration,  bool snapping);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE230( UnityEngine.RectTransform target,  UnityEngine.Vector2 endValue,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE231( UnityEngine.RectTransform target,  float endValue,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE232( UnityEngine.RectTransform target,  float endValue,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE233( UnityEngine.RectTransform target,  UnityEngine.Vector2 endValue,  float duration,  bool snapping);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE234( UnityEngine.RectTransform target,  UnityEngine.Vector2 punch,  float duration,  int vibrato,  float elasticity,  bool snapping);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE235( UnityEngine.RectTransform target,  float duration,  float strength,  int vibrato,  float randomness,  bool snapping,  bool fadeOut);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE236( UnityEngine.RectTransform target,  float duration,  UnityEngine.Vector2 strength,  int vibrato,  float randomness,  bool snapping,  bool fadeOut);
		
		delegate DG.Tweening.Sequence __GEN_DELEGATE237( UnityEngine.RectTransform target,  UnityEngine.Vector2 endValue,  float jumpPower,  int numJumps,  float duration,  bool snapping);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE238( UnityEngine.UI.ScrollRect target,  UnityEngine.Vector2 endValue,  float duration,  bool snapping);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE239( UnityEngine.UI.ScrollRect target,  float endValue,  float duration,  bool snapping);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE240( UnityEngine.UI.ScrollRect target,  float endValue,  float duration,  bool snapping);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE241( UnityEngine.UI.Slider target,  float endValue,  float duration,  bool snapping);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE242( UnityEngine.UI.Text target,  UnityEngine.Color endValue,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE243( UnityEngine.UI.Text target,  float endValue,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE244( UnityEngine.UI.Text target,  string endValue,  float duration,  bool richTextEnabled,  DG.Tweening.ScrambleMode scrambleMode,  string scrambleChars);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE245( UnityEngine.UI.Graphic target,  UnityEngine.Color endValue,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE246( UnityEngine.UI.Image target,  UnityEngine.Color endValue,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE247( UnityEngine.UI.Text target,  UnityEngine.Color endValue,  float duration);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE248( UnityEngine.Audio.AudioMixer target,  string floatName,  float endValue,  float duration);
		
		delegate int __GEN_DELEGATE249( UnityEngine.Audio.AudioMixer target,  bool withCallbacks);
		
		delegate int __GEN_DELEGATE250( UnityEngine.Audio.AudioMixer target,  bool complete);
		
		delegate int __GEN_DELEGATE251( UnityEngine.Audio.AudioMixer target);
		
		delegate int __GEN_DELEGATE252( UnityEngine.Audio.AudioMixer target,  float to,  bool andPlay);
		
		delegate int __GEN_DELEGATE253( UnityEngine.Audio.AudioMixer target);
		
		delegate int __GEN_DELEGATE254( UnityEngine.Audio.AudioMixer target);
		
		delegate int __GEN_DELEGATE255( UnityEngine.Audio.AudioMixer target);
		
		delegate int __GEN_DELEGATE256( UnityEngine.Audio.AudioMixer target);
		
		delegate int __GEN_DELEGATE257( UnityEngine.Audio.AudioMixer target);
		
		delegate int __GEN_DELEGATE258( UnityEngine.Audio.AudioMixer target);
		
		delegate int __GEN_DELEGATE259( UnityEngine.Audio.AudioMixer target);
		
		delegate int __GEN_DELEGATE260( UnityEngine.Audio.AudioMixer target);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE261( DG.Tweening.Core.TweenerCore<float, float, DG.Tweening.Plugins.Options.FloatOptions> t,  bool snapping);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE262( DG.Tweening.Core.TweenerCore<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions> t,  bool snapping);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE263( DG.Tweening.Core.TweenerCore<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions> t,  DG.Tweening.AxisConstraint axisConstraint,  bool snapping);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE264( DG.Tweening.Core.TweenerCore<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions> t,  bool snapping);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE265( DG.Tweening.Core.TweenerCore<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions> t,  DG.Tweening.AxisConstraint axisConstraint,  bool snapping);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE266( DG.Tweening.Core.TweenerCore<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions> t,  bool useShortest360Route);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE267( DG.Tweening.Core.TweenerCore<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions> t,  bool alphaOnly);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE268( DG.Tweening.Core.TweenerCore<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions> t,  bool snapping);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE269( DG.Tweening.Core.TweenerCore<string, string, DG.Tweening.Plugins.Options.StringOptions> t,  bool richTextEnabled,  DG.Tweening.ScrambleMode scrambleMode,  string scrambleChars);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE270( DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3[], DG.Tweening.Plugins.Options.Vector3ArrayOptions> t,  bool snapping);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE271( DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3[], DG.Tweening.Plugins.Options.Vector3ArrayOptions> t,  DG.Tweening.AxisConstraint axisConstraint,  bool snapping);
		
		delegate DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions> __GEN_DELEGATE272( DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions> t,  DG.Tweening.AxisConstraint lockPosition,  DG.Tweening.AxisConstraint lockRotation);
		
		delegate DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions> __GEN_DELEGATE273( DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions> t,  bool closePath,  DG.Tweening.AxisConstraint lockPosition,  DG.Tweening.AxisConstraint lockRotation);
		
		delegate DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions> __GEN_DELEGATE274( DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions> t,  UnityEngine.Vector3 lookAtPosition,  System.Nullable<UnityEngine.Vector3> forwardDirection,  System.Nullable<UnityEngine.Vector3> up);
		
		delegate DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions> __GEN_DELEGATE275( DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions> t,  UnityEngine.Transform lookAtTransform,  System.Nullable<UnityEngine.Vector3> forwardDirection,  System.Nullable<UnityEngine.Vector3> up);
		
		delegate DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions> __GEN_DELEGATE276( DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions> t,  float lookAhead,  System.Nullable<UnityEngine.Vector3> forwardDirection,  System.Nullable<UnityEngine.Vector3> up);
		
		delegate DG.Tweening.Tweener __GEN_DELEGATE277( UnityEngine.Audio.AudioMixer target,  string floatName,  float endValue,  float duration);
		
		delegate int __GEN_DELEGATE278( UnityEngine.Audio.AudioMixer target,  bool withCallbacks);
		
		delegate int __GEN_DELEGATE279( UnityEngine.Audio.AudioMixer target,  bool complete);
		
		delegate int __GEN_DELEGATE280( UnityEngine.Audio.AudioMixer target);
		
		delegate int __GEN_DELEGATE281( UnityEngine.Audio.AudioMixer target,  float to,  bool andPlay);
		
		delegate int __GEN_DELEGATE282( UnityEngine.Audio.AudioMixer target);
		
		delegate int __GEN_DELEGATE283( UnityEngine.Audio.AudioMixer target);
		
		delegate int __GEN_DELEGATE284( UnityEngine.Audio.AudioMixer target);
		
		delegate int __GEN_DELEGATE285( UnityEngine.Audio.AudioMixer target);
		
		delegate int __GEN_DELEGATE286( UnityEngine.Audio.AudioMixer target);
		
		delegate int __GEN_DELEGATE287( UnityEngine.Audio.AudioMixer target);
		
		delegate int __GEN_DELEGATE288( UnityEngine.Audio.AudioMixer target);
		
		delegate int __GEN_DELEGATE289( UnityEngine.Audio.AudioMixer target);
		
		delegate UnityEngine.PhysicsScene __GEN_DELEGATE290( UnityEngine.SceneManagement.Scene scene);
		
		delegate UnityEngine.PhysicsScene2D __GEN_DELEGATE291( UnityEngine.SceneManagement.Scene scene);
		
	    static InternalGlobals()
		{
		    extensionMethodMap = new Dictionary<Type, IEnumerable<MethodInfo>>()
			{
			    
				{typeof(DG.Tweening.Tween), new List<MethodInfo>(){
				
				  new __GEN_DELEGATE0(DG.Tweening.TweenExtensions.Complete)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE1(DG.Tweening.TweenExtensions.Complete)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE2(DG.Tweening.TweenExtensions.Flip)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE3(DG.Tweening.TweenExtensions.ForceInit)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE4(DG.Tweening.TweenExtensions.Goto)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE5(DG.Tweening.TweenExtensions.Kill)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE6(DG.Tweening.TweenExtensions.Pause)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE7(DG.Tweening.TweenExtensions.Play)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE8(DG.Tweening.TweenExtensions.PlayBackwards)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE9(DG.Tweening.TweenExtensions.PlayForward)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE10(DG.Tweening.TweenExtensions.Restart)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE11(DG.Tweening.TweenExtensions.Rewind)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE12(DG.Tweening.TweenExtensions.SmoothRewind)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE13(DG.Tweening.TweenExtensions.TogglePause)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE14(DG.Tweening.TweenExtensions.GotoWaypoint)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE15(DG.Tweening.TweenExtensions.WaitForCompletion)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE16(DG.Tweening.TweenExtensions.WaitForRewind)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE17(DG.Tweening.TweenExtensions.WaitForKill)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE18(DG.Tweening.TweenExtensions.WaitForElapsedLoops)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE19(DG.Tweening.TweenExtensions.WaitForPosition)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE20(DG.Tweening.TweenExtensions.WaitForStart)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE21(DG.Tweening.TweenExtensions.CompletedLoops)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE22(DG.Tweening.TweenExtensions.Delay)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE23(DG.Tweening.TweenExtensions.Duration)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE24(DG.Tweening.TweenExtensions.Elapsed)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE25(DG.Tweening.TweenExtensions.ElapsedPercentage)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE26(DG.Tweening.TweenExtensions.ElapsedDirectionalPercentage)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE27(DG.Tweening.TweenExtensions.IsActive)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE28(DG.Tweening.TweenExtensions.IsBackwards)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE29(DG.Tweening.TweenExtensions.IsComplete)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE30(DG.Tweening.TweenExtensions.IsInitialized)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE31(DG.Tweening.TweenExtensions.IsPlaying)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE32(DG.Tweening.TweenExtensions.Loops)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE33(DG.Tweening.TweenExtensions.PathGetPoint)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE34(DG.Tweening.TweenExtensions.PathGetDrawPoints)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE35(DG.Tweening.TweenExtensions.PathLength)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE36(DG.Tweening.TweenSettingsExtensions.SetAutoKill)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE37(DG.Tweening.TweenSettingsExtensions.SetAutoKill)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE38(DG.Tweening.TweenSettingsExtensions.SetId)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE39(DG.Tweening.TweenSettingsExtensions.SetTarget)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE40(DG.Tweening.TweenSettingsExtensions.SetLoops)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE41(DG.Tweening.TweenSettingsExtensions.SetLoops)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE42(DG.Tweening.TweenSettingsExtensions.SetEase)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE43(DG.Tweening.TweenSettingsExtensions.SetEase)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE44(DG.Tweening.TweenSettingsExtensions.SetEase)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE45(DG.Tweening.TweenSettingsExtensions.SetEase)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE46(DG.Tweening.TweenSettingsExtensions.SetEase)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE47(DG.Tweening.TweenSettingsExtensions.SetRecyclable)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE48(DG.Tweening.TweenSettingsExtensions.SetRecyclable)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE49(DG.Tweening.TweenSettingsExtensions.SetUpdate)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE50(DG.Tweening.TweenSettingsExtensions.SetUpdate)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE51(DG.Tweening.TweenSettingsExtensions.SetUpdate)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE52(DG.Tweening.TweenSettingsExtensions.OnStart)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE53(DG.Tweening.TweenSettingsExtensions.OnPlay)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE54(DG.Tweening.TweenSettingsExtensions.OnPause)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE55(DG.Tweening.TweenSettingsExtensions.OnRewind)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE56(DG.Tweening.TweenSettingsExtensions.OnUpdate)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE57(DG.Tweening.TweenSettingsExtensions.OnStepComplete)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE58(DG.Tweening.TweenSettingsExtensions.OnComplete)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE59(DG.Tweening.TweenSettingsExtensions.OnKill)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE60(DG.Tweening.TweenSettingsExtensions.OnWaypointChange)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE61(DG.Tweening.TweenSettingsExtensions.SetAs)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE62(DG.Tweening.TweenSettingsExtensions.SetAs)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE74(DG.Tweening.TweenSettingsExtensions.SetDelay)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE75(DG.Tweening.TweenSettingsExtensions.SetRelative)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE76(DG.Tweening.TweenSettingsExtensions.SetRelative)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE77(DG.Tweening.TweenSettingsExtensions.SetSpeedBased)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE78(DG.Tweening.TweenSettingsExtensions.SetSpeedBased)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE167(DG.Tweening.ShortcutExtensions.DOTimeScale)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				}},
				
				{typeof(DG.Tweening.Sequence), new List<MethodInfo>(){
				
				  new __GEN_DELEGATE63(DG.Tweening.TweenSettingsExtensions.Append)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE64(DG.Tweening.TweenSettingsExtensions.Prepend)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE65(DG.Tweening.TweenSettingsExtensions.Join)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE66(DG.Tweening.TweenSettingsExtensions.Insert)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE67(DG.Tweening.TweenSettingsExtensions.AppendInterval)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE68(DG.Tweening.TweenSettingsExtensions.PrependInterval)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE69(DG.Tweening.TweenSettingsExtensions.AppendCallback)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE70(DG.Tweening.TweenSettingsExtensions.PrependCallback)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE71(DG.Tweening.TweenSettingsExtensions.InsertCallback)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				}},
				
				{typeof(DG.Tweening.Tweener), new List<MethodInfo>(){
				
				  new __GEN_DELEGATE72(DG.Tweening.TweenSettingsExtensions.From)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE73(DG.Tweening.TweenSettingsExtensions.From)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				}},
				
				{typeof(DG.Tweening.Core.TweenerCore<float, float, DG.Tweening.Plugins.Options.FloatOptions>), new List<MethodInfo>(){
				
				  new __GEN_DELEGATE79(DG.Tweening.TweenSettingsExtensions.SetOptions)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE261(DG.Tweening.TweenSettingsExtensions.SetOptions)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				}},
				
				{typeof(DG.Tweening.Core.TweenerCore<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>), new List<MethodInfo>(){
				
				  new __GEN_DELEGATE80(DG.Tweening.TweenSettingsExtensions.SetOptions)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE81(DG.Tweening.TweenSettingsExtensions.SetOptions)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE262(DG.Tweening.TweenSettingsExtensions.SetOptions)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE263(DG.Tweening.TweenSettingsExtensions.SetOptions)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				}},
				
				{typeof(DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>), new List<MethodInfo>(){
				
				  new __GEN_DELEGATE82(DG.Tweening.TweenSettingsExtensions.SetOptions)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE83(DG.Tweening.TweenSettingsExtensions.SetOptions)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				}},
				
				{typeof(DG.Tweening.Core.TweenerCore<UnityEngine.Vector4, UnityEngine.Vector4, DG.Tweening.Plugins.Options.VectorOptions>), new List<MethodInfo>(){
				
				  new __GEN_DELEGATE84(DG.Tweening.TweenSettingsExtensions.SetOptions)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE85(DG.Tweening.TweenSettingsExtensions.SetOptions)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE264(DG.Tweening.TweenSettingsExtensions.SetOptions)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE265(DG.Tweening.TweenSettingsExtensions.SetOptions)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				}},
				
				{typeof(DG.Tweening.Core.TweenerCore<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>), new List<MethodInfo>(){
				
				  new __GEN_DELEGATE86(DG.Tweening.TweenSettingsExtensions.SetOptions)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE266(DG.Tweening.TweenSettingsExtensions.SetOptions)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				}},
				
				{typeof(DG.Tweening.Core.TweenerCore<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>), new List<MethodInfo>(){
				
				  new __GEN_DELEGATE87(DG.Tweening.TweenSettingsExtensions.SetOptions)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE267(DG.Tweening.TweenSettingsExtensions.SetOptions)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				}},
				
				{typeof(DG.Tweening.Core.TweenerCore<UnityEngine.Rect, UnityEngine.Rect, DG.Tweening.Plugins.Options.RectOptions>), new List<MethodInfo>(){
				
				  new __GEN_DELEGATE88(DG.Tweening.TweenSettingsExtensions.SetOptions)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE268(DG.Tweening.TweenSettingsExtensions.SetOptions)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				}},
				
				{typeof(DG.Tweening.Core.TweenerCore<string, string, DG.Tweening.Plugins.Options.StringOptions>), new List<MethodInfo>(){
				
				  new __GEN_DELEGATE89(DG.Tweening.TweenSettingsExtensions.SetOptions)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE269(DG.Tweening.TweenSettingsExtensions.SetOptions)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				}},
				
				{typeof(DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3[], DG.Tweening.Plugins.Options.Vector3ArrayOptions>), new List<MethodInfo>(){
				
				  new __GEN_DELEGATE90(DG.Tweening.TweenSettingsExtensions.SetOptions)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE91(DG.Tweening.TweenSettingsExtensions.SetOptions)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE270(DG.Tweening.TweenSettingsExtensions.SetOptions)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE271(DG.Tweening.TweenSettingsExtensions.SetOptions)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				}},
				
				{typeof(DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>), new List<MethodInfo>(){
				
				  new __GEN_DELEGATE92(DG.Tweening.TweenSettingsExtensions.SetOptions)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE93(DG.Tweening.TweenSettingsExtensions.SetOptions)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE94(DG.Tweening.TweenSettingsExtensions.SetLookAt)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE95(DG.Tweening.TweenSettingsExtensions.SetLookAt)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE96(DG.Tweening.TweenSettingsExtensions.SetLookAt)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE272(DG.Tweening.TweenSettingsExtensions.SetOptions)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE273(DG.Tweening.TweenSettingsExtensions.SetOptions)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE274(DG.Tweening.TweenSettingsExtensions.SetLookAt)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE275(DG.Tweening.TweenSettingsExtensions.SetLookAt)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE276(DG.Tweening.TweenSettingsExtensions.SetLookAt)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				}},
				
				{typeof(UnityEngine.AudioSource), new List<MethodInfo>(){
				
				  new __GEN_DELEGATE97(DG.Tweening.ShortcutExtensions.DOFade)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE98(DG.Tweening.ShortcutExtensions.DOPitch)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				}},
				
				{typeof(UnityEngine.Camera), new List<MethodInfo>(){
				
				  new __GEN_DELEGATE99(DG.Tweening.ShortcutExtensions.DOAspect)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE100(DG.Tweening.ShortcutExtensions.DOColor)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE101(DG.Tweening.ShortcutExtensions.DOFarClipPlane)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE102(DG.Tweening.ShortcutExtensions.DOFieldOfView)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE103(DG.Tweening.ShortcutExtensions.DONearClipPlane)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE104(DG.Tweening.ShortcutExtensions.DOOrthoSize)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE105(DG.Tweening.ShortcutExtensions.DOPixelRect)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE106(DG.Tweening.ShortcutExtensions.DORect)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE107(DG.Tweening.ShortcutExtensions.DOShakePosition)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE108(DG.Tweening.ShortcutExtensions.DOShakePosition)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE109(DG.Tweening.ShortcutExtensions.DOShakeRotation)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE110(DG.Tweening.ShortcutExtensions.DOShakeRotation)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				}},
				
				{typeof(UnityEngine.Light), new List<MethodInfo>(){
				
				  new __GEN_DELEGATE111(DG.Tweening.ShortcutExtensions.DOColor)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE112(DG.Tweening.ShortcutExtensions.DOIntensity)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE113(DG.Tweening.ShortcutExtensions.DOShadowStrength)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE168(DG.Tweening.ShortcutExtensions.DOBlendableColor)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				}},
				
				{typeof(UnityEngine.LineRenderer), new List<MethodInfo>(){
				
				  new __GEN_DELEGATE114(DG.Tweening.ShortcutExtensions.DOColor)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				}},
				
				{typeof(UnityEngine.Material), new List<MethodInfo>(){
				
				  new __GEN_DELEGATE115(DG.Tweening.ShortcutExtensions.DOColor)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE116(DG.Tweening.ShortcutExtensions.DOColor)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE117(DG.Tweening.ShortcutExtensions.DOFade)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE118(DG.Tweening.ShortcutExtensions.DOFade)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE119(DG.Tweening.ShortcutExtensions.DOFloat)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE120(DG.Tweening.ShortcutExtensions.DOOffset)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE121(DG.Tweening.ShortcutExtensions.DOOffset)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE122(DG.Tweening.ShortcutExtensions.DOTiling)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE123(DG.Tweening.ShortcutExtensions.DOTiling)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE124(DG.Tweening.ShortcutExtensions.DOVector)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE169(DG.Tweening.ShortcutExtensions.DOBlendableColor)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE170(DG.Tweening.ShortcutExtensions.DOBlendableColor)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE177(DG.Tweening.ShortcutExtensions.DOComplete)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE179(DG.Tweening.ShortcutExtensions.DOKill)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE181(DG.Tweening.ShortcutExtensions.DOFlip)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE183(DG.Tweening.ShortcutExtensions.DOGoto)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE185(DG.Tweening.ShortcutExtensions.DOPause)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE187(DG.Tweening.ShortcutExtensions.DOPlay)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE189(DG.Tweening.ShortcutExtensions.DOPlayBackwards)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE191(DG.Tweening.ShortcutExtensions.DOPlayForward)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE193(DG.Tweening.ShortcutExtensions.DORestart)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE195(DG.Tweening.ShortcutExtensions.DORewind)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE197(DG.Tweening.ShortcutExtensions.DOSmoothRewind)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE199(DG.Tweening.ShortcutExtensions.DOTogglePause)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE200(DG.Tweening.ShortcutExtensions43.DOGradientColor)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE201(DG.Tweening.ShortcutExtensions43.DOGradientColor)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				}},
				
				{typeof(UnityEngine.Rigidbody), new List<MethodInfo>(){
				
				  new __GEN_DELEGATE125(DG.Tweening.ShortcutExtensions.DOMove)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE126(DG.Tweening.ShortcutExtensions.DOMoveX)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE127(DG.Tweening.ShortcutExtensions.DOMoveY)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE128(DG.Tweening.ShortcutExtensions.DOMoveZ)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE129(DG.Tweening.ShortcutExtensions.DORotate)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE130(DG.Tweening.ShortcutExtensions.DOLookAt)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE131(DG.Tweening.ShortcutExtensions.DOJump)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE132(DG.Tweening.ShortcutExtensions.DOPath)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE133(DG.Tweening.ShortcutExtensions.DOLocalPath)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				}},
				
				{typeof(UnityEngine.TrailRenderer), new List<MethodInfo>(){
				
				  new __GEN_DELEGATE134(DG.Tweening.ShortcutExtensions.DOResize)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE135(DG.Tweening.ShortcutExtensions.DOTime)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				}},
				
				{typeof(UnityEngine.Transform), new List<MethodInfo>(){
				
				  new __GEN_DELEGATE136(DG.Tweening.ShortcutExtensions.DOMove)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE137(DG.Tweening.ShortcutExtensions.DOMoveX)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE138(DG.Tweening.ShortcutExtensions.DOMoveY)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE139(DG.Tweening.ShortcutExtensions.DOMoveZ)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE140(DG.Tweening.ShortcutExtensions.DOLocalMove)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE141(DG.Tweening.ShortcutExtensions.DOLocalMoveX)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE142(DG.Tweening.ShortcutExtensions.DOLocalMoveY)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE143(DG.Tweening.ShortcutExtensions.DOLocalMoveZ)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE144(DG.Tweening.ShortcutExtensions.DORotate)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE145(DG.Tweening.ShortcutExtensions.DORotateQuaternion)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE146(DG.Tweening.ShortcutExtensions.DOLocalRotate)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE147(DG.Tweening.ShortcutExtensions.DOLocalRotateQuaternion)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE148(DG.Tweening.ShortcutExtensions.DOScale)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE149(DG.Tweening.ShortcutExtensions.DOScale)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE150(DG.Tweening.ShortcutExtensions.DOScaleX)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE151(DG.Tweening.ShortcutExtensions.DOScaleY)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE152(DG.Tweening.ShortcutExtensions.DOScaleZ)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE153(DG.Tweening.ShortcutExtensions.DOLookAt)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE154(DG.Tweening.ShortcutExtensions.DOPunchPosition)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE155(DG.Tweening.ShortcutExtensions.DOPunchScale)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE156(DG.Tweening.ShortcutExtensions.DOPunchRotation)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE157(DG.Tweening.ShortcutExtensions.DOShakePosition)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE158(DG.Tweening.ShortcutExtensions.DOShakePosition)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE159(DG.Tweening.ShortcutExtensions.DOShakeRotation)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE160(DG.Tweening.ShortcutExtensions.DOShakeRotation)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE161(DG.Tweening.ShortcutExtensions.DOShakeScale)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE162(DG.Tweening.ShortcutExtensions.DOShakeScale)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE163(DG.Tweening.ShortcutExtensions.DOJump)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE164(DG.Tweening.ShortcutExtensions.DOLocalJump)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE165(DG.Tweening.ShortcutExtensions.DOPath)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE166(DG.Tweening.ShortcutExtensions.DOLocalPath)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE171(DG.Tweening.ShortcutExtensions.DOBlendableMoveBy)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE172(DG.Tweening.ShortcutExtensions.DOBlendableLocalMoveBy)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE173(DG.Tweening.ShortcutExtensions.DOBlendableRotateBy)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE174(DG.Tweening.ShortcutExtensions.DOBlendableLocalRotateBy)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE175(DG.Tweening.ShortcutExtensions.DOBlendableScaleBy)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				}},
				
				{typeof(UnityEngine.Component), new List<MethodInfo>(){
				
				  new __GEN_DELEGATE176(DG.Tweening.ShortcutExtensions.DOComplete)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE178(DG.Tweening.ShortcutExtensions.DOKill)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE180(DG.Tweening.ShortcutExtensions.DOFlip)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE182(DG.Tweening.ShortcutExtensions.DOGoto)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE184(DG.Tweening.ShortcutExtensions.DOPause)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE186(DG.Tweening.ShortcutExtensions.DOPlay)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE188(DG.Tweening.ShortcutExtensions.DOPlayBackwards)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE190(DG.Tweening.ShortcutExtensions.DOPlayForward)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE192(DG.Tweening.ShortcutExtensions.DORestart)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE194(DG.Tweening.ShortcutExtensions.DORewind)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE196(DG.Tweening.ShortcutExtensions.DOSmoothRewind)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE198(DG.Tweening.ShortcutExtensions.DOTogglePause)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				}},
				
				{typeof(UnityEngine.SpriteRenderer), new List<MethodInfo>(){
				
				  new __GEN_DELEGATE202(DG.Tweening.ShortcutExtensions43.DOColor)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE203(DG.Tweening.ShortcutExtensions43.DOFade)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE204(DG.Tweening.ShortcutExtensions43.DOGradientColor)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE210(DG.Tweening.ShortcutExtensions43.DOBlendableColor)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				}},
				
				{typeof(UnityEngine.Rigidbody2D), new List<MethodInfo>(){
				
				  new __GEN_DELEGATE205(DG.Tweening.ShortcutExtensions43.DOMove)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE206(DG.Tweening.ShortcutExtensions43.DOMoveX)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE207(DG.Tweening.ShortcutExtensions43.DOMoveY)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE208(DG.Tweening.ShortcutExtensions43.DORotate)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE209(DG.Tweening.ShortcutExtensions43.DOJump)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				}},
				
				{typeof(UnityEngine.CanvasGroup), new List<MethodInfo>(){
				
				  new __GEN_DELEGATE211(DG.Tweening.ShortcutExtensions46.DOFade)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				}},
				
				{typeof(UnityEngine.UI.Graphic), new List<MethodInfo>(){
				
				  new __GEN_DELEGATE212(DG.Tweening.ShortcutExtensions46.DOColor)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE213(DG.Tweening.ShortcutExtensions46.DOFade)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE245(DG.Tweening.ShortcutExtensions46.DOBlendableColor)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				}},
				
				{typeof(UnityEngine.UI.Image), new List<MethodInfo>(){
				
				  new __GEN_DELEGATE214(DG.Tweening.ShortcutExtensions46.DOColor)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE215(DG.Tweening.ShortcutExtensions46.DOFade)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE216(DG.Tweening.ShortcutExtensions46.DOFillAmount)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE217(DG.Tweening.ShortcutExtensions46.DOGradientColor)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE246(DG.Tweening.ShortcutExtensions46.DOBlendableColor)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				}},
				
				{typeof(UnityEngine.UI.LayoutElement), new List<MethodInfo>(){
				
				  new __GEN_DELEGATE218(DG.Tweening.ShortcutExtensions46.DOFlexibleSize)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE219(DG.Tweening.ShortcutExtensions46.DOMinSize)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE220(DG.Tweening.ShortcutExtensions46.DOPreferredSize)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				}},
				
				{typeof(UnityEngine.UI.Outline), new List<MethodInfo>(){
				
				  new __GEN_DELEGATE221(DG.Tweening.ShortcutExtensions46.DOColor)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE222(DG.Tweening.ShortcutExtensions46.DOFade)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE223(DG.Tweening.ShortcutExtensions46.DOScale)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				}},
				
				{typeof(UnityEngine.RectTransform), new List<MethodInfo>(){
				
				  new __GEN_DELEGATE224(DG.Tweening.ShortcutExtensions46.DOAnchorPos)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE225(DG.Tweening.ShortcutExtensions46.DOAnchorPosX)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE226(DG.Tweening.ShortcutExtensions46.DOAnchorPosY)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE227(DG.Tweening.ShortcutExtensions46.DOAnchorPos3D)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE228(DG.Tweening.ShortcutExtensions46.DOAnchorMax)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE229(DG.Tweening.ShortcutExtensions46.DOAnchorMin)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE230(DG.Tweening.ShortcutExtensions46.DOPivot)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE231(DG.Tweening.ShortcutExtensions46.DOPivotX)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE232(DG.Tweening.ShortcutExtensions46.DOPivotY)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE233(DG.Tweening.ShortcutExtensions46.DOSizeDelta)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE234(DG.Tweening.ShortcutExtensions46.DOPunchAnchorPos)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE235(DG.Tweening.ShortcutExtensions46.DOShakeAnchorPos)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE236(DG.Tweening.ShortcutExtensions46.DOShakeAnchorPos)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE237(DG.Tweening.ShortcutExtensions46.DOJumpAnchorPos)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				}},
				
				{typeof(UnityEngine.UI.ScrollRect), new List<MethodInfo>(){
				
				  new __GEN_DELEGATE238(DG.Tweening.ShortcutExtensions46.DONormalizedPos)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE239(DG.Tweening.ShortcutExtensions46.DOHorizontalNormalizedPos)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE240(DG.Tweening.ShortcutExtensions46.DOVerticalNormalizedPos)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				}},
				
				{typeof(UnityEngine.UI.Slider), new List<MethodInfo>(){
				
				  new __GEN_DELEGATE241(DG.Tweening.ShortcutExtensions46.DOValue)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				}},
				
				{typeof(UnityEngine.UI.Text), new List<MethodInfo>(){
				
				  new __GEN_DELEGATE242(DG.Tweening.ShortcutExtensions46.DOColor)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE243(DG.Tweening.ShortcutExtensions46.DOFade)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE244(DG.Tweening.ShortcutExtensions46.DOText)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE247(DG.Tweening.ShortcutExtensions46.DOBlendableColor)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				}},
				
				{typeof(UnityEngine.Audio.AudioMixer), new List<MethodInfo>(){
				
				  new __GEN_DELEGATE248(DG.Tweening.ShortcutExtensions50.DOSetFloat)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE249(DG.Tweening.ShortcutExtensions50.DOComplete)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE250(DG.Tweening.ShortcutExtensions50.DOKill)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE251(DG.Tweening.ShortcutExtensions50.DOFlip)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE252(DG.Tweening.ShortcutExtensions50.DOGoto)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE253(DG.Tweening.ShortcutExtensions50.DOPause)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE254(DG.Tweening.ShortcutExtensions50.DOPlay)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE255(DG.Tweening.ShortcutExtensions50.DOPlayBackwards)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE256(DG.Tweening.ShortcutExtensions50.DOPlayForward)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE257(DG.Tweening.ShortcutExtensions50.DORestart)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE258(DG.Tweening.ShortcutExtensions50.DORewind)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE259(DG.Tweening.ShortcutExtensions50.DOSmoothRewind)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE260(DG.Tweening.ShortcutExtensions50.DOTogglePause)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE277(DG.Tweening.ShortcutExtensions50.DOSetFloat)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE278(DG.Tweening.ShortcutExtensions50.DOComplete)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE279(DG.Tweening.ShortcutExtensions50.DOKill)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE280(DG.Tweening.ShortcutExtensions50.DOFlip)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE281(DG.Tweening.ShortcutExtensions50.DOGoto)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE282(DG.Tweening.ShortcutExtensions50.DOPause)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE283(DG.Tweening.ShortcutExtensions50.DOPlay)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE284(DG.Tweening.ShortcutExtensions50.DOPlayBackwards)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE285(DG.Tweening.ShortcutExtensions50.DOPlayForward)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE286(DG.Tweening.ShortcutExtensions50.DORestart)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE287(DG.Tweening.ShortcutExtensions50.DORewind)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE288(DG.Tweening.ShortcutExtensions50.DOSmoothRewind)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE289(DG.Tweening.ShortcutExtensions50.DOTogglePause)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				}},
				
				{typeof(UnityEngine.SceneManagement.Scene), new List<MethodInfo>(){
				
				  new __GEN_DELEGATE290(UnityEngine.PhysicsSceneExtensions.GetPhysicsScene)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				  new __GEN_DELEGATE291(UnityEngine.PhysicsSceneExtensions2D.GetPhysicsScene2D)
#if UNITY_WSA && !UNITY_EDITOR
                                      .GetMethodInfo(),
#else
                                      .Method,
#endif
				
				}},
				
			};
			
			genTryArrayGetPtr = StaticLuaCallbacks.__tryArrayGet;
            genTryArraySetPtr = StaticLuaCallbacks.__tryArraySet;
		}
	}
}
