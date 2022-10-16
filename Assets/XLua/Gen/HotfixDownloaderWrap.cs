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
    public class HotfixDownloaderWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(HotfixDownloader);
			Utils.BeginObjectRegister(type, L, translator, 0, 3, 8, 8);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Init", _m_Init);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "StartDownload", _m_StartDownload);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Abort", _m_Abort);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "maxDownloadThread", _g_get_maxDownloadThread);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "retryCount", _g_get_retryCount);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "validateMD5", _g_get_validateMD5);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "streamFragmentSize", _g_get_streamFragmentSize);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "downloadToTemp", _g_get_downloadToTemp);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "completeOperation", _g_get_completeOperation);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onProgress", _g_get_onProgress);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onFinished", _g_get_onFinished);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "maxDownloadThread", _s_set_maxDownloadThread);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "retryCount", _s_set_retryCount);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "validateMD5", _s_set_validateMD5);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "streamFragmentSize", _s_set_streamFragmentSize);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "downloadToTemp", _s_set_downloadToTemp);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "completeOperation", _s_set_completeOperation);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onProgress", _s_set_onProgress);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onFinished", _s_set_onFinished);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 4, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "CreateInstance", _m_CreateInstance_xlua_st_);
            
			
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "OPERATION_NONE", HotfixDownloader.OPERATION_NONE);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "OPERATION_UNLOAD_AND_REENTER", HotfixDownloader.OPERATION_UNLOAD_AND_REENTER);
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					var gen_ret = new HotfixDownloader();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to HotfixDownloader constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateInstance_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    
                        var gen_ret = HotfixDownloader.CreateInstance(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Init(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                HotfixDownloader gen_to_be_invoked = (HotfixDownloader)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _downloadListJson = LuaAPI.lua_tostring(L, 2);
                    
                    gen_to_be_invoked.Init( _downloadListJson );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StartDownload(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                HotfixDownloader gen_to_be_invoked = (HotfixDownloader)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.StartDownload(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Abort(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                HotfixDownloader gen_to_be_invoked = (HotfixDownloader)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Abort(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_maxDownloadThread(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                HotfixDownloader gen_to_be_invoked = (HotfixDownloader)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.maxDownloadThread);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_retryCount(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                HotfixDownloader gen_to_be_invoked = (HotfixDownloader)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.retryCount);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_validateMD5(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                HotfixDownloader gen_to_be_invoked = (HotfixDownloader)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.validateMD5);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_streamFragmentSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                HotfixDownloader gen_to_be_invoked = (HotfixDownloader)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.streamFragmentSize);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_downloadToTemp(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                HotfixDownloader gen_to_be_invoked = (HotfixDownloader)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.downloadToTemp);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_completeOperation(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                HotfixDownloader gen_to_be_invoked = (HotfixDownloader)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.completeOperation);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onProgress(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                HotfixDownloader gen_to_be_invoked = (HotfixDownloader)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onProgress);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onFinished(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                HotfixDownloader gen_to_be_invoked = (HotfixDownloader)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onFinished);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_maxDownloadThread(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                HotfixDownloader gen_to_be_invoked = (HotfixDownloader)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.maxDownloadThread = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_retryCount(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                HotfixDownloader gen_to_be_invoked = (HotfixDownloader)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.retryCount = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_validateMD5(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                HotfixDownloader gen_to_be_invoked = (HotfixDownloader)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.validateMD5 = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_streamFragmentSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                HotfixDownloader gen_to_be_invoked = (HotfixDownloader)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.streamFragmentSize = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_downloadToTemp(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                HotfixDownloader gen_to_be_invoked = (HotfixDownloader)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.downloadToTemp = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_completeOperation(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                HotfixDownloader gen_to_be_invoked = (HotfixDownloader)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.completeOperation = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onProgress(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                HotfixDownloader gen_to_be_invoked = (HotfixDownloader)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onProgress = translator.GetDelegate<HotfixDownloader.OnProgress>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onFinished(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                HotfixDownloader gen_to_be_invoked = (HotfixDownloader)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onFinished = translator.GetDelegate<HotfixDownloader.OnFinished>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
