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
    public class CoroutineHelperWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(CoroutineHelper);
			Utils.BeginObjectRegister(type, L, translator, 0, 7, 0, 0);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Stop", _m_Stop);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "StopAll", _m_StopAll);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ExcuteTask", _m_ExcuteTask);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "WaitForEndOfFrame", _m_WaitForEndOfFrame);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "WaitForSeconds", _m_WaitForSeconds);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "QueueWaitForSeconds", _m_QueueWaitForSeconds);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "QueueWaitForEndOfFrame", _m_QueueWaitForEndOfFrame);
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 2, 1, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "GetInstance", _m_GetInstance_xlua_st_);
            
			
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "Instance", _g_get_Instance);
            
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					CoroutineHelper gen_ret = new CoroutineHelper();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to CoroutineHelper constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetInstance_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _obj = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    
                        CoroutineHelper gen_ret = CoroutineHelper.GetInstance( _obj );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Stop(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                CoroutineHelper gen_to_be_invoked = (CoroutineHelper)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Coroutine _coroutine = (UnityEngine.Coroutine)translator.GetObject(L, 2, typeof(UnityEngine.Coroutine));
                    
                    gen_to_be_invoked.Stop( _coroutine );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StopAll(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                CoroutineHelper gen_to_be_invoked = (CoroutineHelper)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.StopAll(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ExcuteTask(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                CoroutineHelper gen_to_be_invoked = (CoroutineHelper)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    CoroutineHelper.Task _task = translator.GetDelegate<CoroutineHelper.Task>(L, 2);
                    
                        UnityEngine.Coroutine gen_ret = gen_to_be_invoked.ExcuteTask( _task );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WaitForEndOfFrame(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                CoroutineHelper gen_to_be_invoked = (CoroutineHelper)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    CoroutineHelper.Task _task = translator.GetDelegate<CoroutineHelper.Task>(L, 2);
                    
                        UnityEngine.Coroutine gen_ret = gen_to_be_invoked.WaitForEndOfFrame( _task );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WaitForSeconds(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                CoroutineHelper gen_to_be_invoked = (CoroutineHelper)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    float _delay = (float)LuaAPI.lua_tonumber(L, 2);
                    CoroutineHelper.Task _task = translator.GetDelegate<CoroutineHelper.Task>(L, 3);
                    
                        UnityEngine.Coroutine gen_ret = gen_to_be_invoked.WaitForSeconds( _delay, _task );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_QueueWaitForSeconds(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                CoroutineHelper gen_to_be_invoked = (CoroutineHelper)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    float _delay = (float)LuaAPI.lua_tonumber(L, 2);
                    CoroutineHelper.Task _task = translator.GetDelegate<CoroutineHelper.Task>(L, 3);
                    
                    gen_to_be_invoked.QueueWaitForSeconds( _delay, _task );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_QueueWaitForEndOfFrame(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                CoroutineHelper gen_to_be_invoked = (CoroutineHelper)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    CoroutineHelper.Task _task = translator.GetDelegate<CoroutineHelper.Task>(L, 2);
                    
                    gen_to_be_invoked.QueueWaitForEndOfFrame( _task );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Instance(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, CoroutineHelper.Instance);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
