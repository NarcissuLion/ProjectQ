BattleManager = {}
BattleManager.__index = BattleManager

-- 战斗状态
BattleState = {}
BattleState.BattleStart = 1
BattleState.RoundStart = 2
BattleState.Round = 3
BattleState.RoundEnd = 4
BattleState.BattleEnd = 5

function BattleManager:Create(config)
    local copy = {}
    setmetatable(copy, BattleManager)

    copy:Init(config)
    return copy
end

function BattleManager:Init(config)
    self.config = config
    self.view = BattleUI:Create(self)    
    self.state = BattleState.BattleStart

    self.ownTurn = false
    self:InitState()
    self.fsmManager:Start()
end

function BattleManager:InitState()
    self.fsmManager = FSMManager.Create(self)
    self.fsmManager:AddState(BattleStartState:Create(self))
    self.fsmManager:AddState(RoundStartState:Create(self))
    self.fsmManager:AddState(RoundState:Create(self))
    self.fsmManager:AddState(RoundEndState:Create(self))
    self.fsmManager:AddState(BattleEndState:Create(self))
end

function BattleManager:ChangeState(newState)
    self.fsmManager:ChangeState(newState)
end


------------------------------------------------------------
function BattleManager:GetCharData(id)
    for uuid, data in pairs(self.own) do
        if uuid == id then
            return data
        end
    end
    for uuid, data in pairs(self.enemy) do
        if uuid == id then
            return data
        end
    end
    if id == nil then
        printError("id为空")
        return
    end
    printError("找不到uuid"..id.."的英雄")
end

function BattleManager:GetCharSpd(id)
    local charData = self:GetCharData(id)
    return charData.spd
end

function BattleManager:GetCharMaxHp(id)
    local charData = ConfigManager:GetConfig("Character")
    if charData ~= nil and charData[id] ~= nil then
        return charData[id].hp
    end
end

function BattleManager:GetCharByPos(isOwn , pos)
    if isOwn then
        for uuid, data in pairs(self.own) do
            if data.pos == pos then
                return data
            end
        end
    else
        for uuid, data in pairs(self.enemy) do
            if data.pos == pos then
                return data
            end
        end
    end
    
    return nil
end

function BattleManager:AddCharHp(isOwn ,pos , hp)
    if isOwn then
        for uuid, data in pairs(self.own) do
            if data.pos == pos then
                local maxHp = self:GetCharMaxHp(data.uid)
                self.own[uuid].hp = math.max(0,math.min(self.own[uuid].hp + hp , maxHp))
                if self.own[uuid].hp == 0 then
                    self.own[uuid].isDead = true
                end
            end
        end
    else
        for uuid, data in pairs(self.enemy) do
            if data.pos == pos then
                local maxHp = self:GetCharMaxHp(data.uid)
                self.enemy[uuid].hp = math.max(0,math.min(self.enemy[uuid].hp + hp , maxHp))
                if self.enemy[uuid].hp == 0 then
                    self.enemy[uuid].isDead = true
                end
            end
        end
    end
end

function BattleManager:UseSkillToChar(skillIndex,uuid)
    if self.state == BattleState.Round then
        self.fsmManager:OwnUseSkill(skillIndex,uuid)
        self.view:SetSkillSelect()
    end
end

