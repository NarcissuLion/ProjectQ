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
    public class ResourceConfigWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(ResourceConfig);
			Utils.BeginObjectRegister(type, L, translator, 0, 3, 3, 3);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "IsCommon", _m_IsCommon);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetCacheGroup", _m_GetCacheGroup);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetCacheGroupLimit", _m_GetCacheGroupLimit);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "common", _g_get_common);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "cacheGroup", _g_get_cacheGroup);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "cachePool", _g_get_cachePool);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "common", _s_set_common);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "cacheGroup", _s_set_cacheGroup);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "cachePool", _s_set_cachePool);
            
			
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
					
					var gen_ret = new ResourceConfig();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to ResourceConfig constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsCommon(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ResourceConfig gen_to_be_invoked = (ResourceConfig)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _bundleName = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.IsCommon( _bundleName );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetCacheGroup(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ResourceConfig gen_to_be_invoked = (ResourceConfig)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _assetPath = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetCacheGroup( _assetPath );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetCacheGroupLimit(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ResourceConfig gen_to_be_invoked = (ResourceConfig)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _groupName = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetCacheGroupLimit( _groupName );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_common(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ResourceConfig gen_to_be_invoked = (ResourceConfig)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.common);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_cacheGroup(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ResourceConfig gen_to_be_invoked = (ResourceConfig)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.cacheGroup);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_cachePool(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ResourceConfig gen_to_be_invoked = (ResourceConfig)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.cachePool);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_common(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ResourceConfig gen_to_be_invoked = (ResourceConfig)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.common = (System.Collections.Generic.List<string>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<string>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_cacheGroup(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ResourceConfig gen_to_be_invoked = (ResourceConfig)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.cacheGroup = (System.Collections.Generic.Dictionary<string, int>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<string, int>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_cachePool(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ResourceConfig gen_to_be_invoked = (ResourceConfig)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.cachePool = (System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
