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
    public class ResPathesWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(ResPathes);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 2, 5, 2);
			
			
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "SPRITE_INDEX_PATH", ResPathes.SPRITE_INDEX_PATH);
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "ASSETS_PATH", _g_get_ASSETS_PATH);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "PREFAB_FOLDER_PATH", _g_get_PREFAB_FOLDER_PATH);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "RESOURCE_PATH", _g_get_RESOURCE_PATH);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "ASSETS_FOLDER", _g_get_ASSETS_FOLDER);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "PREFAB_FOLDER", _g_get_PREFAB_FOLDER);
            
			Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "ASSETS_FOLDER", _s_set_ASSETS_FOLDER);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "PREFAB_FOLDER", _s_set_PREFAB_FOLDER);
            
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					var gen_ret = new ResPathes();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to ResPathes constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ASSETS_PATH(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushstring(L, ResPathes.ASSETS_PATH);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PREFAB_FOLDER_PATH(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushstring(L, ResPathes.PREFAB_FOLDER_PATH);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RESOURCE_PATH(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushstring(L, ResPathes.RESOURCE_PATH);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ASSETS_FOLDER(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushstring(L, ResPathes.ASSETS_FOLDER);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PREFAB_FOLDER(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushstring(L, ResPathes.PREFAB_FOLDER);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ASSETS_FOLDER(RealStatePtr L)
        {
		    try {
                
			    ResPathes.ASSETS_FOLDER = LuaAPI.lua_tostring(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_PREFAB_FOLDER(RealStatePtr L)
        {
		    try {
                
			    ResPathes.PREFAB_FOLDER = LuaAPI.lua_tostring(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
