HeroControler = {}
HeroControler.__index = HeroControler

HeroState = {}
HeroState.HBattleStartState = 1
HeroState.HRoundStartState = 2
HeroState.HIdelState = 3
HeroState.HAttackState = 4
HeroState.HBeAttackedState = 5
HeroState.HRoundEndState = 6
HeroState.HBattleEndState = 7
HeroState.HDeadState = 8

function HeroControler.Create(uuid,pos,id,isOwn)
    local copy = {}
    setmetatable(copy, HeroControler)
    HeroControler.__index = HeroControler
    copy:Init(uuid,pos,id,isOwn)
    return copy
end

function HeroControler:Init(uuid,pos,id,isOwn)
    local charData = self:GetPlayerData(id)

    self.isOwn = isOwn
    self.pos = pos
    self.uid = id
    self.uuid = uuid
    self.name = charData.name
    self.prefab = charData.prefab
    self.hp = charData.hp
    self.atk = charData.atk
    self.spd = charData.spd
    self.vol = charData.vol
    self.skill = charData.skill
    self.skillCD = {0,0,0,0}

    self.state = HeroState.HBattleStartState
    self:InitState()
    self.fsmManager:Start()
end

function HeroControler:InitState()
    self.fsmManager = FSMManager.Create(self)
    self.fsmManager:AddState(HBattleStartState:Create(self))
    self.fsmManager:AddState(HRoundStartState:Create(self))
    self.fsmManager:AddState(HIdelState:Create(self))
    self.fsmManager:AddState(HAttackState:Create(self))
    self.fsmManager:AddState(HBeAttackedState:Create(self))
    self.fsmManager:AddState(HRoundEndState:Create(self))
    self.fsmManager:AddState(HBattleEndState:Create(self))
end

function HeroControler:ChangeState(newState)
    self.fsmManager:ChangeState(newState)
end

function HeroControler:GetPlayerData(id)
    local config = ConfigManager:GetConfig("Hero")
    if config ~= nil then
        return config[id]
    end
    print(id .. " id is not found")
end