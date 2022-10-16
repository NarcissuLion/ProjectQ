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
    public class ResourceCachePoolWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(ResourceCachePool);
			Utils.BeginObjectRegister(type, L, translator, 0, 5, 2, 2);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "init", _m_init);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnLoadResource", _m_OnLoadResource);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetCache", _m_GetCache);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "IsCached", _m_IsCached);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Clear", _m_Clear);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "resourceConfig", _g_get_resourceConfig);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "cacheDict", _g_get_cacheDict);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "resourceConfig", _s_set_resourceConfig);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "cacheDict", _s_set_cacheDict);
            
			
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
					
					var gen_ret = new ResourceCachePool();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to ResourceCachePool constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_init(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ResourceCachePool gen_to_be_invoked = (ResourceCachePool)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    ResourceConfig _resourceConfig = (ResourceConfig)translator.GetObject(L, 2, typeof(ResourceConfig));
                    
                    gen_to_be_invoked.init( _resourceConfig );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnLoadResource(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ResourceCachePool gen_to_be_invoked = (ResourceCachePool)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Object _res = (UnityEngine.Object)translator.GetObject(L, 2, typeof(UnityEngine.Object));
                    string _path = LuaAPI.lua_tostring(L, 3);
                    string _group = LuaAPI.lua_tostring(L, 4);
                    string _bundleName = LuaAPI.lua_tostring(L, 5);
                    
                    gen_to_be_invoked.OnLoadResource( _res, _path, _group, _bundleName );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetCache(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ResourceCachePool gen_to_be_invoked = (ResourceCachePool)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _path = LuaAPI.lua_tostring(L, 2);
                    string _group = LuaAPI.lua_tostring(L, 3);
                    
                        var gen_ret = gen_to_be_invoked.GetCache( _path, _group );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsCached(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ResourceCachePool gen_to_be_invoked = (ResourceCachePool)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _path = LuaAPI.lua_tostring(L, 2);
                    string _group = LuaAPI.lua_tostring(L, 3);
                    
                        var gen_ret = gen_to_be_invoked.IsCached( _path, _group );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Clear(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ResourceCachePool gen_to_be_invoked = (ResourceCachePool)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Clear(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_resourceConfig(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ResourceCachePool gen_to_be_invoked = (ResourceCachePool)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.resourceConfig);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_cacheDict(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ResourceCachePool gen_to_be_invoked = (ResourceCachePool)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.cacheDict);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_resourceConfig(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ResourceCachePool gen_to_be_invoked = (ResourceCachePool)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.resourceConfig = (ResourceConfig)translator.GetObject(L, 2, typeof(ResourceConfig));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_cacheDict(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ResourceCachePool gen_to_be_invoked = (ResourceCachePool)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.cacheDict = (System.Collections.Generic.Dictionary<string, OrderMap<string, ResourceCachePool.Cache>>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<string, OrderMap<string, ResourceCachePool.Cache>>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
