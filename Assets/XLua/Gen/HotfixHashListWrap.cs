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
    public class HotfixHashListWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(HotfixHashList);
			Utils.BeginObjectRegister(type, L, translator, 0, 7, 3, 3);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddHash", _m_AddHash);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetHash", _m_GetHash);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddOrReplaceHash", _m_AddOrReplaceHash);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RemoveHash", _m_RemoveHash);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Contains", _m_Contains);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddSingleBundle", _m_AddSingleBundle);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "IsSingleBundle", _m_IsSingleBundle);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "version", _g_get_version);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "singleBundle", _g_get_singleBundle);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "hash", _g_get_hash);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "version", _s_set_version);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "singleBundle", _s_set_singleBundle);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "hash", _s_set_hash);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					var gen_ret = new HotfixHashList();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to HotfixHashList constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddHash(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                HotfixHashList gen_to_be_invoked = (HotfixHashList)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _bundleName = LuaAPI.lua_tostring(L, 2);
                    string _hash = LuaAPI.lua_tostring(L, 3);
                    
                    gen_to_be_invoked.AddHash( _bundleName, _hash );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetHash(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                HotfixHashList gen_to_be_invoked = (HotfixHashList)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _bundleName = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetHash( _bundleName );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddOrReplaceHash(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                HotfixHashList gen_to_be_invoked = (HotfixHashList)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _bundleName = LuaAPI.lua_tostring(L, 2);
                    string _hash = LuaAPI.lua_tostring(L, 3);
                    
                    gen_to_be_invoked.AddOrReplaceHash( _bundleName, _hash );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveHash(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                HotfixHashList gen_to_be_invoked = (HotfixHashList)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _bundleName = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.RemoveHash( _bundleName );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Contains(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                HotfixHashList gen_to_be_invoked = (HotfixHashList)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _bundleName = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.Contains( _bundleName );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddSingleBundle(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                HotfixHashList gen_to_be_invoked = (HotfixHashList)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _assetDirPath = LuaAPI.lua_tostring(L, 2);
                    
                    gen_to_be_invoked.AddSingleBundle( _assetDirPath );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsSingleBundle(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                HotfixHashList gen_to_be_invoked = (HotfixHashList)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _assetDirPath = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.IsSingleBundle( _assetDirPath );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_version(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                HotfixHashList gen_to_be_invoked = (HotfixHashList)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.version);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_singleBundle(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                HotfixHashList gen_to_be_invoked = (HotfixHashList)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.singleBundle);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_hash(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                HotfixHashList gen_to_be_invoked = (HotfixHashList)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.hash);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_version(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                HotfixHashList gen_to_be_invoked = (HotfixHashList)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.version = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_singleBundle(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                HotfixHashList gen_to_be_invoked = (HotfixHashList)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.singleBundle = (System.Collections.Generic.List<string>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<string>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_hash(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                HotfixHashList gen_to_be_invoked = (HotfixHashList)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.hash = (System.Collections.Generic.Dictionary<string, string>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<string, string>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
