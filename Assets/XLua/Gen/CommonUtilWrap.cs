#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    public class CommonUtilWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(CommonUtil);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 257, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "GetChild", _m_GetChild_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "HasChild", _m_HasChild_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetTransform", _m_GetTransform_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetGameObject", _m_GetGameObject_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetComponent", _m_GetComponent_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetChildAt", _m_GetChildAt_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetAssemblyQualifiedName", _m_GetAssemblyQualifiedName_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetTypeByName", _m_GetTypeByName_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetComponentInChildren", _m_GetComponentInChildren_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetComponentsInChildren", _m_GetComponentsInChildren_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "AddComponent", _m_AddComponent_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DestroyChild", _m_DestroyChild_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DestroyChildImmediate", _m_DestroyChildImmediate_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DestroyChildren", _m_DestroyChildren_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DestroyChildrenImmediate", _m_DestroyChildrenImmediate_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DestroyLimitChildren", _m_DestroyLimitChildren_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetRendererShadow", _m_SetRendererShadow_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ForceLayout", _m_ForceLayout_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "RepairLayout", _m_RepairLayout_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetParent", _m_SetParent_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetParentByPath", _m_SetParentByPath_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetAsLastSibling", _m_SetAsLastSibling_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetAsFirstSibling", _m_SetAsFirstSibling_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetSiblingIndex", _m_SetSiblingIndex_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetSiblingIndex", _m_GetSiblingIndex_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetActive", _m_SetActive_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ToggleActive", _m_ToggleActive_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetChildrenActive", _m_SetChildrenActive_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetGrayStyle", _m_SetGrayStyle_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetComponentEnabled", _m_SetComponentEnabled_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetChildrenComponentsEnabled", _m_SetChildrenComponentsEnabled_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetButtonEnabled", _m_SetButtonEnabled_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetImageEnabled", _m_SetImageEnabled_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetRawImageEnabled", _m_SetRawImageEnabled_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetTextEnabled", _m_SetTextEnabled_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetAnimatorEnabled", _m_SetAnimatorEnabled_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "AddButtonClick", _m_AddButtonClick_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "RemoveButtonClick", _m_RemoveButtonClick_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "AddButtonClickWithoutRemove", _m_AddButtonClickWithoutRemove_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "InvokeButtonClick", _m_InvokeButtonClick_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "AddToggleClick", _m_AddToggleClick_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetToggleValue", _m_SetToggleValue_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetToggleValue", _m_GetToggleValue_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetToggleGroupByPath", _m_SetToggleGroupByPath_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetToggleGroup", _m_SetToggleGroup_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetToggleGraphicByPath", _m_SetToggleGraphicByPath_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetToggleGraphic", _m_SetToggleGraphic_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "AddDropdownOptions", _m_AddDropdownOptions_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "AddDropdownOnChange", _m_AddDropdownOnChange_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetDropdownValue", _m_GetDropdownValue_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetDropdownInteractable", _m_SetDropdownInteractable_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "AddInputFieldOnChange", _m_AddInputFieldOnChange_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetText", _m_GetText_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetTextColor", _m_GetTextColor_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetText", _m_SetText_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetTextFont", _m_SetTextFont_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetTextFontSize", _m_SetTextFontSize_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetTextColor", _m_SetTextColor_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetTextAndColor", _m_SetTextAndColor_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetTextMesh", _m_SetTextMesh_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetTextMesh", _m_GetTextMesh_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetTextMeshColor", _m_SetTextMeshColor_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetTextMeshColor", _m_GetTextMeshColor_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetImage", _m_SetImage_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetImage", _m_GetImage_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetImageColor", _m_SetImageColor_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetImageAutoEnable", _m_SetImageAutoEnable_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetRawImage", _m_SetRawImage_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetRawImage", _m_GetRawImage_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetRawImageColor", _m_SetRawImageColor_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetRawImageAutoEnable", _m_SetRawImageAutoEnable_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetSprite", _m_SetSprite_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetSprite", _m_GetSprite_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetSpriteColor", _m_SetSpriteColor_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetSpriteColor", _m_GetSpriteColor_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "FitImageAspect", _m_FitImageAspect_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetImageFillAmount", _m_SetImageFillAmount_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetAudioClip", _m_SetAudioClip_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetBtnInteractable", _m_SetBtnInteractable_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ToggleBtnInteractable", _m_ToggleBtnInteractable_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetButtonTargetGraphic", _m_SetButtonTargetGraphic_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetScrollbarPosition", _m_SetScrollbarPosition_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetInputFieldText", _m_SetInputFieldText_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetInputFieldText", _m_GetInputFieldText_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetInputFieldContentType", _m_SetInputFieldContentType_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ToggleInputFieldPasswordType", _m_ToggleInputFieldPasswordType_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ForceRebuildLayoutImmediate", _m_ForceRebuildLayoutImmediate_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "IsActiveSelf", _m_IsActiveSelf_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetIgnoreLayout", _m_SetIgnoreLayout_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetLayoutPadding", _m_SetLayoutPadding_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ResetRectTransformByLayout", _m_ResetRectTransformByLayout_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ZeroTransform", _m_ZeroTransform_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ZeroRectTransform", _m_ZeroRectTransform_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ZeroRectTransformAnchorPivot", _m_ZeroRectTransformAnchorPivot_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "StretchRectTransform", _m_StretchRectTransform_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetRendererMateiral", _m_GetRendererMateiral_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetRendererMaterial", _m_SetRendererMaterial_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "PlayParticle", _m_PlayParticle_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "StopParticle", _m_StopParticle_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "StopAndClearParticle", _m_StopAndClearParticle_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetParticlePlay", _m_SetParticlePlay_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "PauseParticles", _m_PauseParticles_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetParticleStartColor", _m_SetParticleStartColor_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetCameraColor", _m_SetCameraColor_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "IsOverlapsViewport", _m_IsOverlapsViewport_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DOKill", _m_DOKill_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DOPlay", _m_DOPlay_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DOTweenAnimationPlay", _m_DOTweenAnimationPlay_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DOShake", _m_DOShake_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DOShakeAnchorPos", _m_DOShakeAnchorPos_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DOLocalRotate", _m_DOLocalRotate_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DOScale", _m_DOScale_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DOScaleX", _m_DOScaleX_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DOScaleY", _m_DOScaleY_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DOScaleZ", _m_DOScaleZ_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DOAnchorPos", _m_DOAnchorPos_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DOAnchorPosX", _m_DOAnchorPosX_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DOAnchorPosY", _m_DOAnchorPosY_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DOAnchorPos3D", _m_DOAnchorPos3D_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DOAnchorPosX3D", _m_DOAnchorPosX3D_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DOAnchorPosY3D", _m_DOAnchorPosY3D_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DOAnchorPosZ3D", _m_DOAnchorPosZ3D_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DOSizeDelta", _m_DOSizeDelta_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DOSizeDeltaX", _m_DOSizeDeltaX_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DOSizeDeltaY", _m_DOSizeDeltaY_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DOLocalMove", _m_DOLocalMove_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DOLocalMoveX", _m_DOLocalMoveX_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DOLocalMoveY", _m_DOLocalMoveY_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DOLocalMoveZ", _m_DOLocalMoveZ_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DOMove", _m_DOMove_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DOMoveX", _m_DOMoveX_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DOMoveY", _m_DOMoveY_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DOMoveZ", _m_DOMoveZ_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DORotate", _m_DORotate_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DOFillAmount", _m_DOFillAmount_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DOFillAmountFromTo", _m_DOFillAmountFromTo_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DoImageColor", _m_DoImageColor_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DoImageFade", _m_DoImageFade_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DoImageFadeFromTo", _m_DoImageFadeFromTo_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DOImageFillAmount", _m_DOImageFillAmount_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DOImageFillAmountFromTo", _m_DOImageFillAmountFromTo_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DOImageFillAmountBeyondClamp", _m_DOImageFillAmountBeyondClamp_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DoRawImageFade", _m_DoRawImageFade_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DoRawImageFadeFromTo", _m_DoRawImageFadeFromTo_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DoTextFade", _m_DoTextFade_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DoTextFadeFromTo", _m_DoTextFadeFromTo_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DoScrollRectPercentX", _m_DoScrollRectPercentX_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DoScrollRectPercentY", _m_DoScrollRectPercentY_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DoScrollRectPosX", _m_DoScrollRectPosX_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DoScrollRectPosY", _m_DoScrollRectPosY_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DOPath", _m_DOPath_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DoMaterialFloat", _m_DoMaterialFloat_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DOTargetTransform", _m_DOTargetTransform_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "NewGuid", _m_NewGuid_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetActiveSceneName", _m_GetActiveSceneName_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetActiveSceneIndex", _m_GetActiveSceneIndex_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "LoadSceneByIndex", _m_LoadSceneByIndex_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "LoadSceneByName", _m_LoadSceneByName_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetSkybox", _m_SetSkybox_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetAmbientLight", _m_SetAmbientLight_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetAmbientSkyColor", _m_SetAmbientSkyColor_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetAmbientEquatorColor", _m_SetAmbientEquatorColor_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetAmbientGroundColor", _m_SetAmbientGroundColor_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetFogColor", _m_SetFogColor_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetFogMod", _m_SetFogMod_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetFogDistance", _m_SetFogDistance_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "UpdateEnvironmentGI", _m_UpdateEnvironmentGI_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetChildrenRendererSortingOrder", _m_SetChildrenRendererSortingOrder_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetLayer", _m_SetLayer_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "LookUpCanvas", _m_LookUpCanvas_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetMD5FromFile", _m_GetMD5FromFile_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetMD5FromData", _m_GetMD5FromData_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetMD5FromStr", _m_GetMD5FromStr_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetSleepTimeout", _m_GetSleepTimeout_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetSleepTimeout", _m_SetSleepTimeout_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "XmlToJson", _m_XmlToJson_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "XmlToJsonData", _m_XmlToJsonData_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "QuitGame", _m_QuitGame_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetFileSize", _m_GetFileSize_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SubStringFromTo", _m_SubStringFromTo_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SubStringFromLastTo", _m_SubStringFromLastTo_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Contains", _m_Contains_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "FormatText", _m_FormatText_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "WriteToUTF8", _m_WriteToUTF8_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Trim", _m_Trim_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ReplaceStr", _m_ReplaceStr_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ReplaceNonBreakingSpaces", _m_ReplaceNonBreakingSpaces_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "EscapeRichText", _m_EscapeRichText_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetTextPrefferdSize", _m_GetTextPrefferdSize_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetTextPrefferdWidth", _m_SetTextPrefferdWidth_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetTextPrefferdHeight", _m_SetTextPrefferdHeight_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetTextPrefferdSize", _m_SetTextPrefferdSize_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "InvokeAction", _m_InvokeAction_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetMaterialProperty", _m_SetMaterialProperty_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetMeshMaterial", _m_SetMeshMaterial_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetMeshSharedMaterial", _m_GetMeshSharedMaterial_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetAnimationLength", _m_GetAnimationLength_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "PlayAnimatorFrom", _m_PlayAnimatorFrom_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetAnimatorTrigger", _m_SetAnimatorTrigger_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetAnimatorBool", _m_SetAnimatorBool_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetAnimatorInt", _m_SetAnimatorInt_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetAnimatorFloat", _m_SetAnimatorFloat_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetPlayableAsset", _m_SetPlayableAsset_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "PlayPlayableAsset", _m_PlayPlayableAsset_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetNowMilliseconds", _m_GetNowMilliseconds_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "IsNullOrEmpty", _m_IsNullOrEmpty_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "IsAndroid", _m_IsAndroid_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "IsIPhone", _m_IsIPhone_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "IsIOS", _m_IsIOS_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetPlatformName", _m_GetPlatformName_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetLocalData", _m_SetLocalData_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetLocalData", _m_GetLocalData_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetLocalDataInt", _m_SetLocalDataInt_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetLocalDataInt", _m_GetLocalDataInt_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetLocalDataFloat", _m_SetLocalDataFloat_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetLocalDataFloat", _m_GetLocalDataFloat_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetLocalDataBool", _m_SetLocalDataBool_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetLocalDataBool", _m_GetLocalDataBool_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetTimeStamp", _m_GetTimeStamp_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetDateStamp", _m_GetDateStamp_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetDateTimeStamp", _m_GetDateTimeStamp_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "WriteFile", _m_WriteFile_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ReadFile", _m_ReadFile_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetUIWidth", _m_GetUIWidth_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetUIHeight", _m_GetUIHeight_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetUISize", _m_GetUISize_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetUIWidth", _m_SetUIWidth_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetUIHeight", _m_SetUIHeight_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetUISize", _m_SetUISize_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetUISizeX", _m_SetUISizeX_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetUISizeY", _m_SetUISizeY_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetVideoRenderTexture", _m_SetVideoRenderTexture_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DOAnchoredX", _m_DOAnchoredX_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DOAnchoredY", _m_DOAnchoredY_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetPosition", _m_SetPosition_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetPositionXY", _m_SetPositionXY_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetAnchoredPositionX", _m_SetAnchoredPositionX_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetAnchoredPositionY", _m_SetAnchoredPositionY_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetAnchoredPosition", _m_SetAnchoredPosition_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetlLocalScale", _m_SetlLocalScale_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetEulerAngles", _m_SetEulerAngles_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetLocalEulerAngles", _m_SetLocalEulerAngles_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Approximately", _m_Approximately_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ColorHexToRGBA", _m_ColorHexToRGBA_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ColorRGBAToHex", _m_ColorRGBAToHex_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Vect2Distance", _m_Vect2Distance_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Vect3Distance", _m_Vect3Distance_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Join", _m_Join_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DOOrthoSize", _m_DOOrthoSize_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DOTweenTo", _m_DOTweenTo_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DOAnchorAndPivot", _m_DOAnchorAndPivot_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DOAnchor", _m_DOAnchor_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DOPivot", _m_DOPivot_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ClearRaycastTarget", _m_ClearRaycastTarget_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "PlayAnimator", _m_PlayAnimator_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetGridLayoutGroupChildAlignment", _m_SetGridLayoutGroupChildAlignment_xlua_st_);
            
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "CommonUtil does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetChild_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = CommonUtil.GetChild( _parent, _path );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HasChild_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = CommonUtil.HasChild( _parent, _path );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTransform_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = CommonUtil.GetTransform( _parent, _path );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGameObject_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = CommonUtil.GetGameObject( _parent, _path );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetComponent_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    string _type = LuaAPI.lua_tostring(L, 3);
                    
                        var gen_ret = CommonUtil.GetComponent( _parent, _path, _type );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetChildAt_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    int _index = LuaAPI.xlua_tointeger(L, 3);
                    
                        var gen_ret = CommonUtil.GetChildAt( _parent, _path, _index );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAssemblyQualifiedName_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 5&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 5) || LuaAPI.lua_type(L, 5) == LuaTypes.LUA_TSTRING)) 
                {
                    string _typeName = LuaAPI.lua_tostring(L, 1);
                    string _typeAssembly = LuaAPI.lua_tostring(L, 2);
                    string _version = LuaAPI.lua_tostring(L, 3);
                    string _culture = LuaAPI.lua_tostring(L, 4);
                    string _publicKeyToken = LuaAPI.lua_tostring(L, 5);
                    
                        var gen_ret = CommonUtil.GetAssemblyQualifiedName( _typeName, _typeAssembly, _version, _culture, _publicKeyToken );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TSTRING)) 
                {
                    string _typeName = LuaAPI.lua_tostring(L, 1);
                    string _typeAssembly = LuaAPI.lua_tostring(L, 2);
                    string _version = LuaAPI.lua_tostring(L, 3);
                    string _culture = LuaAPI.lua_tostring(L, 4);
                    
                        var gen_ret = CommonUtil.GetAssemblyQualifiedName( _typeName, _typeAssembly, _version, _culture );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)) 
                {
                    string _typeName = LuaAPI.lua_tostring(L, 1);
                    string _typeAssembly = LuaAPI.lua_tostring(L, 2);
                    string _version = LuaAPI.lua_tostring(L, 3);
                    
                        var gen_ret = CommonUtil.GetAssemblyQualifiedName( _typeName, _typeAssembly, _version );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string _typeName = LuaAPI.lua_tostring(L, 1);
                    string _typeAssembly = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = CommonUtil.GetAssemblyQualifiedName( _typeName, _typeAssembly );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to CommonUtil.GetAssemblyQualifiedName!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTypeByName_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _typeName = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = CommonUtil.GetTypeByName( _typeName );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetComponentInChildren_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    string _type = LuaAPI.lua_tostring(L, 3);
                    
                        var gen_ret = CommonUtil.GetComponentInChildren( _parent, _path, _type );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetComponentsInChildren_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    string _type = LuaAPI.lua_tostring(L, 3);
                    bool _includeInactive = LuaAPI.lua_toboolean(L, 4);
                    
                        var gen_ret = CommonUtil.GetComponentsInChildren( _parent, _path, _type, _includeInactive );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddComponent_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    string _type = LuaAPI.lua_tostring(L, 3);
                    bool _allowMultiple = LuaAPI.lua_toboolean(L, 4);
                    
                        var gen_ret = CommonUtil.AddComponent( _parent, _path, _type, _allowMultiple );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DestroyChild_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                    CommonUtil.DestroyChild( _parent, _path );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DestroyChildImmediate_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                    CommonUtil.DestroyChildImmediate( _parent, _path );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DestroyChildren_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                    CommonUtil.DestroyChildren( _parent, _path );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DestroyChildrenImmediate_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                    CommonUtil.DestroyChildrenImmediate( _parent, _path );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DestroyLimitChildren_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    int _limit = LuaAPI.xlua_tointeger(L, 3);
                    bool _updown = LuaAPI.lua_toboolean(L, 4);
                    
                    CommonUtil.DestroyLimitChildren( _parent, _path, _limit, _updown );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetRendererShadow_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    bool _cast = LuaAPI.lua_toboolean(L, 3);
                    bool _receive = LuaAPI.lua_toboolean(L, 4);
                    bool _withChildren = LuaAPI.lua_toboolean(L, 5);
                    
                    CommonUtil.SetRendererShadow( _parent, _path, _cast, _receive, _withChildren );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ForceLayout_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                    CommonUtil.ForceLayout( _parent, _path );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RepairLayout_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                    CommonUtil.RepairLayout( _parent, _path );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetParent_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _child = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 2, typeof(UnityEngine.Object));
                    bool _worldPosStays = LuaAPI.lua_toboolean(L, 3);
                    
                    CommonUtil.SetParent( _child, _parent, _worldPosStays );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetParentByPath_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _childRoot = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _childPath = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Object _parentRoot = (UnityEngine.Object)translator.GetObject(L, 3, typeof(UnityEngine.Object));
                    string _parentPath = LuaAPI.lua_tostring(L, 4);
                    bool _worldPosStays = LuaAPI.lua_toboolean(L, 5);
                    
                    CommonUtil.SetParentByPath( _childRoot, _childPath, _parentRoot, _parentPath, _worldPosStays );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetAsLastSibling_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                    CommonUtil.SetAsLastSibling( _parent, _path );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetAsFirstSibling_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                    CommonUtil.SetAsFirstSibling( _parent, _path );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetSiblingIndex_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    int _index = LuaAPI.xlua_tointeger(L, 3);
                    
                    CommonUtil.SetSiblingIndex( _parent, _path, _index );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSiblingIndex_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = CommonUtil.GetSiblingIndex( _parent, _path );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetActive_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    bool _active = LuaAPI.lua_toboolean(L, 3);
                    
                    CommonUtil.SetActive( _parent, _path, _active );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToggleActive_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                    CommonUtil.ToggleActive( _parent, _path );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetChildrenActive_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    bool _active = LuaAPI.lua_toboolean(L, 3);
                    
                    CommonUtil.SetChildrenActive( _parent, _path, _active );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetGrayStyle_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    bool _isGray = LuaAPI.lua_toboolean(L, 3);
                    bool _withChildren = LuaAPI.lua_toboolean(L, 4);
                    
                    CommonUtil.SetGrayStyle( _parent, _path, _isGray, _withChildren );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetComponentEnabled_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    string _type = LuaAPI.lua_tostring(L, 3);
                    bool _enabled = LuaAPI.lua_toboolean(L, 4);
                    
                    CommonUtil.SetComponentEnabled( _parent, _path, _type, _enabled );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetChildrenComponentsEnabled_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    string _type = LuaAPI.lua_tostring(L, 3);
                    bool _enabled = LuaAPI.lua_toboolean(L, 4);
                    
                    CommonUtil.SetChildrenComponentsEnabled( _parent, _path, _type, _enabled );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetButtonEnabled_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    bool _enabled = LuaAPI.lua_toboolean(L, 3);
                    
                    CommonUtil.SetButtonEnabled( _parent, _path, _enabled );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetImageEnabled_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    bool _enabled = LuaAPI.lua_toboolean(L, 3);
                    
                    CommonUtil.SetImageEnabled( _parent, _path, _enabled );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetRawImageEnabled_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    bool _enabled = LuaAPI.lua_toboolean(L, 3);
                    
                    CommonUtil.SetRawImageEnabled( _parent, _path, _enabled );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetTextEnabled_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    bool _enabled = LuaAPI.lua_toboolean(L, 3);
                    
                    CommonUtil.SetTextEnabled( _parent, _path, _enabled );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetAnimatorEnabled_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    bool _enabled = LuaAPI.lua_toboolean(L, 3);
                    
                    CommonUtil.SetAnimatorEnabled( _parent, _path, _enabled );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddButtonClick_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Events.UnityAction _action = translator.GetDelegate<UnityEngine.Events.UnityAction>(L, 3);
                    
                    CommonUtil.AddButtonClick( _parent, _path, _action );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveButtonClick_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                    CommonUtil.RemoveButtonClick( _parent, _path );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddButtonClickWithoutRemove_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Events.UnityAction _action = translator.GetDelegate<UnityEngine.Events.UnityAction>(L, 3);
                    
                    CommonUtil.AddButtonClickWithoutRemove( _parent, _path, _action );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InvokeButtonClick_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                    CommonUtil.InvokeButtonClick( _parent, _path );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddToggleClick_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    CommonUtil.OnToggleChange _onChange = translator.GetDelegate<CommonUtil.OnToggleChange>(L, 3);
                    
                    CommonUtil.AddToggleClick( _parent, _path, _onChange );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetToggleValue_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    bool _isOn = LuaAPI.lua_toboolean(L, 3);
                    
                    CommonUtil.SetToggleValue( _parent, _path, _isOn );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetToggleValue_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = CommonUtil.GetToggleValue( _parent, _path );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetToggleGroupByPath_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Object _groupParent = (UnityEngine.Object)translator.GetObject(L, 3, typeof(UnityEngine.Object));
                    string _groupPath = LuaAPI.lua_tostring(L, 4);
                    
                    CommonUtil.SetToggleGroupByPath( _parent, _path, _groupParent, _groupPath );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetToggleGroup_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Object _group = (UnityEngine.Object)translator.GetObject(L, 3, typeof(UnityEngine.Object));
                    
                    CommonUtil.SetToggleGroup( _parent, _path, _group );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetToggleGraphicByPath_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Object _graphicParent = (UnityEngine.Object)translator.GetObject(L, 3, typeof(UnityEngine.Object));
                    string _graphicPath = LuaAPI.lua_tostring(L, 4);
                    
                    CommonUtil.SetToggleGraphicByPath( _parent, _path, _graphicParent, _graphicPath );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetToggleGraphic_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Object _graphic = (UnityEngine.Object)translator.GetObject(L, 3, typeof(UnityEngine.Object));
                    
                    CommonUtil.SetToggleGraphic( _parent, _path, _graphic );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddDropdownOptions_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    string _options = LuaAPI.lua_tostring(L, 3);
                    bool _clear = LuaAPI.lua_toboolean(L, 4);
                    
                    CommonUtil.AddDropdownOptions( _parent, _path, _options, _clear );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddDropdownOnChange_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    CommonUtil.OnDropdownChange _onChange = translator.GetDelegate<CommonUtil.OnDropdownChange>(L, 3);
                    
                    CommonUtil.AddDropdownOnChange( _parent, _path, _onChange );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetDropdownValue_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = CommonUtil.GetDropdownValue( _parent, _path );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetDropdownInteractable_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    bool _interactable = LuaAPI.lua_toboolean(L, 3);
                    
                    CommonUtil.SetDropdownInteractable( _parent, _path, _interactable );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddInputFieldOnChange_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    CommonUtil.OnInputFieldChange _onChange = translator.GetDelegate<CommonUtil.OnInputFieldChange>(L, 3);
                    
                    CommonUtil.AddInputFieldOnChange( _parent, _path, _onChange );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetText_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = CommonUtil.GetText( _parent, _path );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTextColor_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = CommonUtil.GetTextColor( _parent, _path );
                        translator.PushUnityEngineColor(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetText_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    string _text = LuaAPI.lua_tostring(L, 3);
                    
                    CommonUtil.SetText( _parent, _path, _text );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetTextFont_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Font _font = (UnityEngine.Font)translator.GetObject(L, 3, typeof(UnityEngine.Font));
                    
                    CommonUtil.SetTextFont( _parent, _path, _font );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetTextFontSize_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    int _fontSize = LuaAPI.xlua_tointeger(L, 3);
                    
                    CommonUtil.SetTextFontSize( _parent, _path, _fontSize );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetTextColor_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Color _color;translator.Get(L, 3, out _color);
                    
                    CommonUtil.SetTextColor( _parent, _path, _color );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetTextAndColor_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    string _text = LuaAPI.lua_tostring(L, 3);
                    UnityEngine.Color _color;translator.Get(L, 4, out _color);
                    
                    CommonUtil.SetTextAndColor( _parent, _path, _text, _color );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetTextMesh_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    string _text = LuaAPI.lua_tostring(L, 3);
                    
                    CommonUtil.SetTextMesh( _parent, _path, _text );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTextMesh_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = CommonUtil.GetTextMesh( _parent, _path );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetTextMeshColor_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Color _color;translator.Get(L, 3, out _color);
                    
                    CommonUtil.SetTextMeshColor( _parent, _path, _color );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTextMeshColor_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = CommonUtil.GetTextMeshColor( _parent, _path );
                        translator.PushUnityEngineColor(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetImage_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Sprite _sprite = (UnityEngine.Sprite)translator.GetObject(L, 3, typeof(UnityEngine.Sprite));
                    
                    CommonUtil.SetImage( _parent, _path, _sprite );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetImage_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = CommonUtil.GetImage( _parent, _path );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetImageColor_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Color _color;translator.Get(L, 3, out _color);
                    
                    CommonUtil.SetImageColor( _parent, _path, _color );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetImageAutoEnable_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Sprite _sprite = (UnityEngine.Sprite)translator.GetObject(L, 3, typeof(UnityEngine.Sprite));
                    
                    CommonUtil.SetImageAutoEnable( _parent, _path, _sprite );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetRawImage_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Texture _texture = (UnityEngine.Texture)translator.GetObject(L, 3, typeof(UnityEngine.Texture));
                    
                    CommonUtil.SetRawImage( _parent, _path, _texture );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetRawImage_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = CommonUtil.GetRawImage( _parent, _path );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetRawImageColor_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Color _color;translator.Get(L, 3, out _color);
                    
                    CommonUtil.SetRawImageColor( _parent, _path, _color );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetRawImageAutoEnable_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Texture _texture = (UnityEngine.Texture)translator.GetObject(L, 3, typeof(UnityEngine.Texture));
                    
                    CommonUtil.SetRawImageAutoEnable( _parent, _path, _texture );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetSprite_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Sprite _sprite = (UnityEngine.Sprite)translator.GetObject(L, 3, typeof(UnityEngine.Sprite));
                    
                    CommonUtil.SetSprite( _parent, _path, _sprite );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSprite_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = CommonUtil.GetSprite( _parent, _path );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetSpriteColor_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Color _color;translator.Get(L, 3, out _color);
                    
                    CommonUtil.SetSpriteColor( _parent, _path, _color );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSpriteColor_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = CommonUtil.GetSpriteColor( _parent, _path );
                        translator.PushUnityEngineColor(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FitImageAspect_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                    CommonUtil.FitImageAspect( _parent, _path );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetImageFillAmount_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    float _fillAmount = (float)LuaAPI.lua_tonumber(L, 3);
                    
                    CommonUtil.SetImageFillAmount( _parent, _path, _fillAmount );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetAudioClip_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.AudioClip _clip = (UnityEngine.AudioClip)translator.GetObject(L, 3, typeof(UnityEngine.AudioClip));
                    
                    CommonUtil.SetAudioClip( _parent, _path, _clip );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetBtnInteractable_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    bool _interactable = LuaAPI.lua_toboolean(L, 3);
                    
                    CommonUtil.SetBtnInteractable( _parent, _path, _interactable );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToggleBtnInteractable_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                    CommonUtil.ToggleBtnInteractable( _parent, _path );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetButtonTargetGraphic_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Object _target = (UnityEngine.Object)translator.GetObject(L, 3, typeof(UnityEngine.Object));
                    string _targetPath = LuaAPI.lua_tostring(L, 4);
                    
                    CommonUtil.SetButtonTargetGraphic( _parent, _path, _target, _targetPath );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetScrollbarPosition_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    float _value = (float)LuaAPI.lua_tonumber(L, 3);
                    
                    CommonUtil.SetScrollbarPosition( _parent, _path, _value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetInputFieldText_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    string _text = LuaAPI.lua_tostring(L, 3);
                    
                    CommonUtil.SetInputFieldText( _parent, _path, _text );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetInputFieldText_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = CommonUtil.GetInputFieldText( _parent, _path );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetInputFieldContentType_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    string _type = LuaAPI.lua_tostring(L, 3);
                    
                    CommonUtil.SetInputFieldContentType( _parent, _path, _type );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToggleInputFieldPasswordType_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = CommonUtil.ToggleInputFieldPasswordType( _parent, _path );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ForceRebuildLayoutImmediate_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                    CommonUtil.ForceRebuildLayoutImmediate( _parent, _path );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsActiveSelf_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = CommonUtil.IsActiveSelf( _parent, _path );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetIgnoreLayout_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    bool _ignore = LuaAPI.lua_toboolean(L, 3);
                    
                    CommonUtil.SetIgnoreLayout( _parent, _path, _ignore );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetLayoutPadding_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    int _left = LuaAPI.xlua_tointeger(L, 3);
                    int _right = LuaAPI.xlua_tointeger(L, 4);
                    int _top = LuaAPI.xlua_tointeger(L, 5);
                    int _bottom = LuaAPI.xlua_tointeger(L, 6);
                    
                    CommonUtil.SetLayoutPadding( _parent, _path, _left, _right, _top, _bottom );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ResetRectTransformByLayout_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                    CommonUtil.ResetRectTransformByLayout( _parent, _path );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ZeroTransform_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                    CommonUtil.ZeroTransform( _parent, _path );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ZeroRectTransform_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                    CommonUtil.ZeroRectTransform( _parent, _path );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ZeroRectTransformAnchorPivot_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                    CommonUtil.ZeroRectTransformAnchorPivot( _parent, _path );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StretchRectTransform_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                    CommonUtil.StretchRectTransform( _parent, _path );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetRendererMateiral_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = CommonUtil.GetRendererMateiral( _parent, _path );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetRendererMaterial_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Material _material = (UnityEngine.Material)translator.GetObject(L, 3, typeof(UnityEngine.Material));
                    
                    CommonUtil.SetRendererMaterial( _parent, _path, _material );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PlayParticle_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    bool _withChildren = LuaAPI.lua_toboolean(L, 3);
                    
                    CommonUtil.PlayParticle( _parent, _path, _withChildren );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StopParticle_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    bool _withChildren = LuaAPI.lua_toboolean(L, 3);
                    
                    CommonUtil.StopParticle( _parent, _path, _withChildren );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StopAndClearParticle_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    bool _withChildren = LuaAPI.lua_toboolean(L, 3);
                    
                    CommonUtil.StopAndClearParticle( _parent, _path, _withChildren );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetParticlePlay_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    bool _isPlay = LuaAPI.lua_toboolean(L, 3);
                    bool _withChildren = LuaAPI.lua_toboolean(L, 4);
                    
                    CommonUtil.SetParticlePlay( _parent, _path, _isPlay, _withChildren );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PauseParticles_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    bool _isPause = LuaAPI.lua_toboolean(L, 3);
                    
                    CommonUtil.PauseParticles( _parent, _path, _isPause );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetParticleStartColor_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Color _startColor;translator.Get(L, 3, out _startColor);
                    
                    CommonUtil.SetParticleStartColor( _parent, _path, _startColor );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetCameraColor_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Color _color;translator.Get(L, 3, out _color);
                    
                    CommonUtil.SetCameraColor( _parent, _path, _color );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsOverlapsViewport_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.RectTransform _transform = (UnityEngine.RectTransform)translator.GetObject(L, 1, typeof(UnityEngine.RectTransform));
                    UnityEngine.RectTransform _viewport = (UnityEngine.RectTransform)translator.GetObject(L, 2, typeof(UnityEngine.RectTransform));
                    UnityEngine.Camera _uiCamera = (UnityEngine.Camera)translator.GetObject(L, 3, typeof(UnityEngine.Camera));
                    bool _isScreenOverlay = LuaAPI.lua_toboolean(L, 4);
                    
                        var gen_ret = CommonUtil.IsOverlapsViewport( _transform, _viewport, _uiCamera, _isScreenOverlay );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOKill_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                    CommonUtil.DOKill( _parent, _path );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOPlay_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                    CommonUtil.DOPlay( _parent, _path );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOTweenAnimationPlay_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                    CommonUtil.DOTweenAnimationPlay( _parent, _path );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOShake_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 3);
                    float _strength = (float)LuaAPI.lua_tonumber(L, 4);
                    int _vibrato = LuaAPI.xlua_tointeger(L, 5);
                    
                    CommonUtil.DOShake( _parent, _path, _duration, _strength, _vibrato );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOShakeAnchorPos_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 3);
                    float _strength = (float)LuaAPI.lua_tonumber(L, 4);
                    int _vibrato = LuaAPI.xlua_tointeger(L, 5);
                    
                    CommonUtil.DOShakeAnchorPos( _parent, _path, _duration, _strength, _vibrato );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOLocalRotate_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Vector3 _angles;translator.Get(L, 3, out _angles);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 4);
                    string _ease = LuaAPI.lua_tostring(L, 5);
                    string _rotateMode = LuaAPI.lua_tostring(L, 6);
                    
                    CommonUtil.DOLocalRotate( _parent, _path, _angles, _duration, _ease, _rotateMode );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOScale_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Vector3 _scale;translator.Get(L, 3, out _scale);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 4);
                    string _ease = LuaAPI.lua_tostring(L, 5);
                    
                    CommonUtil.DOScale( _parent, _path, _scale, _duration, _ease );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOScaleX_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    float _x = (float)LuaAPI.lua_tonumber(L, 3);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 4);
                    string _ease = LuaAPI.lua_tostring(L, 5);
                    
                    CommonUtil.DOScaleX( _parent, _path, _x, _duration, _ease );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOScaleY_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    float _y = (float)LuaAPI.lua_tonumber(L, 3);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 4);
                    string _ease = LuaAPI.lua_tostring(L, 5);
                    
                    CommonUtil.DOScaleY( _parent, _path, _y, _duration, _ease );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOScaleZ_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 4);
                    string _ease = LuaAPI.lua_tostring(L, 5);
                    
                    CommonUtil.DOScaleZ( _parent, _path, _z, _duration, _ease );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOAnchorPos_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Vector2 _position;translator.Get(L, 3, out _position);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 4);
                    string _ease = LuaAPI.lua_tostring(L, 5);
                    
                    CommonUtil.DOAnchorPos( _parent, _path, _position, _duration, _ease );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOAnchorPosX_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    float _x = (float)LuaAPI.lua_tonumber(L, 3);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 4);
                    string _ease = LuaAPI.lua_tostring(L, 5);
                    
                    CommonUtil.DOAnchorPosX( _parent, _path, _x, _duration, _ease );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOAnchorPosY_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    float _y = (float)LuaAPI.lua_tonumber(L, 3);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 4);
                    string _ease = LuaAPI.lua_tostring(L, 5);
                    
                    CommonUtil.DOAnchorPosY( _parent, _path, _y, _duration, _ease );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOAnchorPos3D_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Vector3 _position;translator.Get(L, 3, out _position);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 4);
                    string _ease = LuaAPI.lua_tostring(L, 5);
                    
                    CommonUtil.DOAnchorPos3D( _parent, _path, _position, _duration, _ease );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOAnchorPosX3D_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    float _x = (float)LuaAPI.lua_tonumber(L, 3);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 4);
                    string _ease = LuaAPI.lua_tostring(L, 5);
                    
                    CommonUtil.DOAnchorPosX3D( _parent, _path, _x, _duration, _ease );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOAnchorPosY3D_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    float _y = (float)LuaAPI.lua_tonumber(L, 3);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 4);
                    string _ease = LuaAPI.lua_tostring(L, 5);
                    
                    CommonUtil.DOAnchorPosY3D( _parent, _path, _y, _duration, _ease );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOAnchorPosZ3D_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 4);
                    string _ease = LuaAPI.lua_tostring(L, 5);
                    
                    CommonUtil.DOAnchorPosZ3D( _parent, _path, _z, _duration, _ease );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOSizeDelta_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Vector2 _size;translator.Get(L, 3, out _size);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 4);
                    string _ease = LuaAPI.lua_tostring(L, 5);
                    
                    CommonUtil.DOSizeDelta( _parent, _path, _size, _duration, _ease );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOSizeDeltaX_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    float _x = (float)LuaAPI.lua_tonumber(L, 3);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 4);
                    string _ease = LuaAPI.lua_tostring(L, 5);
                    
                    CommonUtil.DOSizeDeltaX( _parent, _path, _x, _duration, _ease );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOSizeDeltaY_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    float _y = (float)LuaAPI.lua_tonumber(L, 3);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 4);
                    string _ease = LuaAPI.lua_tostring(L, 5);
                    
                    CommonUtil.DOSizeDeltaY( _parent, _path, _y, _duration, _ease );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOLocalMove_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Vector3 _position;translator.Get(L, 3, out _position);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 4);
                    string _ease = LuaAPI.lua_tostring(L, 5);
                    
                    CommonUtil.DOLocalMove( _parent, _path, _position, _duration, _ease );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOLocalMoveX_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    float _x = (float)LuaAPI.lua_tonumber(L, 3);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 4);
                    string _ease = LuaAPI.lua_tostring(L, 5);
                    
                    CommonUtil.DOLocalMoveX( _parent, _path, _x, _duration, _ease );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOLocalMoveY_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    float _y = (float)LuaAPI.lua_tonumber(L, 3);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 4);
                    string _ease = LuaAPI.lua_tostring(L, 5);
                    
                    CommonUtil.DOLocalMoveY( _parent, _path, _y, _duration, _ease );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOLocalMoveZ_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 4);
                    string _ease = LuaAPI.lua_tostring(L, 5);
                    
                    CommonUtil.DOLocalMoveZ( _parent, _path, _z, _duration, _ease );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOMove_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Vector3 _position;translator.Get(L, 3, out _position);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 4);
                    string _ease = LuaAPI.lua_tostring(L, 5);
                    
                    CommonUtil.DOMove( _parent, _path, _position, _duration, _ease );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOMoveX_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    float _x = (float)LuaAPI.lua_tonumber(L, 3);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 4);
                    string _ease = LuaAPI.lua_tostring(L, 5);
                    
                    CommonUtil.DOMoveX( _parent, _path, _x, _duration, _ease );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOMoveY_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    float _y = (float)LuaAPI.lua_tonumber(L, 3);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 4);
                    string _ease = LuaAPI.lua_tostring(L, 5);
                    
                    CommonUtil.DOMoveY( _parent, _path, _y, _duration, _ease );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOMoveZ_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 4);
                    string _ease = LuaAPI.lua_tostring(L, 5);
                    
                    CommonUtil.DOMoveZ( _parent, _path, _z, _duration, _ease );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DORotate_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Vector3 _angle;translator.Get(L, 3, out _angle);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 4);
                    string _ease = LuaAPI.lua_tostring(L, 5);
                    System.Action<UnityEngine.Vector3> _callBack = translator.GetDelegate<System.Action<UnityEngine.Vector3>>(L, 6);
                    
                    CommonUtil.DORotate( _parent, _path, _angle, _duration, _ease, _callBack );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOFillAmount_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    float _to = (float)LuaAPI.lua_tonumber(L, 3);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 4);
                    string _ease = LuaAPI.lua_tostring(L, 5);
                    
                    CommonUtil.DOFillAmount( _parent, _path, _to, _duration, _ease );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOFillAmountFromTo_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    float _from = (float)LuaAPI.lua_tonumber(L, 3);
                    float _to = (float)LuaAPI.lua_tonumber(L, 4);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 5);
                    string _ease = LuaAPI.lua_tostring(L, 6);
                    
                    CommonUtil.DOFillAmountFromTo( _parent, _path, _from, _to, _duration, _ease );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DoImageColor_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Color _endColor;translator.Get(L, 3, out _endColor);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 4);
                    string _ease = LuaAPI.lua_tostring(L, 5);
                    
                    CommonUtil.DoImageColor( _parent, _path, _endColor, _duration, _ease );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DoImageFade_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    float _alpha = (float)LuaAPI.lua_tonumber(L, 3);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 4);
                    string _ease = LuaAPI.lua_tostring(L, 5);
                    
                    CommonUtil.DoImageFade( _parent, _path, _alpha, _duration, _ease );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DoImageFadeFromTo_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    float _fromAlpha = (float)LuaAPI.lua_tonumber(L, 3);
                    float _toAlpha = (float)LuaAPI.lua_tonumber(L, 4);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 5);
                    string _ease = LuaAPI.lua_tostring(L, 6);
                    
                    CommonUtil.DoImageFadeFromTo( _parent, _path, _fromAlpha, _toAlpha, _duration, _ease );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOImageFillAmount_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    float _value = (float)LuaAPI.lua_tonumber(L, 3);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 4);
                    string _ease = LuaAPI.lua_tostring(L, 5);
                    
                    CommonUtil.DOImageFillAmount( _parent, _path, _value, _duration, _ease );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOImageFillAmountFromTo_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    float _from = (float)LuaAPI.lua_tonumber(L, 3);
                    float _to = (float)LuaAPI.lua_tonumber(L, 4);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 5);
                    string _ease = LuaAPI.lua_tostring(L, 6);
                    
                    CommonUtil.DOImageFillAmountFromTo( _parent, _path, _from, _to, _duration, _ease );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOImageFillAmountBeyondClamp_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    float _from = (float)LuaAPI.lua_tonumber(L, 3);
                    float _to = (float)LuaAPI.lua_tonumber(L, 4);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 5);
                    string _easeType = LuaAPI.lua_tostring(L, 6);
                    UnityEngine.Events.UnityAction _onClamp = translator.GetDelegate<UnityEngine.Events.UnityAction>(L, 7);
                    
                    CommonUtil.DOImageFillAmountBeyondClamp( _parent, _path, _from, _to, _duration, _easeType, _onClamp );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DoRawImageFade_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    float _alpha = (float)LuaAPI.lua_tonumber(L, 3);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 4);
                    string _ease = LuaAPI.lua_tostring(L, 5);
                    
                    CommonUtil.DoRawImageFade( _parent, _path, _alpha, _duration, _ease );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DoRawImageFadeFromTo_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    float _fromAlpha = (float)LuaAPI.lua_tonumber(L, 3);
                    float _toAlpha = (float)LuaAPI.lua_tonumber(L, 4);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 5);
                    string _ease = LuaAPI.lua_tostring(L, 6);
                    
                    CommonUtil.DoRawImageFadeFromTo( _parent, _path, _fromAlpha, _toAlpha, _duration, _ease );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DoTextFade_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    float _alpha = (float)LuaAPI.lua_tonumber(L, 3);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 4);
                    string _ease = LuaAPI.lua_tostring(L, 5);
                    
                    CommonUtil.DoTextFade( _parent, _path, _alpha, _duration, _ease );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DoTextFadeFromTo_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    float _fromAlpha = (float)LuaAPI.lua_tonumber(L, 3);
                    float _toAlpha = (float)LuaAPI.lua_tonumber(L, 4);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 5);
                    string _ease = LuaAPI.lua_tostring(L, 6);
                    
                    CommonUtil.DoTextFadeFromTo( _parent, _path, _fromAlpha, _toAlpha, _duration, _ease );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DoScrollRectPercentX_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    int _index = LuaAPI.xlua_tointeger(L, 3);
                    int _totalCount = LuaAPI.xlua_tointeger(L, 4);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 5);
                    string _ease = LuaAPI.lua_tostring(L, 6);
                    
                    CommonUtil.DoScrollRectPercentX( _parent, _path, _index, _totalCount, _duration, _ease );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DoScrollRectPercentY_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    int _index = LuaAPI.xlua_tointeger(L, 3);
                    int _totalCount = LuaAPI.xlua_tointeger(L, 4);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 5);
                    string _ease = LuaAPI.lua_tostring(L, 6);
                    
                    CommonUtil.DoScrollRectPercentY( _parent, _path, _index, _totalCount, _duration, _ease );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DoScrollRectPosX_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    float _x = (float)LuaAPI.lua_tonumber(L, 3);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 4);
                    string _ease = LuaAPI.lua_tostring(L, 5);
                    
                    CommonUtil.DoScrollRectPosX( _parent, _path, _x, _duration, _ease );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DoScrollRectPosY_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    float _y = (float)LuaAPI.lua_tonumber(L, 3);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 4);
                    string _ease = LuaAPI.lua_tostring(L, 5);
                    
                    CommonUtil.DoScrollRectPosY( _parent, _path, _y, _duration, _ease );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOPath_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 3);
                    UnityEngine.Vector3[] _pos = translator.GetParams<UnityEngine.Vector3>(L, 4);
                    
                    CommonUtil.DOPath( _parent, _path, _duration, _pos );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DoMaterialFloat_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Material _material = (UnityEngine.Material)translator.GetObject(L, 1, typeof(UnityEngine.Material));
                    float _value = (float)LuaAPI.lua_tonumber(L, 2);
                    string _property = LuaAPI.lua_tostring(L, 3);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 4);
                    string _ease = LuaAPI.lua_tostring(L, 5);
                    
                    CommonUtil.DoMaterialFloat( _material, _value, _property, _duration, _ease );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOTargetTransform_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _obj = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    UnityEngine.Object _target = (UnityEngine.Object)translator.GetObject(L, 2, typeof(UnityEngine.Object));
                    bool _position = LuaAPI.lua_toboolean(L, 3);
                    bool _rotation = LuaAPI.lua_toboolean(L, 4);
                    bool _scale = LuaAPI.lua_toboolean(L, 5);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 6);
                    string _easeType = LuaAPI.lua_tostring(L, 7);
                    
                    CommonUtil.DOTargetTransform( _obj, _target, _position, _rotation, _scale, _duration, _easeType );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_NewGuid_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        var gen_ret = CommonUtil.NewGuid(  );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetActiveSceneName_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        var gen_ret = CommonUtil.GetActiveSceneName(  );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetActiveSceneIndex_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        var gen_ret = CommonUtil.GetActiveSceneIndex(  );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadSceneByIndex_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    int _index = LuaAPI.xlua_tointeger(L, 1);
                    
                    CommonUtil.LoadSceneByIndex( _index );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadSceneByName_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _name = LuaAPI.lua_tostring(L, 1);
                    
                    CommonUtil.LoadSceneByName( _name );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetSkybox_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Material _material = (UnityEngine.Material)translator.GetObject(L, 1, typeof(UnityEngine.Material));
                    float _ambientIntensity = (float)LuaAPI.lua_tonumber(L, 2);
                    
                    CommonUtil.SetSkybox( _material, _ambientIntensity );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetAmbientLight_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _colorText = LuaAPI.lua_tostring(L, 1);
                    
                    CommonUtil.SetAmbientLight( _colorText );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetAmbientSkyColor_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _colorText = LuaAPI.lua_tostring(L, 1);
                    
                    CommonUtil.SetAmbientSkyColor( _colorText );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetAmbientEquatorColor_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _colorText = LuaAPI.lua_tostring(L, 1);
                    
                    CommonUtil.SetAmbientEquatorColor( _colorText );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetAmbientGroundColor_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _colorText = LuaAPI.lua_tostring(L, 1);
                    
                    CommonUtil.SetAmbientGroundColor( _colorText );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetFogColor_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _colorText = LuaAPI.lua_tostring(L, 1);
                    
                    CommonUtil.SetFogColor( _colorText );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetFogMod_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _mode = LuaAPI.lua_tostring(L, 1);
                    
                    CommonUtil.SetFogMod( _mode );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetFogDistance_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    float _start = (float)LuaAPI.lua_tonumber(L, 1);
                    float _end = (float)LuaAPI.lua_tonumber(L, 2);
                    
                    CommonUtil.SetFogDistance( _start, _end );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateEnvironmentGI_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    CommonUtil.UpdateEnvironmentGI(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetChildrenRendererSortingOrder_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    string _layerName = LuaAPI.lua_tostring(L, 3);
                    int _sortingOrder = LuaAPI.xlua_tointeger(L, 4);
                    
                    CommonUtil.SetChildrenRendererSortingOrder( _parent, _path, _layerName, _sortingOrder );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetLayer_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    string _layerName = LuaAPI.lua_tostring(L, 3);
                    bool _withChildren = LuaAPI.lua_toboolean(L, 4);
                    
                    CommonUtil.SetLayer( _parent, _path, _layerName, _withChildren );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LookUpCanvas_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = CommonUtil.LookUpCanvas( _parent, _path );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetMD5FromFile_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _fileName = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = CommonUtil.GetMD5FromFile( _fileName );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetMD5FromData_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    byte[] _rawData = LuaAPI.lua_tobytes(L, 1);
                    
                        var gen_ret = CommonUtil.GetMD5FromData( _rawData );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetMD5FromStr_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _str = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = CommonUtil.GetMD5FromStr( _str );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSleepTimeout_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        var gen_ret = CommonUtil.GetSleepTimeout(  );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetSleepTimeout_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    int _timeout = LuaAPI.xlua_tointeger(L, 1);
                    
                    CommonUtil.SetSleepTimeout( _timeout );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_XmlToJson_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _xml = LuaAPI.lua_tostring(L, 1);
                    bool _prettyPrint = LuaAPI.lua_toboolean(L, 2);
                    
                        var gen_ret = CommonUtil.XmlToJson( _xml, _prettyPrint );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_XmlToJsonData_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _xml = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = CommonUtil.XmlToJsonData( _xml );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_QuitGame_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    CommonUtil.QuitGame(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetFileSize_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    double _size = LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = CommonUtil.GetFileSize( _size );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SubStringFromTo_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _str = LuaAPI.lua_tostring(L, 1);
                    string _from = LuaAPI.lua_tostring(L, 2);
                    string _to = LuaAPI.lua_tostring(L, 3);
                    
                        var gen_ret = CommonUtil.SubStringFromTo( _str, _from, _to );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SubStringFromLastTo_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _str = LuaAPI.lua_tostring(L, 1);
                    string _from = LuaAPI.lua_tostring(L, 2);
                    string _to = LuaAPI.lua_tostring(L, 3);
                    
                        var gen_ret = CommonUtil.SubStringFromLastTo( _str, _from, _to );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Contains_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _text = LuaAPI.lua_tostring(L, 1);
                    string _str = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = CommonUtil.Contains( _text, _str );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FormatText_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _text = LuaAPI.lua_tostring(L, 1);
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = CommonUtil.FormatText( _text, _args );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WriteToUTF8_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _path = LuaAPI.lua_tostring(L, 1);
                    string _target = LuaAPI.lua_tostring(L, 2);
                    
                    CommonUtil.WriteToUTF8( _path, _target );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Trim_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _text = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = CommonUtil.Trim( _text );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReplaceStr_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _str = LuaAPI.lua_tostring(L, 1);
                    string _oldStr = LuaAPI.lua_tostring(L, 2);
                    string _newStr = LuaAPI.lua_tostring(L, 3);
                    
                        var gen_ret = CommonUtil.ReplaceStr( _str, _oldStr, _newStr );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReplaceNonBreakingSpaces_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _str = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = CommonUtil.ReplaceNonBreakingSpaces( _str );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EscapeRichText_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _str = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = CommonUtil.EscapeRichText( _str );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTextPrefferdSize_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = CommonUtil.GetTextPrefferdSize( _parent, _path );
                        translator.PushUnityEngineVector2(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetTextPrefferdWidth_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                    CommonUtil.SetTextPrefferdWidth( _parent, _path );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetTextPrefferdHeight_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                    CommonUtil.SetTextPrefferdHeight( _parent, _path );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetTextPrefferdSize_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                    CommonUtil.SetTextPrefferdSize( _parent, _path );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InvokeAction_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    System.Action _action = translator.GetDelegate<System.Action>(L, 1);
                    
                    CommonUtil.InvokeAction( _action );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetMaterialProperty_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Material _material = (UnityEngine.Material)translator.GetObject(L, 1, typeof(UnityEngine.Material));
                    string _key = LuaAPI.lua_tostring(L, 2);
                    object _value = translator.GetObject(L, 3, typeof(object));
                    
                    CommonUtil.SetMaterialProperty( _material, _key, _value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetMeshMaterial_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Material _material = (UnityEngine.Material)translator.GetObject(L, 3, typeof(UnityEngine.Material));
                    
                    CommonUtil.SetMeshMaterial( _parent, _path, _material );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetMeshSharedMaterial_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = CommonUtil.GetMeshSharedMaterial( _parent, _path );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAnimationLength_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    int _index = LuaAPI.xlua_tointeger(L, 3);
                    
                        var gen_ret = CommonUtil.GetAnimationLength( _parent, _path, _index );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PlayAnimatorFrom_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    float _normalizedTime = (float)LuaAPI.lua_tonumber(L, 3);
                    
                    CommonUtil.PlayAnimatorFrom( _parent, _path, _normalizedTime );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetAnimatorTrigger_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    string _trigger = LuaAPI.lua_tostring(L, 3);
                    
                    CommonUtil.SetAnimatorTrigger( _parent, _path, _trigger );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetAnimatorBool_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    string _name = LuaAPI.lua_tostring(L, 3);
                    bool _value = LuaAPI.lua_toboolean(L, 4);
                    
                    CommonUtil.SetAnimatorBool( _parent, _path, _name, _value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetAnimatorInt_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    string _name = LuaAPI.lua_tostring(L, 3);
                    int _value = LuaAPI.xlua_tointeger(L, 4);
                    
                    CommonUtil.SetAnimatorInt( _parent, _path, _name, _value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetAnimatorFloat_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    string _name = LuaAPI.lua_tostring(L, 3);
                    float _value = (float)LuaAPI.lua_tonumber(L, 4);
                    
                    CommonUtil.SetAnimatorFloat( _parent, _path, _name, _value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetPlayableAsset_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Playables.PlayableAsset _asset = (UnityEngine.Playables.PlayableAsset)translator.GetObject(L, 3, typeof(UnityEngine.Playables.PlayableAsset));
                    
                    CommonUtil.SetPlayableAsset( _parent, _path, _asset );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PlayPlayableAsset_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Playables.PlayableAsset _asset = (UnityEngine.Playables.PlayableAsset)translator.GetObject(L, 3, typeof(UnityEngine.Playables.PlayableAsset));
                    
                    CommonUtil.PlayPlayableAsset( _parent, _path, _asset );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNowMilliseconds_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        var gen_ret = CommonUtil.GetNowMilliseconds(  );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsNullOrEmpty_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _str = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = CommonUtil.IsNullOrEmpty( _str );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsAndroid_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        var gen_ret = CommonUtil.IsAndroid(  );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsIPhone_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        var gen_ret = CommonUtil.IsIPhone(  );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsIOS_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        var gen_ret = CommonUtil.IsIOS(  );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPlatformName_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        var gen_ret = CommonUtil.GetPlatformName(  );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetLocalData_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _key = LuaAPI.lua_tostring(L, 1);
                    string _data = LuaAPI.lua_tostring(L, 2);
                    
                    CommonUtil.SetLocalData( _key, _data );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetLocalData_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _key = LuaAPI.lua_tostring(L, 1);
                    string _defaultValue = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = CommonUtil.GetLocalData( _key, _defaultValue );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetLocalDataInt_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _key = LuaAPI.lua_tostring(L, 1);
                    int _data = LuaAPI.xlua_tointeger(L, 2);
                    
                    CommonUtil.SetLocalDataInt( _key, _data );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetLocalDataInt_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _key = LuaAPI.lua_tostring(L, 1);
                    int _defaultValue = LuaAPI.xlua_tointeger(L, 2);
                    
                        var gen_ret = CommonUtil.GetLocalDataInt( _key, _defaultValue );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetLocalDataFloat_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _key = LuaAPI.lua_tostring(L, 1);
                    float _data = (float)LuaAPI.lua_tonumber(L, 2);
                    
                    CommonUtil.SetLocalDataFloat( _key, _data );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetLocalDataFloat_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _key = LuaAPI.lua_tostring(L, 1);
                    float _defaultValue = (float)LuaAPI.lua_tonumber(L, 2);
                    
                        var gen_ret = CommonUtil.GetLocalDataFloat( _key, _defaultValue );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetLocalDataBool_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _key = LuaAPI.lua_tostring(L, 1);
                    bool _data = LuaAPI.lua_toboolean(L, 2);
                    
                    CommonUtil.SetLocalDataBool( _key, _data );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetLocalDataBool_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _key = LuaAPI.lua_tostring(L, 1);
                    bool _defaultValue = LuaAPI.lua_toboolean(L, 2);
                    
                        var gen_ret = CommonUtil.GetLocalDataBool( _key, _defaultValue );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTimeStamp_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        var gen_ret = CommonUtil.GetTimeStamp(  );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetDateStamp_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        var gen_ret = CommonUtil.GetDateStamp(  );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetDateTimeStamp_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        var gen_ret = CommonUtil.GetDateTimeStamp(  );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WriteFile_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _path = LuaAPI.lua_tostring(L, 1);
                    string _content = LuaAPI.lua_tostring(L, 2);
                    bool _append = LuaAPI.lua_toboolean(L, 3);
                    
                    CommonUtil.WriteFile( _path, _content, _append );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReadFile_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _path = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = CommonUtil.ReadFile( _path );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetUIWidth_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = CommonUtil.GetUIWidth( _parent, _path );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetUIHeight_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = CommonUtil.GetUIHeight( _parent, _path );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetUISize_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = CommonUtil.GetUISize( _parent, _path );
                        translator.PushUnityEngineVector2(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetUIWidth_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    float _width = (float)LuaAPI.lua_tonumber(L, 3);
                    
                    CommonUtil.SetUIWidth( _parent, _path, _width );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetUIHeight_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    float _height = (float)LuaAPI.lua_tonumber(L, 3);
                    
                    CommonUtil.SetUIHeight( _parent, _path, _height );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetUISize_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    float _x = (float)LuaAPI.lua_tonumber(L, 3);
                    float _y = (float)LuaAPI.lua_tonumber(L, 4);
                    
                    CommonUtil.SetUISize( _parent, _path, _x, _y );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetUISizeX_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    float _x = (float)LuaAPI.lua_tonumber(L, 3);
                    
                    CommonUtil.SetUISizeX( _parent, _path, _x );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetUISizeY_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    float _y = (float)LuaAPI.lua_tonumber(L, 3);
                    
                    CommonUtil.SetUISizeY( _parent, _path, _y );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetVideoRenderTexture_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.RenderTexture _texture = (UnityEngine.RenderTexture)translator.GetObject(L, 3, typeof(UnityEngine.RenderTexture));
                    
                    CommonUtil.SetVideoRenderTexture( _parent, _path, _texture );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOAnchoredX_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    float _x = (float)LuaAPI.lua_tonumber(L, 3);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 4);
                    string _ease = LuaAPI.lua_tostring(L, 5);
                    
                    CommonUtil.DOAnchoredX( _parent, _path, _x, _duration, _ease );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOAnchoredY_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    float _y = (float)LuaAPI.lua_tonumber(L, 3);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 4);
                    string _ease = LuaAPI.lua_tostring(L, 5);
                    
                    CommonUtil.DOAnchoredY( _parent, _path, _y, _duration, _ease );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetPosition_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Vector3 _position;translator.Get(L, 3, out _position);
                    
                    CommonUtil.SetPosition( _parent, _path, _position );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetPositionXY_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    float _x = (float)LuaAPI.lua_tonumber(L, 3);
                    float _y = (float)LuaAPI.lua_tonumber(L, 4);
                    
                    CommonUtil.SetPositionXY( _parent, _path, _x, _y );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetAnchoredPositionX_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    float _x = (float)LuaAPI.lua_tonumber(L, 3);
                    
                    CommonUtil.SetAnchoredPositionX( _parent, _path, _x );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetAnchoredPositionY_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    float _y = (float)LuaAPI.lua_tonumber(L, 3);
                    
                    CommonUtil.SetAnchoredPositionY( _parent, _path, _y );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetAnchoredPosition_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Vector2 _pos;translator.Get(L, 3, out _pos);
                    
                    CommonUtil.SetAnchoredPosition( _parent, _path, _pos );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetlLocalScale_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Vector3 _scale;translator.Get(L, 3, out _scale);
                    
                    CommonUtil.SetlLocalScale( _parent, _path, _scale );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetEulerAngles_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Vector3 _angles;translator.Get(L, 3, out _angles);
                    
                    CommonUtil.SetEulerAngles( _parent, _path, _angles );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetLocalEulerAngles_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Vector3 _angles;translator.Get(L, 3, out _angles);
                    
                    CommonUtil.SetLocalEulerAngles( _parent, _path, _angles );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Approximately_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    float _a = (float)LuaAPI.lua_tonumber(L, 1);
                    float _b = (float)LuaAPI.lua_tonumber(L, 2);
                    float _maxDelta = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        var gen_ret = CommonUtil.Approximately( _a, _b, _maxDelta );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ColorHexToRGBA_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _hex = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = CommonUtil.ColorHexToRGBA( _hex );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ColorRGBAToHex_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    float _r = (float)LuaAPI.lua_tonumber(L, 1);
                    float _g = (float)LuaAPI.lua_tonumber(L, 2);
                    float _b = (float)LuaAPI.lua_tonumber(L, 3);
                    float _a = (float)LuaAPI.lua_tonumber(L, 4);
                    
                        var gen_ret = CommonUtil.ColorRGBAToHex( _r, _g, _b, _a );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Vect2Distance_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Vector2 _a;translator.Get(L, 1, out _a);
                    UnityEngine.Vector2 _b;translator.Get(L, 2, out _b);
                    
                        var gen_ret = CommonUtil.Vect2Distance( _a, _b );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Vect3Distance_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Vector3 _a;translator.Get(L, 1, out _a);
                    UnityEngine.Vector3 _b;translator.Get(L, 2, out _b);
                    
                        var gen_ret = CommonUtil.Vect3Distance( _a, _b );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Join_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    System.Collections.IEnumerable _list = (System.Collections.IEnumerable)translator.GetObject(L, 1, typeof(System.Collections.IEnumerable));
                    string _seperator = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = CommonUtil.Join( _list, _seperator );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOOrthoSize_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    float _size = (float)LuaAPI.lua_tonumber(L, 3);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 4);
                    string _ease = LuaAPI.lua_tostring(L, 5);
                    
                    CommonUtil.DOOrthoSize( _parent, _path, _size, _duration, _ease );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOTweenTo_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    float _num = (float)LuaAPI.lua_tonumber(L, 1);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 2);
                    string _ease = LuaAPI.lua_tostring(L, 3);
                    System.Action<float> _callBack = translator.GetDelegate<System.Action<float>>(L, 4);
                    
                    CommonUtil.DOTweenTo( _num, _duration, _ease, _callBack );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOAnchorAndPivot_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Vector2 _anchorMin;translator.Get(L, 3, out _anchorMin);
                    UnityEngine.Vector2 _anchorMax;translator.Get(L, 4, out _anchorMax);
                    UnityEngine.Vector2 _pivot;translator.Get(L, 5, out _pivot);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 6);
                    string _ease = LuaAPI.lua_tostring(L, 7);
                    
                    CommonUtil.DOAnchorAndPivot( _parent, _path, _anchorMin, _anchorMax, _pivot, _duration, _ease );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOAnchor_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Vector2 _anchorMin;translator.Get(L, 3, out _anchorMin);
                    UnityEngine.Vector2 _anchorMax;translator.Get(L, 4, out _anchorMax);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 5);
                    string _ease = LuaAPI.lua_tostring(L, 6);
                    
                    CommonUtil.DOAnchor( _parent, _path, _anchorMin, _anchorMax, _duration, _ease );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DOPivot_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Vector2 _pivot;translator.Get(L, 3, out _pivot);
                    float _duration = (float)LuaAPI.lua_tonumber(L, 4);
                    string _ease = LuaAPI.lua_tostring(L, 5);
                    
                    CommonUtil.DOPivot( _parent, _path, _pivot, _duration, _ease );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ClearRaycastTarget_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                    CommonUtil.ClearRaycastTarget( _parent, _path );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PlayAnimator_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    string _name = LuaAPI.lua_tostring(L, 3);
                    
                    CommonUtil.PlayAnimator( _parent, _path, _name );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetGridLayoutGroupChildAlignment_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    string _childAlignment = LuaAPI.lua_tostring(L, 3);
                    
                    CommonUtil.SetGridLayoutGroupChildAlignment( _parent, _path, _childAlignment );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
