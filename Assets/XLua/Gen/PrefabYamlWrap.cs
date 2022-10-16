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
    public class PrefabYamlWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(PrefabYaml);
			Utils.BeginObjectRegister(type, L, translator, 0, 5, 3, 3);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetPath", _m_GetPath);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetGameObject", _m_GetGameObject);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetTransform", _m_GetTransform);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "FindParentTransform", _m_FindParentTransform);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetNodesByType", _m_GetNodesByType);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "version", _g_get_version);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "tag", _g_get_tag);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "nodes", _g_get_nodes);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "version", _s_set_version);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "tag", _s_set_tag);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "nodes", _s_set_nodes);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 2, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "Parse", _m_Parse_xlua_st_);
            
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					var gen_ret = new PrefabYaml();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to PrefabYaml constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPath(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PrefabYaml gen_to_be_invoked = (PrefabYaml)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _fileID = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetPath( _fileID );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGameObject(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PrefabYaml gen_to_be_invoked = (PrefabYaml)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.Collections.Generic.List<PrefabYaml.Node>>(L, 3)) 
                {
                    string _fileID = LuaAPI.lua_tostring(L, 2);
                    System.Collections.Generic.List<PrefabYaml.Node> _gameObjects = (System.Collections.Generic.List<PrefabYaml.Node>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<PrefabYaml.Node>));
                    
                        var gen_ret = gen_to_be_invoked.GetGameObject( _fileID, _gameObjects );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string _fileID = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetGameObject( _fileID );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to PrefabYaml.GetGameObject!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTransform(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PrefabYaml gen_to_be_invoked = (PrefabYaml)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.Collections.Generic.List<PrefabYaml.Node>>(L, 3)&& translator.Assignable<System.Collections.Generic.List<PrefabYaml.Node>>(L, 4)) 
                {
                    string _fileID = LuaAPI.lua_tostring(L, 2);
                    System.Collections.Generic.List<PrefabYaml.Node> _transforms = (System.Collections.Generic.List<PrefabYaml.Node>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<PrefabYaml.Node>));
                    System.Collections.Generic.List<PrefabYaml.Node> _gameObjects = (System.Collections.Generic.List<PrefabYaml.Node>)translator.GetObject(L, 4, typeof(System.Collections.Generic.List<PrefabYaml.Node>));
                    
                        var gen_ret = gen_to_be_invoked.GetTransform( _fileID, _transforms, _gameObjects );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.Collections.Generic.List<PrefabYaml.Node>>(L, 3)) 
                {
                    string _fileID = LuaAPI.lua_tostring(L, 2);
                    System.Collections.Generic.List<PrefabYaml.Node> _transforms = (System.Collections.Generic.List<PrefabYaml.Node>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<PrefabYaml.Node>));
                    
                        var gen_ret = gen_to_be_invoked.GetTransform( _fileID, _transforms );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string _fileID = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetTransform( _fileID );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to PrefabYaml.GetTransform!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FindParentTransform(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PrefabYaml gen_to_be_invoked = (PrefabYaml)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.Collections.Generic.List<PrefabYaml.Node>>(L, 3)) 
                {
                    string _fileID = LuaAPI.lua_tostring(L, 2);
                    System.Collections.Generic.List<PrefabYaml.Node> _transformNodes = (System.Collections.Generic.List<PrefabYaml.Node>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<PrefabYaml.Node>));
                    
                        var gen_ret = gen_to_be_invoked.FindParentTransform( _fileID, _transformNodes );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string _fileID = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.FindParentTransform( _fileID );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to PrefabYaml.FindParentTransform!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNodesByType(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PrefabYaml gen_to_be_invoked = (PrefabYaml)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string[] _types = translator.GetParams<string>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetNodesByType( _types );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Parse_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _filePath = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = PrefabYaml.Parse( _filePath );
                        translator.Push(L, gen_ret);
                    
                    
                    
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
			
                PrefabYaml gen_to_be_invoked = (PrefabYaml)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.version);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_tag(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PrefabYaml gen_to_be_invoked = (PrefabYaml)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.tag);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_nodes(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PrefabYaml gen_to_be_invoked = (PrefabYaml)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.nodes);
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
			
                PrefabYaml gen_to_be_invoked = (PrefabYaml)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.version = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_tag(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PrefabYaml gen_to_be_invoked = (PrefabYaml)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.tag = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_nodes(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PrefabYaml gen_to_be_invoked = (PrefabYaml)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.nodes = (System.Collections.Generic.Dictionary<string, PrefabYaml.Node>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<string, PrefabYaml.Node>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
