--region *.lua
--Date
--此文件由[BabeLua]插件自动生成

function Destroy(obj)
    CS.UnityEngine.GameObject.Destroy(obj)
end

function table.getCount(self)
	local count = 0
	
	for k, v in pairs(self) do
		count = count + 1	
	end
	
	return count
end

function printJson(json)
    print(RapidJson.encode(json))
end

function print(str)
    CS.LuaDebugger.LogLua(str, GetFunctionTraceback("print"))
end

function printf(str)
    CS.LuaDebugger.LogLua(str, GetFunctionTraceback("printf"))
end

function printError(str)
    CS.LuaDebugger.LogLuaError(str, GetFunctionTraceback("printError"))
end

function printfError(str)
    CS.LuaDebugger.LogLuaError(str, GetFunctionTraceback("printfError"))
end

--function print(str, ...)
--    local args = {...}
--    for i = 1, select("#", ...) do
--        if args[i] == nil then
--            args[i] = "Null"
--        end
--    end
--    CS.LuaDebugger.LogLua(str, GetFunctionTraceback("print"), unpack(args))
--end

--function printError(obj, ...)
--    local args = {...}
--    for i = 1, select("#", ...) do
--        if args[i] == nil then
--            args[i] = "Null"
--        end
--    end
--    CS.LuaDebugger.LogLuaError(obj, GetFunctionTraceback("printError"), unpack(args))
--end

function GetFunctionTraceback(funcName)
    local traceback = debug.traceback()
    local from, to = string.find(traceback, "in function '" .. funcName .. "'")
    if to ~= nil then
        return Trim(string.sub(traceback, to + 1))
    else
        return traceback
    end
end

function Trim(s) 
    return (string.gsub(s, "^%s*(.-)%s*$", "%1"))
end  

-- 返回一个委托函数
-- 例如:
--      一个C#回调接口Callback(int a, string b)
--      lua这边可以绑定到一个function，比如LuaTable:SomeFunction(a, b)
--      通过xxx.callback = BindDelegate(LuaTable, LuaTable.SomeFunction)
--      或者xxx.callback = BindDelegate(self, self.SomeFunction)
function BindDelegate(table, func)
    if func == nil then
        printError("BindDelegate() error, func is nil")
        return nil
    end

    if type(func) ~= "function" then
        printfError("BindDelegate() error, func is not a function: {0}", type(func))
        return nil
    end

    return
        function (...)
            return func(table, ...)
        end
end

-- 返回一个闭包函数
-- 例如:
--      lua中给一个按钮绑定一个点击事件，要传递一些参数到一个lua的function
--      通过btn.onClick:AddListener(BindFunction(self, self.SomeFunction, 123, "abc"))
function BindFunction(table, func, ...)
    if func == nil then
        printError("BindFunction() error, func is nil")
        return nil
    end

    if type(func) ~= "function" then
        printfError("BindFunction() error, func is not a function: {0}", type(func))
        return nil
    end

    local args = {...}
    return
        function ()
            return func(table, args[1], args[2], args[3], args[4], args[5])
--            return func(table, unpack(args))
        end
end

-- 异常处理
-- func 需要处理的函数
-- errHandleFun 发生异常的处理方法，默认为空，则弹出错误提示框
-- return 是否成功,成功返回值/失败信息
function TryCatch(func, errHandleFun)
    if func == nil then
        return false, "func is nil"
    end

    if errHandleFun == nil then
        return xpcall(func, function(err)
            printError(err)
        end)
    end
    return xpcall(func, errHandleFun)
end

-- 异步调用方法，使用协程实现
-- delay            延时秒数，可为空
-- host             执行协程的宿主对象，可为空。如果指定为当前对象，可实现销毁时自动中止异步操作
-- return handler   当host为空的时候，用StopAsyncall(handler)也能实现中止异步操作
function AsyncCall(func, delay, host)
    if func == nil then
        printError("AsyncCall() has a nil func")
        return nil
    end

    local coroutineHelper = nil
    if host == nil then
        coroutineHelper = CoroutineHelper.Instance
    else
        coroutineHelper = CoroutineHelper.GetInstance(host)
    end
        
    if delay == nil or delay <= 0 then
        return coroutineHelper:WaitForEndOfFrame(func)
    else
        return coroutineHelper:WaitForSeconds(delay, func)
    end
end

-- 向异步队列中加入一个异步调用，即同一个host同时只有一个异步操作会执行，使用协程实现
-- delay            延时秒数，可为空
-- host             执行协程的宿主对象，可为空。如果指定为当前对象，可实现销毁时自动中止异步操作
function QueueAsyncCall(func, delay, host)
    if func == nil then
        printError("QueueAsyncCall() has a nil func")
        return nil
    end

    local coroutineHelper = nil
    if host == nil then
        coroutineHelper = CoroutineHelper.Instance
    else
        coroutineHelper = CoroutineHelper.GetInstance(host)
    end

    if delay == nil or delay <= 0 then
        return coroutineHelper:QueueWaitForEndOfFrame(func)
    else
        return coroutineHelper:QueueWaitForSeconds(delay, func)
    end
end

-- 停止指定的协程句柄，或者停止指定host上的所有协程
function StopAsyncall(handler, host)
    local coroutineHelper = nil
    if host == nil then
        coroutineHelper = CoroutineHelper.Instance
    else
        coroutineHelper = CoroutineHelper.GetInstance(host)
    end
    if handler == nil then
        coroutineHelper:StopAll()
    else
        coroutineHelper:Stop(handler)
    end
end

-- 或者停止指定host上的所有协程
function StopAllAsyncall(host)
    if host ~= nil then
        local coroutineHelper = CoroutineHelper.GetInstance(host)
        if coroutineHelper ~= nil then
            coroutineHelper:StopAll()
        end
    end
end

-- 自带遮挡输入的延时AsyncCall
function AsyncCallBlockInput(func, delay, host)
    ViewManager:BlockInput(true)
    return AsyncCall(function()
        ViewManager:BlockInput(false)
        SafeCall(func)
    end, delay, host)
end

function ArrayContains(array, item)
    for i, v in ipairs(array) do
        if v == item then
            return true
        end
    end
    return false
end

function JoinArray(...)
    local args = {...}
    local result = {}
    for i, array in ipairs(args) do
        for j, item in ipairs(array) do
            table.insert(result, item)
        end
    end
    return result
end

function JoinString(array, seperator)
    local str = ""
    local count = table.getCount(array)

    for i = 1, count do
        if i > 1 then
            str = str .. seperator
        end
        str = str .. array[i]
    end
    return str
end

function StartsWith(str, pattern)
    return string.sub(str, 1, str.len(pattern)) == pattern
end

function EndsWith(str, pattern)
    return string.sub(str, - str.len(pattern)) == pattern
end

function SafeCall(callback, ...)
    if callback ~= nil then
        callback(...)
    end
end

function Choose(bool, trueValue, falseValue)
    if bool then
        return trueValue
    else
        return falseValue
    end
end

function GetFilePathWithoutExt(path)
    local index = string.find(path, "%.")
    if index >= 1 then
        return string.sub(path, 1, index - 1)
    end
    return path
end

function FindJsonPath(root, path, defaultValue)
    local result = root
    for i, p in ipairs(path:split(".")) do
        result = result[p]
        if result == nil then
            return defaultValue
        end
    end

    if result == nil then
        return defaultValue
    else
        return result
    end
end

function CombineUrl(url, path)
    if EndsWith(url, "/") then
        if StartsWith(path, "/") then
            return url .. string.sub(path, 2)
        else
            return url .. path
        end
    else
        if StartsWith(path, "/") then
            return url .. path
        else
            return url .. "/" .. path
        end
    end
end

function CombinePath(path1, path2)
    if IsNilOrEmptyStr(path1) then
        if IsNilOrEmptyStr(path2) then
            return nil
        else
            return path2
        end
    else
        if IsNilOrEmptyStr(path2) then
            return path1
        else
            return path1 .. "/" .. path2
        end
    end
end

function GetRandomArrayItem(array)
    local index = math.random(1, table.getCount(array))
    return array[index]
end

-- 防精度误差减法
function Minus(a, b, precision)
    return math.round(a * precision - b * precision) / precision
end

-- 防精度误差加法
function Plus(a, b, precision)
    return math.round(a * precision + b * precision) / precision
end

--截取中英混合的UTF8字符串，endIndex可缺省
function SubStringUTF8(str, startIndex, endIndex)
    if startIndex < 0 then
        startIndex = SubStringGetTotalIndex(str) + startIndex + 1;
    end

    if endIndex ~= nil and endIndex < 0 then
        endIndex = SubStringGetTotalIndex(str) + endIndex + 1;
    end

    if endIndex == nil then 
        return string.sub(str, SubStringGetTrueIndex(str, startIndex));
    else
        return string.sub(str, SubStringGetTrueIndex(str, startIndex), SubStringGetTrueIndex(str, endIndex + 1) - 1);
    end
end

--获取中英混合UTF8字符串的真实字符数量
function SubStringGetTotalIndex(str)
    local curIndex = 0;
    local i = 1;
    local lastCount = 1;
    repeat 
        lastCount = SubStringGetByteCount(str, i)
        i = i + lastCount;
        curIndex = curIndex + 1;
    until(lastCount == 0);
    return curIndex - 1;
end

function SubStringGetTrueIndex(str, index)
    local curIndex = 0;
    local i = 1;
    local lastCount = 1;
    repeat 
        lastCount = SubStringGetByteCount(str, i)
        i = i + lastCount;
        curIndex = curIndex + 1;
    until(curIndex >= index);
    return i - lastCount;
end

--返回当前字符实际占用的字符数
function SubStringGetByteCount(str, index)
    local curByte = string.byte(str, index)
    local byteCount = 1;
    if curByte == nil then
        byteCount = 0
    elseif curByte > 0 and curByte <= 127 then
        byteCount = 1
    elseif curByte>=192 and curByte<=223 then
        byteCount = 2
    elseif curByte>=224 and curByte<=239 then
        byteCount = 3
    elseif curByte>=240 and curByte<=247 then
        byteCount = 4
    end
    return byteCount;
end

--endregion
