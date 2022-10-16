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
    public class JsonUtilWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(JsonUtil);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 14, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "ParseJsonObject", _m_ParseJsonObject_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ParseJsonArray", _m_ParseJsonArray_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ToJsonString", _m_ToJsonString_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ToString", _m_ToString_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetJsonObject", _m_GetJsonObject_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetJsonArray", _m_GetJsonArray_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetString", _m_GetString_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetInt", _m_GetInt_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetFloat", _m_GetFloat_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetDouble", _m_GetDouble_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetLong", _m_GetLong_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetBool", _m_GetBool_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "WriteJson", _m_WriteJson_xlua_st_);
            
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					var gen_ret = new JsonUtil();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to JsonUtil constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseJsonObject_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _json = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = JsonUtil.ParseJsonObject( _json );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseJsonArray_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _json = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = JsonUtil.ParseJsonArray( _json );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToJsonString_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<object>(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    object _obj = translator.GetObject(L, 1, typeof(object));
                    bool _prettyPrint = LuaAPI.lua_toboolean(L, 2);
                    
                        var gen_ret = JsonUtil.ToJsonString( _obj, _prettyPrint );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<object>(L, 1)) 
                {
                    object _obj = translator.GetObject(L, 1, typeof(object));
                    
                        var gen_ret = JsonUtil.ToJsonString( _obj );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to JsonUtil.ToJsonString!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToString_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<Newtonsoft.Json.Linq.JContainer>(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    Newtonsoft.Json.Linq.JContainer _json = (Newtonsoft.Json.Linq.JContainer)translator.GetObject(L, 1, typeof(Newtonsoft.Json.Linq.JContainer));
                    bool _prettyPrint = LuaAPI.lua_toboolean(L, 2);
                    
                        var gen_ret = JsonUtil.ToString( _json, _prettyPrint );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<Newtonsoft.Json.Linq.JContainer>(L, 1)) 
                {
                    Newtonsoft.Json.Linq.JContainer _json = (Newtonsoft.Json.Linq.JContainer)translator.GetObject(L, 1, typeof(Newtonsoft.Json.Linq.JContainer));
                    
                        var gen_ret = JsonUtil.ToString( _json );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to JsonUtil.ToString!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetJsonObject_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<Newtonsoft.Json.Linq.JObject>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    Newtonsoft.Json.Linq.JObject _json = (Newtonsoft.Json.Linq.JObject)translator.GetObject(L, 1, typeof(Newtonsoft.Json.Linq.JObject));
                    string _key = LuaAPI.lua_tostring(L, 2);
                    bool _byPath = LuaAPI.lua_toboolean(L, 3);
                    
                        var gen_ret = JsonUtil.GetJsonObject( _json, _key, _byPath );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<Newtonsoft.Json.Linq.JObject>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    Newtonsoft.Json.Linq.JObject _json = (Newtonsoft.Json.Linq.JObject)translator.GetObject(L, 1, typeof(Newtonsoft.Json.Linq.JObject));
                    string _key = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = JsonUtil.GetJsonObject( _json, _key );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to JsonUtil.GetJsonObject!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetJsonArray_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<Newtonsoft.Json.Linq.JObject>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    Newtonsoft.Json.Linq.JObject _json = (Newtonsoft.Json.Linq.JObject)translator.GetObject(L, 1, typeof(Newtonsoft.Json.Linq.JObject));
                    string _key = LuaAPI.lua_tostring(L, 2);
                    bool _byPath = LuaAPI.lua_toboolean(L, 3);
                    
                        var gen_ret = JsonUtil.GetJsonArray( _json, _key, _byPath );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<Newtonsoft.Json.Linq.JObject>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    Newtonsoft.Json.Linq.JObject _json = (Newtonsoft.Json.Linq.JObject)translator.GetObject(L, 1, typeof(Newtonsoft.Json.Linq.JObject));
                    string _key = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = JsonUtil.GetJsonArray( _json, _key );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to JsonUtil.GetJsonArray!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetString_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<Newtonsoft.Json.Linq.JToken>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)) 
                {
                    Newtonsoft.Json.Linq.JToken _json = (Newtonsoft.Json.Linq.JToken)translator.GetObject(L, 1, typeof(Newtonsoft.Json.Linq.JToken));
                    string _key = LuaAPI.lua_tostring(L, 2);
                    string _defaultValue = LuaAPI.lua_tostring(L, 3);
                    
                        var gen_ret = JsonUtil.GetString( _json, _key, _defaultValue );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<Newtonsoft.Json.Linq.JToken>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    Newtonsoft.Json.Linq.JToken _json = (Newtonsoft.Json.Linq.JToken)translator.GetObject(L, 1, typeof(Newtonsoft.Json.Linq.JToken));
                    string _key = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = JsonUtil.GetString( _json, _key );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<Newtonsoft.Json.Linq.JObject>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)) 
                {
                    Newtonsoft.Json.Linq.JObject _json = (Newtonsoft.Json.Linq.JObject)translator.GetObject(L, 1, typeof(Newtonsoft.Json.Linq.JObject));
                    string _key = LuaAPI.lua_tostring(L, 2);
                    string _defaultValue = LuaAPI.lua_tostring(L, 3);
                    
                        var gen_ret = JsonUtil.GetString( _json, _key, _defaultValue );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<Newtonsoft.Json.Linq.JObject>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    Newtonsoft.Json.Linq.JObject _json = (Newtonsoft.Json.Linq.JObject)translator.GetObject(L, 1, typeof(Newtonsoft.Json.Linq.JObject));
                    string _key = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = JsonUtil.GetString( _json, _key );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to JsonUtil.GetString!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetInt_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<Newtonsoft.Json.Linq.JToken>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    Newtonsoft.Json.Linq.JToken _json = (Newtonsoft.Json.Linq.JToken)translator.GetObject(L, 1, typeof(Newtonsoft.Json.Linq.JToken));
                    string _key = LuaAPI.lua_tostring(L, 2);
                    int _defaultValue = LuaAPI.xlua_tointeger(L, 3);
                    
                        var gen_ret = JsonUtil.GetInt( _json, _key, _defaultValue );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<Newtonsoft.Json.Linq.JToken>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    Newtonsoft.Json.Linq.JToken _json = (Newtonsoft.Json.Linq.JToken)translator.GetObject(L, 1, typeof(Newtonsoft.Json.Linq.JToken));
                    string _key = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = JsonUtil.GetInt( _json, _key );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<Newtonsoft.Json.Linq.JObject>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    Newtonsoft.Json.Linq.JObject _json = (Newtonsoft.Json.Linq.JObject)translator.GetObject(L, 1, typeof(Newtonsoft.Json.Linq.JObject));
                    string _key = LuaAPI.lua_tostring(L, 2);
                    int _defaultValue = LuaAPI.xlua_tointeger(L, 3);
                    
                        var gen_ret = JsonUtil.GetInt( _json, _key, _defaultValue );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<Newtonsoft.Json.Linq.JObject>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    Newtonsoft.Json.Linq.JObject _json = (Newtonsoft.Json.Linq.JObject)translator.GetObject(L, 1, typeof(Newtonsoft.Json.Linq.JObject));
                    string _key = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = JsonUtil.GetInt( _json, _key );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to JsonUtil.GetInt!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetFloat_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<Newtonsoft.Json.Linq.JToken>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    Newtonsoft.Json.Linq.JToken _json = (Newtonsoft.Json.Linq.JToken)translator.GetObject(L, 1, typeof(Newtonsoft.Json.Linq.JToken));
                    string _key = LuaAPI.lua_tostring(L, 2);
                    float _defaultValue = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        var gen_ret = JsonUtil.GetFloat( _json, _key, _defaultValue );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<Newtonsoft.Json.Linq.JToken>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    Newtonsoft.Json.Linq.JToken _json = (Newtonsoft.Json.Linq.JToken)translator.GetObject(L, 1, typeof(Newtonsoft.Json.Linq.JToken));
                    string _key = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = JsonUtil.GetFloat( _json, _key );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<Newtonsoft.Json.Linq.JObject>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    Newtonsoft.Json.Linq.JObject _json = (Newtonsoft.Json.Linq.JObject)translator.GetObject(L, 1, typeof(Newtonsoft.Json.Linq.JObject));
                    string _key = LuaAPI.lua_tostring(L, 2);
                    float _defaultValue = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        var gen_ret = JsonUtil.GetFloat( _json, _key, _defaultValue );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<Newtonsoft.Json.Linq.JObject>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    Newtonsoft.Json.Linq.JObject _json = (Newtonsoft.Json.Linq.JObject)translator.GetObject(L, 1, typeof(Newtonsoft.Json.Linq.JObject));
                    string _key = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = JsonUtil.GetFloat( _json, _key );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to JsonUtil.GetFloat!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetDouble_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<Newtonsoft.Json.Linq.JToken>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    Newtonsoft.Json.Linq.JToken _json = (Newtonsoft.Json.Linq.JToken)translator.GetObject(L, 1, typeof(Newtonsoft.Json.Linq.JToken));
                    string _key = LuaAPI.lua_tostring(L, 2);
                    double _defaultValue = LuaAPI.lua_tonumber(L, 3);
                    
                        var gen_ret = JsonUtil.GetDouble( _json, _key, _defaultValue );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<Newtonsoft.Json.Linq.JToken>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    Newtonsoft.Json.Linq.JToken _json = (Newtonsoft.Json.Linq.JToken)translator.GetObject(L, 1, typeof(Newtonsoft.Json.Linq.JToken));
                    string _key = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = JsonUtil.GetDouble( _json, _key );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<Newtonsoft.Json.Linq.JObject>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    Newtonsoft.Json.Linq.JObject _json = (Newtonsoft.Json.Linq.JObject)translator.GetObject(L, 1, typeof(Newtonsoft.Json.Linq.JObject));
                    string _key = LuaAPI.lua_tostring(L, 2);
                    double _defaultValue = LuaAPI.lua_tonumber(L, 3);
                    
                        var gen_ret = JsonUtil.GetDouble( _json, _key, _defaultValue );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<Newtonsoft.Json.Linq.JObject>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    Newtonsoft.Json.Linq.JObject _json = (Newtonsoft.Json.Linq.JObject)translator.GetObject(L, 1, typeof(Newtonsoft.Json.Linq.JObject));
                    string _key = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = JsonUtil.GetDouble( _json, _key );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to JsonUtil.GetDouble!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetLong_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<Newtonsoft.Json.Linq.JToken>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3) || LuaAPI.lua_isint64(L, 3))) 
                {
                    Newtonsoft.Json.Linq.JToken _json = (Newtonsoft.Json.Linq.JToken)translator.GetObject(L, 1, typeof(Newtonsoft.Json.Linq.JToken));
                    string _key = LuaAPI.lua_tostring(L, 2);
                    long _defaultValue = LuaAPI.lua_toint64(L, 3);
                    
                        var gen_ret = JsonUtil.GetLong( _json, _key, _defaultValue );
                        LuaAPI.lua_pushint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<Newtonsoft.Json.Linq.JToken>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    Newtonsoft.Json.Linq.JToken _json = (Newtonsoft.Json.Linq.JToken)translator.GetObject(L, 1, typeof(Newtonsoft.Json.Linq.JToken));
                    string _key = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = JsonUtil.GetLong( _json, _key );
                        LuaAPI.lua_pushint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<Newtonsoft.Json.Linq.JObject>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3) || LuaAPI.lua_isint64(L, 3))) 
                {
                    Newtonsoft.Json.Linq.JObject _json = (Newtonsoft.Json.Linq.JObject)translator.GetObject(L, 1, typeof(Newtonsoft.Json.Linq.JObject));
                    string _key = LuaAPI.lua_tostring(L, 2);
                    long _defaultValue = LuaAPI.lua_toint64(L, 3);
                    
                        var gen_ret = JsonUtil.GetLong( _json, _key, _defaultValue );
                        LuaAPI.lua_pushint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<Newtonsoft.Json.Linq.JObject>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    Newtonsoft.Json.Linq.JObject _json = (Newtonsoft.Json.Linq.JObject)translator.GetObject(L, 1, typeof(Newtonsoft.Json.Linq.JObject));
                    string _key = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = JsonUtil.GetLong( _json, _key );
                        LuaAPI.lua_pushint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to JsonUtil.GetLong!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBool_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<Newtonsoft.Json.Linq.JToken>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    Newtonsoft.Json.Linq.JToken _json = (Newtonsoft.Json.Linq.JToken)translator.GetObject(L, 1, typeof(Newtonsoft.Json.Linq.JToken));
                    string _key = LuaAPI.lua_tostring(L, 2);
                    bool _defaultValue = LuaAPI.lua_toboolean(L, 3);
                    
                        var gen_ret = JsonUtil.GetBool( _json, _key, _defaultValue );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<Newtonsoft.Json.Linq.JToken>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    Newtonsoft.Json.Linq.JToken _json = (Newtonsoft.Json.Linq.JToken)translator.GetObject(L, 1, typeof(Newtonsoft.Json.Linq.JToken));
                    string _key = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = JsonUtil.GetBool( _json, _key );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<Newtonsoft.Json.Linq.JObject>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    Newtonsoft.Json.Linq.JObject _json = (Newtonsoft.Json.Linq.JObject)translator.GetObject(L, 1, typeof(Newtonsoft.Json.Linq.JObject));
                    string _key = LuaAPI.lua_tostring(L, 2);
                    bool _defaultValue = LuaAPI.lua_toboolean(L, 3);
                    
                        var gen_ret = JsonUtil.GetBool( _json, _key, _defaultValue );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<Newtonsoft.Json.Linq.JObject>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    Newtonsoft.Json.Linq.JObject _json = (Newtonsoft.Json.Linq.JObject)translator.GetObject(L, 1, typeof(Newtonsoft.Json.Linq.JObject));
                    string _key = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = JsonUtil.GetBool( _json, _key );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to JsonUtil.GetBool!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WriteJson_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<LitJson.JsonData>(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    string _path = LuaAPI.lua_tostring(L, 1);
                    LitJson.JsonData _json = (LitJson.JsonData)translator.GetObject(L, 2, typeof(LitJson.JsonData));
                    bool _prettyPrint = LuaAPI.lua_toboolean(L, 3);
                    
                    JsonUtil.WriteJson( _path, _json, _prettyPrint );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<LitJson.JsonData>(L, 2)) 
                {
                    string _path = LuaAPI.lua_tostring(L, 1);
                    LitJson.JsonData _json = (LitJson.JsonData)translator.GetObject(L, 2, typeof(LitJson.JsonData));
                    
                    JsonUtil.WriteJson( _path, _json );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to JsonUtil.WriteJson!");
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
