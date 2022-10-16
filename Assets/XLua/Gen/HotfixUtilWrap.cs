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
    public class HotfixUtilWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(HotfixUtil);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 31, 4, 4);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "GetManifestHash", _m_GetManifestHash_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "BundleFilePathToBundleName", _m_BundleFilePathToBundleName_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "FilePathToAssetPath", _m_FilePathToAssetPath_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "AssetPathToFilePath", _m_AssetPathToFilePath_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "NormalizePath", _m_NormalizePath_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CompareVersion", _m_CompareVersion_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "VersionToDirName", _m_VersionToDirName_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DirNameToVersion", _m_DirNameToVersion_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "PrepareDir", _m_PrepareDir_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "PrepareFileDir", _m_PrepareFileDir_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "IsBundleDifferent", _m_IsBundleDifferent_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "IsFileDifferent", _m_IsFileDifferent_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetCurFileVersion", _m_GetCurFileVersion_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CompressZip", _m_CompressZip_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetZipFileCount", _m_GetZipFileCount_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetZipStreamFileCount", _m_GetZipStreamFileCount_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CompressMax", _m_CompressMax_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DecompressMax", _m_DecompressMax_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Min", _m_Min_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "BytesToLength", _m_BytesToLength_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "LengthToBytes", _m_LengthToBytes_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetBackupName", _m_GetBackupName_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetBackupPath", _m_GetBackupPath_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "BackupCurHotfix", _m_BackupCurHotfix_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "RevertHotfixBackup", _m_RevertHotfixBackup_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DeleteHotfix", _m_DeleteHotfix_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ReloadGameFromLua", _m_ReloadGameFromLua_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ReloadGame", _m_ReloadGame_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "NeedDecompressResource", _m_NeedDecompressResource_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CreateCompleteHotfixMarkFile", _m_CreateCompleteHotfixMarkFile_xlua_st_);
            
			
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "PACKAGE_FILE_ZIP", _g_get_PACKAGE_FILE_ZIP);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "PACKAGE_FILE_MAX", _g_get_PACKAGE_FILE_MAX);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "HOTFIX_MARK_FILE", _g_get_HOTFIX_MARK_FILE);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "compressLevel", _g_get_compressLevel);
            
			Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "PACKAGE_FILE_ZIP", _s_set_PACKAGE_FILE_ZIP);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "PACKAGE_FILE_MAX", _s_set_PACKAGE_FILE_MAX);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "HOTFIX_MARK_FILE", _s_set_HOTFIX_MARK_FILE);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "compressLevel", _s_set_compressLevel);
            
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "HotfixUtil does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetManifestHash_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _filePath = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = HotfixUtil.GetManifestHash( _filePath );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_BundleFilePathToBundleName_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _assetBundleRoot = LuaAPI.lua_tostring(L, 1);
                    string _filePath = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = HotfixUtil.BundleFilePathToBundleName( _assetBundleRoot, _filePath );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FilePathToAssetPath_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _path = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = HotfixUtil.FilePathToAssetPath( _path );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AssetPathToFilePath_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _assetPath = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = HotfixUtil.AssetPathToFilePath( _assetPath );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_NormalizePath_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _path = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = HotfixUtil.NormalizePath( _path );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CompareVersion_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _a = LuaAPI.lua_tostring(L, 1);
                    string _b = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = HotfixUtil.CompareVersion( _a, _b );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_VersionToDirName_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _version = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = HotfixUtil.VersionToDirName( _version );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DirNameToVersion_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _versionName = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = HotfixUtil.DirNameToVersion( _versionName );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PrepareDir_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    string _dir = LuaAPI.lua_tostring(L, 1);
                    bool _clear = LuaAPI.lua_toboolean(L, 2);
                    
                    HotfixUtil.PrepareDir( _dir, _clear );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string _dir = LuaAPI.lua_tostring(L, 1);
                    
                    HotfixUtil.PrepareDir( _dir );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to HotfixUtil.PrepareDir!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PrepareFileDir_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    string _file = LuaAPI.lua_tostring(L, 1);
                    bool _clear = LuaAPI.lua_toboolean(L, 2);
                    
                    HotfixUtil.PrepareFileDir( _file, _clear );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string _file = LuaAPI.lua_tostring(L, 1);
                    
                    HotfixUtil.PrepareFileDir( _file );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to HotfixUtil.PrepareFileDir!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsBundleDifferent_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _bundleName = LuaAPI.lua_tostring(L, 1);
                    HotfixHashList _preHashList = (HotfixHashList)translator.GetObject(L, 2, typeof(HotfixHashList));
                    HotfixHashList _curHashList = (HotfixHashList)translator.GetObject(L, 3, typeof(HotfixHashList));
                    HotfixList _preChangeList = (HotfixList)translator.GetObject(L, 4, typeof(HotfixList));
                    string _md5 = LuaAPI.lua_tostring(L, 5);
                    
                        var gen_ret = HotfixUtil.IsBundleDifferent( _bundleName, _preHashList, _curHashList, _preChangeList, _md5 );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsFileDifferent_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _name = LuaAPI.lua_tostring(L, 1);
                    string _md5 = LuaAPI.lua_tostring(L, 2);
                    HotfixList _preList = (HotfixList)translator.GetObject(L, 3, typeof(HotfixList));
                    
                        var gen_ret = HotfixUtil.IsFileDifferent( _name, _md5, _preList );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetCurFileVersion_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _name = LuaAPI.lua_tostring(L, 1);
                    HotfixList _preList = (HotfixList)translator.GetObject(L, 2, typeof(HotfixList));
                    bool _different = LuaAPI.lua_toboolean(L, 3);
                    
                        var gen_ret = HotfixUtil.GetCurFileVersion( _name, _preList, _different );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CompressZip_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _root = LuaAPI.lua_tostring(L, 1);
                    string _outputFile = LuaAPI.lua_tostring(L, 2);
                    bool _containsRoot = LuaAPI.lua_toboolean(L, 3);
                    
                    HotfixUtil.CompressZip( _root, _outputFile, _containsRoot );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetZipFileCount_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    string _filePath = LuaAPI.lua_tostring(L, 1);
                    int _fileLevel = LuaAPI.xlua_tointeger(L, 2);
                    
                        var gen_ret = HotfixUtil.GetZipFileCount( _filePath, _fileLevel );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string _filePath = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = HotfixUtil.GetZipFileCount( _filePath );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to HotfixUtil.GetZipFileCount!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetZipStreamFileCount_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<System.IO.Stream>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    System.IO.Stream _stream = (System.IO.Stream)translator.GetObject(L, 1, typeof(System.IO.Stream));
                    int _fileLevel = LuaAPI.xlua_tointeger(L, 2);
                    
                        var gen_ret = HotfixUtil.GetZipStreamFileCount( _stream, _fileLevel );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<System.IO.Stream>(L, 1)) 
                {
                    System.IO.Stream _stream = (System.IO.Stream)translator.GetObject(L, 1, typeof(System.IO.Stream));
                    
                        var gen_ret = HotfixUtil.GetZipStreamFileCount( _stream );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to HotfixUtil.GetZipStreamFileCount!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CompressMax_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _root = LuaAPI.lua_tostring(L, 1);
                    string _outputFile = LuaAPI.lua_tostring(L, 2);
                    bool _containsRoot = LuaAPI.lua_toboolean(L, 3);
                    
                    HotfixUtil.CompressMax( _root, _outputFile, _containsRoot );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DecompressMax_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 6&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& translator.Assignable<System.Action<long>>(L, 5)&& translator.Assignable<System.Action<long>>(L, 6)) 
                {
                    string _srcPath = LuaAPI.lua_tostring(L, 1);
                    string _outputPath = LuaAPI.lua_tostring(L, 2);
                    int _bufferSize = LuaAPI.xlua_tointeger(L, 3);
                    int _fileLevel = LuaAPI.xlua_tointeger(L, 4);
                    System.Action<long> _onStart = translator.GetDelegate<System.Action<long>>(L, 5);
                    System.Action<long> _onProgress = translator.GetDelegate<System.Action<long>>(L, 6);
                    
                    HotfixUtil.DecompressMax( _srcPath, _outputPath, _bufferSize, _fileLevel, _onStart, _onProgress );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 6&& translator.Assignable<System.IO.Stream>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& translator.Assignable<System.Action<long>>(L, 5)&& translator.Assignable<System.Action<long>>(L, 6)) 
                {
                    System.IO.Stream _srcStream = (System.IO.Stream)translator.GetObject(L, 1, typeof(System.IO.Stream));
                    string _outputPath = LuaAPI.lua_tostring(L, 2);
                    int _bufferSize = LuaAPI.xlua_tointeger(L, 3);
                    int _fileLevel = LuaAPI.xlua_tointeger(L, 4);
                    System.Action<long> _onStart = translator.GetDelegate<System.Action<long>>(L, 5);
                    System.Action<long> _onProgress = translator.GetDelegate<System.Action<long>>(L, 6);
                    
                    HotfixUtil.DecompressMax( _srcStream, _outputPath, _bufferSize, _fileLevel, _onStart, _onProgress );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to HotfixUtil.DecompressMax!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Min_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    long _a = LuaAPI.lua_toint64(L, 1);
                    long _b = LuaAPI.lua_toint64(L, 2);
                    
                        var gen_ret = HotfixUtil.Min( _a, _b );
                        LuaAPI.lua_pushint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_BytesToLength_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    byte[] _b = LuaAPI.lua_tobytes(L, 1);
                    
                        var gen_ret = HotfixUtil.BytesToLength( _b );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LengthToBytes_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    int _a = LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = HotfixUtil.LengthToBytes( _a );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBackupName_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        var gen_ret = HotfixUtil.GetBackupName(  );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBackupPath_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        var gen_ret = HotfixUtil.GetBackupPath(  );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_BackupCurHotfix_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        var gen_ret = HotfixUtil.BackupCurHotfix(  );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RevertHotfixBackup_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        var gen_ret = HotfixUtil.RevertHotfixBackup(  );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DeleteHotfix_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    HotfixUtil.DeleteHotfix(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReloadGameFromLua_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    HotfixUtil.ReloadGameFromLua(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReloadGame_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    HotfixUtil.ReloadGame(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_NeedDecompressResource_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    
                        var gen_ret = HotfixUtil.NeedDecompressResource(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateCompleteHotfixMarkFile_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _dir = LuaAPI.lua_tostring(L, 1);
                    
                    HotfixUtil.CreateCompleteHotfixMarkFile( _dir );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PACKAGE_FILE_ZIP(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushstring(L, HotfixUtil.PACKAGE_FILE_ZIP);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PACKAGE_FILE_MAX(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushstring(L, HotfixUtil.PACKAGE_FILE_MAX);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_HOTFIX_MARK_FILE(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushstring(L, HotfixUtil.HOTFIX_MARK_FILE);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_compressLevel(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.xlua_pushinteger(L, HotfixUtil.compressLevel);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_PACKAGE_FILE_ZIP(RealStatePtr L)
        {
		    try {
                
			    HotfixUtil.PACKAGE_FILE_ZIP = LuaAPI.lua_tostring(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_PACKAGE_FILE_MAX(RealStatePtr L)
        {
		    try {
                
			    HotfixUtil.PACKAGE_FILE_MAX = LuaAPI.lua_tostring(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_HOTFIX_MARK_FILE(RealStatePtr L)
        {
		    try {
                
			    HotfixUtil.HOTFIX_MARK_FILE = LuaAPI.lua_tostring(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_compressLevel(RealStatePtr L)
        {
		    try {
                
			    HotfixUtil.compressLevel = LuaAPI.xlua_tointeger(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
