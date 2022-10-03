--region *.lua
--Date
--此文件由[BabeLua]插件自动生成

--计数器
Counter = {}

Counter = {}
Counter.__index = Counter

function Counter:Create()
    local copy = {}
    setmetatable(copy, self)

    copy:Init()

    return copy
end

function Counter:Init()
    self.counters = {}
end

function Counter:Add(key, num)
    if self.counters[key] == nil then
        self.counters[key] = 0
    end
    if num == nil then
        self.counters[key] = self.counters[key] + 1
    else
        self.counters[key] = self.counters[key] + num
    end
    
    return self.counters[key]
end

function Counter:Get(key)
    return self.counters[key] or 0
end

function Counter:Set(key, count)
    self.counters[key] = count
end

function Counter:Clear(key)
    self.counters[key] = 0
end

function Counter:ClearAll()
    self.counters = {}
end

--endregion
