---
--- Generated by EmmyLua(https://github.com/EmmyLua)
--- Created by Lion.
--- DateTime: 2019/4/12 16:39
---

FSMManager = {}
FSMManager.__index = FSMManager

function FSMManager.Create(battle)
    local copy = {}
    setmetatable(copy, FSMManager)
    copy.__index = FSMManager
    copy:Init(battle)
    return copy
end

function FSMManager:Init(target)
    self.target = target
    self.fsmManager = {}
end

function FSMManager:AddState(stateClass)
    self.fsmManager[stateClass.id] = stateClass
end

function FSMManager:Start()
    self.fsmManager[self.target.state]:OnEnter()
end

function FSMManager:ChangeState(stateId , ...)
    self.fsmManager[self.target.state]:OnLeave()
    self.fsmManager[stateId]:CopyState(self.target.state)
    self.target.state = stateId
    self.fsmManager[stateId]:OnEnter(...)
end

function FSMManager:Update()
     self.fsmManager[self.target.state]:Update()
end

function FSMManager:GetNowState()
    return self.fsmManager[self.target.state]
end