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
    public class GameUtilWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(GameUtil);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 59, 6, 6);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "ReloadRegexPatterns", _m_ReloadRegexPatterns_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetEncryptKey", _m_SetEncryptKey_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CheckEncryptState", _m_CheckEncryptState_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CreatePrefab", _m_CreatePrefab_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CreatePrefabInActiveScene", _m_CreatePrefabInActiveScene_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CreatePrefabDontDestroyOnLoad", _m_CreatePrefabDontDestroyOnLoad_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CreatePrefabToParent", _m_CreatePrefabToParent_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CreatePrefabToParentAsync", _m_CreatePrefabToParentAsync_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "LoadPrefab", _m_LoadPrefab_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "LoadPrefabAsync", _m_LoadPrefabAsync_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "LoadResource", _m_LoadResource_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "LoadResourceByType", _m_LoadResourceByType_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "LoadBytes", _m_LoadBytes_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "LoadText", _m_LoadText_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "LoadDecryptBytes", _m_LoadDecryptBytes_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "LoadDecryptText", _m_LoadDecryptText_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "LoadDecryptTextAndTrim", _m_LoadDecryptTextAndTrim_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "EncryptBytes", _m_EncryptBytes_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "EncryptText", _m_EncryptText_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "EncryptTextAndTrim", _m_EncryptTextAndTrim_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DecryptBytes", _m_DecryptBytes_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DecryptText", _m_DecryptText_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "EncryptPersistentFile", _m_EncryptPersistentFile_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DecryptPersistentFile", _m_DecryptPersistentFile_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "LoadPersistentData", _m_LoadPersistentData_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SavePersistentData", _m_SavePersistentData_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DeletePersistentData", _m_DeletePersistentData_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "LoadSceneByName", _m_LoadSceneByName_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetPrettyJson", _m_GetPrettyJson_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetOSName", _m_GetOSName_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "LoadAtlasSprite", _m_LoadAtlasSprite_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetupCameraRenderTexture", _m_SetupCameraRenderTexture_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CreateRenderTexture", _m_CreateRenderTexture_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "LoadPrefabSprite", _m_LoadPrefabSprite_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "LoadPrefabTexture", _m_LoadPrefabTexture_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "LoadPrefabMaterial", _m_LoadPrefabMaterial_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "LoadPrefabAnimatorController", _m_LoadPrefabAnimatorController_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetupNormalCamera", _m_SetupNormalCamera_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "AddTimer", _m_AddTimer_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetTextLength", _m_GetTextLength_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "HasSpecialCharacters", _m_HasSpecialCharacters_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "RemoveSpecialCharacters", _m_RemoveSpecialCharacters_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "HasSensitiveWord", _m_HasSensitiveWord_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "RemoveSensitiveWord", _m_RemoveSensitiveWord_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetUpdatePath", _m_GetUpdatePath_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "RemoveCloneSuffix", _m_RemoveCloneSuffix_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "LoadSceneAdditiveAsync", _m_LoadSceneAdditiveAsync_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "LoadSceneAdditive", _m_LoadSceneAdditive_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "UnloadScene", _m_UnloadScene_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetActiveScene", _m_SetActiveScene_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetActiveSceneRoot", _m_GetActiveSceneRoot_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetCanvasCamera", _m_GetCanvasCamera_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetUIScreenPosition", _m_GetUIScreenPosition_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "IsDebugBuild", _m_IsDebugBuild_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "IsDebugBuildOrEditor", _m_IsDebugBuildOrEditor_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "PlayVideo", _m_PlayVideo_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "QuitGame", _m_QuitGame_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "UnloadGame", _m_UnloadGame_xlua_st_);
            
			
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "EncryptKey", _g_get_EncryptKey);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "EncryptKeyBytes", _g_get_EncryptKeyBytes);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "PersistantEncrypted", _g_get_PersistantEncrypted);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "StreamingEncrypted", _g_get_StreamingEncrypted);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "RegexNonWordPattern", _g_get_RegexNonWordPattern);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "RegexSpecialPattern", _g_get_RegexSpecialPattern);
            
			Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "EncryptKey", _s_set_EncryptKey);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "EncryptKeyBytes", _s_set_EncryptKeyBytes);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "PersistantEncrypted", _s_set_PersistantEncrypted);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "StreamingEncrypted", _s_set_StreamingEncrypted);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "RegexNonWordPattern", _s_set_RegexNonWordPattern);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "RegexSpecialPattern", _s_set_RegexSpecialPattern);
            
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "GameUtil does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReloadRegexPatterns_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    GameUtil.ReloadRegexPatterns(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetEncryptKey_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _key = LuaAPI.lua_tostring(L, 1);
                    
                    GameUtil.SetEncryptKey( _key );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CheckEncryptState_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    GameUtil.CheckEncryptState(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreatePrefab_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _path = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = GameUtil.CreatePrefab( _path );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreatePrefabInActiveScene_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _path = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = GameUtil.CreatePrefabInActiveScene( _path );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreatePrefabDontDestroyOnLoad_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _path = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = GameUtil.CreatePrefabDontDestroyOnLoad( _path );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreatePrefabToParent_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _path = LuaAPI.lua_tostring(L, 1);
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 2, typeof(UnityEngine.Object));
                    string _parentPath = LuaAPI.lua_tostring(L, 3);
                    
                        var gen_ret = GameUtil.CreatePrefabToParent( _path, _parent, _parentPath );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreatePrefabToParentAsync_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _path = LuaAPI.lua_tostring(L, 1);
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 2, typeof(UnityEngine.Object));
                    string _parentPath = LuaAPI.lua_tostring(L, 3);
                    GameUtil.OnLoadResource _callback = translator.GetDelegate<GameUtil.OnLoadResource>(L, 4);
                    
                    GameUtil.CreatePrefabToParentAsync( _path, _parent, _parentPath, _callback );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadPrefab_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _path = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = GameUtil.LoadPrefab( _path );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadPrefabAsync_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _path = LuaAPI.lua_tostring(L, 1);
                    GameUtil.OnLoadResource _callback = translator.GetDelegate<GameUtil.OnLoadResource>(L, 2);
                    
                    GameUtil.LoadPrefabAsync( _path, _callback );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadResource_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _path = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = GameUtil.LoadResource( _path );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadResourceByType_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _path = LuaAPI.lua_tostring(L, 1);
                    string _systemTypeName = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = GameUtil.LoadResourceByType( _path, _systemTypeName );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadBytes_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _path = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = GameUtil.LoadBytes( _path );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadText_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _path = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = GameUtil.LoadText( _path );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadDecryptBytes_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _path = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = GameUtil.LoadDecryptBytes( _path );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadDecryptText_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _path = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = GameUtil.LoadDecryptText( _path );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadDecryptTextAndTrim_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _path = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = GameUtil.LoadDecryptTextAndTrim( _path );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EncryptBytes_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    byte[] _bytes = LuaAPI.lua_tobytes(L, 1);
                    
                        var gen_ret = GameUtil.EncryptBytes( _bytes );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EncryptText_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _text = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = GameUtil.EncryptText( _text );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EncryptTextAndTrim_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _text = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = GameUtil.EncryptTextAndTrim( _text );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DecryptBytes_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    byte[] _bytes = LuaAPI.lua_tobytes(L, 1);
                    
                        var gen_ret = GameUtil.DecryptBytes( _bytes );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DecryptText_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _text = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = GameUtil.DecryptText( _text );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EncryptPersistentFile_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _path = LuaAPI.lua_tostring(L, 1);
                    
                    GameUtil.EncryptPersistentFile( _path );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DecryptPersistentFile_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _path = LuaAPI.lua_tostring(L, 1);
                    
                    GameUtil.DecryptPersistentFile( _path );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadPersistentData_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _path = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = GameUtil.LoadPersistentData( _path );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SavePersistentData_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _path = LuaAPI.lua_tostring(L, 1);
                    string _data = LuaAPI.lua_tostring(L, 2);
                    
                    GameUtil.SavePersistentData( _path, _data );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DeletePersistentData_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _path = LuaAPI.lua_tostring(L, 1);
                    
                    GameUtil.DeletePersistentData( _path );
                    
                    
                    
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
                    string _sceneName = LuaAPI.lua_tostring(L, 1);
                    
                    GameUtil.LoadSceneByName( _sceneName );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPrettyJson_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _json = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = GameUtil.GetPrettyJson( _json );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetOSName_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        var gen_ret = GameUtil.GetOSName(  );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadAtlasSprite_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _atlasPath = LuaAPI.lua_tostring(L, 1);
                    string _name = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = GameUtil.LoadAtlasSprite( _atlasPath, _name );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetupCameraRenderTexture_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _cameraPath = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = GameUtil.SetupCameraRenderTexture( _parent, _cameraPath );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateRenderTexture_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    int _width = LuaAPI.xlua_tointeger(L, 1);
                    int _height = LuaAPI.xlua_tointeger(L, 2);
                    int _depth = LuaAPI.xlua_tointeger(L, 3);
                    
                        var gen_ret = GameUtil.CreateRenderTexture( _width, _height, _depth );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadPrefabSprite_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _path = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = GameUtil.LoadPrefabSprite( _path );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadPrefabTexture_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _path = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = GameUtil.LoadPrefabTexture( _path );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadPrefabMaterial_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _path = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = GameUtil.LoadPrefabMaterial( _path );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadPrefabAnimatorController_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _path = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = GameUtil.LoadPrefabAnimatorController( _path );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetupNormalCamera_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                    GameUtil.SetupNormalCamera( _parent, _path );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddTimer_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    float _seconds = (float)LuaAPI.lua_tonumber(L, 3);
                    RealtimeTimer.OnComplete _callback = translator.GetDelegate<RealtimeTimer.OnComplete>(L, 4);
                    
                        var gen_ret = GameUtil.AddTimer( _parent, _path, _seconds, _callback );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTextLength_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _text = LuaAPI.lua_tostring(L, 1);
                    int _wordLength = LuaAPI.xlua_tointeger(L, 2);
                    
                        var gen_ret = GameUtil.GetTextLength( _text, _wordLength );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HasSpecialCharacters_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _text = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = GameUtil.HasSpecialCharacters( _text );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveSpecialCharacters_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _text = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = GameUtil.RemoveSpecialCharacters( _text );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HasSensitiveWord_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _text = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = GameUtil.HasSensitiveWord( _text );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveSensitiveWord_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _text = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = GameUtil.RemoveSensitiveWord( _text );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetUpdatePath_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _path = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = GameUtil.GetUpdatePath( _path );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveCloneSuffix_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.GameObject _gameObject = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    
                    GameUtil.RemoveCloneSuffix( _gameObject );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadSceneAdditiveAsync_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _name = LuaAPI.lua_tostring(L, 1);
                    GameUtil.OnLoadScene _onComplete = translator.GetDelegate<GameUtil.OnLoadScene>(L, 2);
                    
                    GameUtil.LoadSceneAdditiveAsync( _name, _onComplete );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadSceneAdditive_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _name = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = GameUtil.LoadSceneAdditive( _name );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UnloadScene_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _name = LuaAPI.lua_tostring(L, 1);
                    UnityEngine.Events.UnityAction _onComplete = translator.GetDelegate<UnityEngine.Events.UnityAction>(L, 2);
                    
                    GameUtil.UnloadScene( _name, _onComplete );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetActiveScene_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _name = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = GameUtil.SetActiveScene( _name );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetActiveSceneRoot_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    int _index = LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = GameUtil.GetActiveSceneRoot( _index );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetCanvasCamera_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = GameUtil.GetCanvasCamera( _parent, _path );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetUIScreenPosition_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = GameUtil.GetUIScreenPosition( _parent, _path );
                        translator.PushUnityEngineVector3(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsDebugBuild_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        var gen_ret = GameUtil.IsDebugBuild(  );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsDebugBuildOrEditor_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        var gen_ret = GameUtil.IsDebugBuildOrEditor(  );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PlayVideo_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _parent = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 2);
                    string _videoPath = LuaAPI.lua_tostring(L, 3);
                    UnityEngine.Events.UnityAction _onFinish = translator.GetDelegate<UnityEngine.Events.UnityAction>(L, 4);
                    
                    GameUtil.PlayVideo( _parent, _path, _videoPath, _onFinish );
                    
                    
                    
                    return 0;
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
                    
                    GameUtil.QuitGame(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UnloadGame_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    GameUtil.UnloadGame(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EncryptKey(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushstring(L, GameUtil.EncryptKey);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EncryptKeyBytes(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushstring(L, GameUtil.EncryptKeyBytes);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PersistantEncrypted(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, GameUtil.PersistantEncrypted);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_StreamingEncrypted(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, GameUtil.StreamingEncrypted);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RegexNonWordPattern(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushstring(L, GameUtil.RegexNonWordPattern);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RegexSpecialPattern(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushstring(L, GameUtil.RegexSpecialPattern);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_EncryptKey(RealStatePtr L)
        {
		    try {
                
			    GameUtil.EncryptKey = LuaAPI.lua_tostring(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_EncryptKeyBytes(RealStatePtr L)
        {
		    try {
                
			    GameUtil.EncryptKeyBytes = LuaAPI.lua_tobytes(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_PersistantEncrypted(RealStatePtr L)
        {
		    try {
                
			    GameUtil.PersistantEncrypted = LuaAPI.lua_toboolean(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_StreamingEncrypted(RealStatePtr L)
        {
		    try {
                
			    GameUtil.StreamingEncrypted = LuaAPI.lua_toboolean(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_RegexNonWordPattern(RealStatePtr L)
        {
		    try {
                
			    GameUtil.RegexNonWordPattern = LuaAPI.lua_tostring(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_RegexSpecialPattern(RealStatePtr L)
        {
		    try {
                
			    GameUtil.RegexSpecialPattern = LuaAPI.lua_tostring(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
