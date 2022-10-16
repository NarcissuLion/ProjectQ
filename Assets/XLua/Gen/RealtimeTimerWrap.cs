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
    public class RealtimeTimerWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(RealtimeTimer);
			Utils.BeginObjectRegister(type, L, translator, 0, 2, 10, 10);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "StartTiming", _m_StartTiming);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "StopTiming", _m_StopTiming);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "onComplete", _g_get_onComplete);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onTick", _g_get_onTick);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onUpdate", _g_get_onUpdate);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "key", _g_get_key);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "tickInterval", _g_get_tickInterval);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "useFixedUpdate", _g_get_useFixedUpdate);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "fromSeconds", _g_get_fromSeconds);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "toSeconds", _g_get_toSeconds);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "autoStart", _g_get_autoStart);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "offset", _g_get_offset);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "onComplete", _s_set_onComplete);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onTick", _s_set_onTick);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onUpdate", _s_set_onUpdate);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "key", _s_set_key);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "tickInterval", _s_set_tickInterval);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "useFixedUpdate", _s_set_useFixedUpdate);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "fromSeconds", _s_set_fromSeconds);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "toSeconds", _s_set_toSeconds);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "autoStart", _s_set_autoStart);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "offset", _s_set_offset);
            
			
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
					
					var gen_ret = new RealtimeTimer();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to RealtimeTimer constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StartTiming(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                RealtimeTimer gen_to_be_invoked = (RealtimeTimer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    double _fromSeconds = LuaAPI.lua_tonumber(L, 2);
                    double _toSeconds = LuaAPI.lua_tonumber(L, 3);
                    
                    gen_to_be_invoked.StartTiming( _fromSeconds, _toSeconds );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StopTiming(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                RealtimeTimer gen_to_be_invoked = (RealtimeTimer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.StopTiming(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onComplete(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RealtimeTimer gen_to_be_invoked = (RealtimeTimer)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onComplete);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onTick(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RealtimeTimer gen_to_be_invoked = (RealtimeTimer)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onTick);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onUpdate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RealtimeTimer gen_to_be_invoked = (RealtimeTimer)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onUpdate);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_key(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RealtimeTimer gen_to_be_invoked = (RealtimeTimer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.key);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_tickInterval(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RealtimeTimer gen_to_be_invoked = (RealtimeTimer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.tickInterval);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_useFixedUpdate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RealtimeTimer gen_to_be_invoked = (RealtimeTimer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.useFixedUpdate);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_fromSeconds(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RealtimeTimer gen_to_be_invoked = (RealtimeTimer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.fromSeconds);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_toSeconds(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RealtimeTimer gen_to_be_invoked = (RealtimeTimer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.toSeconds);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_autoStart(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RealtimeTimer gen_to_be_invoked = (RealtimeTimer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.autoStart);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_offset(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RealtimeTimer gen_to_be_invoked = (RealtimeTimer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.offset);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onComplete(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RealtimeTimer gen_to_be_invoked = (RealtimeTimer)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onComplete = translator.GetDelegate<RealtimeTimer.OnComplete>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onTick(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RealtimeTimer gen_to_be_invoked = (RealtimeTimer)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onTick = translator.GetDelegate<RealtimeTimer.OnTick>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onUpdate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RealtimeTimer gen_to_be_invoked = (RealtimeTimer)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onUpdate = translator.GetDelegate<RealtimeTimer.OnUpdate>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_key(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RealtimeTimer gen_to_be_invoked = (RealtimeTimer)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.key = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_tickInterval(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RealtimeTimer gen_to_be_invoked = (RealtimeTimer)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.tickInterval = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_useFixedUpdate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RealtimeTimer gen_to_be_invoked = (RealtimeTimer)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.useFixedUpdate = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_fromSeconds(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RealtimeTimer gen_to_be_invoked = (RealtimeTimer)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.fromSeconds = LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_toSeconds(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RealtimeTimer gen_to_be_invoked = (RealtimeTimer)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.toSeconds = LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_autoStart(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RealtimeTimer gen_to_be_invoked = (RealtimeTimer)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.autoStart = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_offset(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                RealtimeTimer gen_to_be_invoked = (RealtimeTimer)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.offset = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
