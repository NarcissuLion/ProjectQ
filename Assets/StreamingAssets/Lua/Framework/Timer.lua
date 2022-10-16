local Timer = {}
Timer.__index = Timer

local allTimers = {}

-- 无限循环loopTimers传 <= 0， callback(currLoopCount)
function Timer.Create(interval, loopTimes, callback)
    assert (callback ~= nil, "Error! Timer -> callback is nil.")
    local copy = {}
    setmetatable(copy, Timer)
    copy:Init(interval, loopTimes, callback)
    return copy
end

function Timer.UpdateAll(deltaTime)
    for i = #allTimers, 1, -1 do
        if allTimers[i].running then
            allTimers[i]:Update(deltaTime)
        end
        if not allTimers[i].running then
            table.remove(allTimers, i)
        end
    end
end

function Timer:Init(interval, loopTimes, callback)
    self.interval = interval
    self.loopTimes = loopTimes
    self.callback = callback
    self:Reset()
    self.running = false
end

function Timer:Reset()
    self.timer = 0
    self.counter = 0
end

function Timer:Play()
    if self.running then return end
    table.insert(allTimers, self)
    self.running = true
end

function Timer:Stop()
    self.running = false
end

function Timer:Update(deltaTime)
    self.timer = self.timer + deltaTime
    if self.timer >= self.interval then
        self.counter = self.counter + 1
        self.timer = self.timer - self.interval
        if self.loopTimes > 0 and self.counter >= self.loopTimes then
            self:Stop()
        end
        self.callback(self.counter)
    end
end

return Timer