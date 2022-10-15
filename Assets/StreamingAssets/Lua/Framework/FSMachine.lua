local FSMachine = {}
FSMachine.__index = FSMachine

function FSMachine.Create(owner)
    local copy = {}
    setmetatable(copy, FSMachine)
    copy:Init(owner)
    return copy
end

function FSMachine:Init(owner)
    self.owner = owner
    self.states = {}
end

function FSMachine:Dispose()
    if self.currState ~= nil then
        self.currState:OnExit()
    end
    self.currState = nil
    for _,state in pairs(self.states) do
        state:Dispose()
    end
    self.states = nil
end

function FSMachine:Add(stateName, state)
    assert(self.states[stateName] == nil, "error! state<"..stateName.."> already exists.")
    self.states[stateName] = state
    state.owner = self.owner
end

function FSMachine:Switch(stateName, ...)
    local nextState = self.states[stateName]
    assert(nextState ~= nil, "error! state<"..stateName.."> not exists.")
    if self.currState == nextState then return end

    if self.currState ~= nil then
        self.currState:OnExit(stateName)
    end
    self.currState = nextState
    local param = {...}
    self.currState:OnEnter(param[1] , param[2] , param[3] , param[4] , param[5])
end

function FSMachine:Update(...)
    if self.currState ~= nil then
        self.currState:OnUpdate(...)
    end
end


FSMachine.State = {}
FSMachine.State.__index = FSMachine.State

function FSMachine.State.Create(...)
    local copy = {}
    setmetatable(copy, FSMachine.State)
    copy:Init(...)
    return copy
end

function FSMachine.State:Init(...)
end

function FSMachine.State:Dispose()
end

function FSMachine.State:OnEnter(...)
end

function FSMachine.State:OnUpdate(...)
end

function FSMachine.State:OnExit(...)
end

return FSMachine


-- 状态子类模板，只声明需要的方法
-- local MyState = {}
-- local FSMachine = require 'Framework.FSMachine'
-- MyState.__index = MyState
-- setmetatable(MyState, FSMachine.State)

-- function MyState.Create(...)
--     local copy = {}
--     setmetatable(copy, MyState)
--     copy:Init(...)
--     return copy
-- end

-- -- function MyState:Init(...)
-- -- end

-- -- function MyState:Dispose()
-- -- end

-- -- function MyState:OnEnter(...)
-- -- end

-- -- function MyState:OnUpdate(...)
-- -- end

-- -- function MyState:OnExit(...)
-- -- end

-- return MyState