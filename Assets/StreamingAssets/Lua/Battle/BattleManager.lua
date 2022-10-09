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
    if self.state == BattleState.Round and self.ownTurn then
        self.fsmManager:GetNowState():OwnUseSkill(skillIndex,uuid)
        self.view:SetSkillSelect()
    end
end

function BattleManager:OwnMove(moveTo)
    if self.state == BattleState.Round and self.ownTurn then
        self.fsmManager:GetNowState():OwnMove(moveTo)
    end
end

function BattleManager:ExchangeChar(isOwn , pos1 , pos2)
    if isOwn then
        local uuid1
        local uuid2
        for uuid, data in pairs(self.own) do
            if data.pos == pos1 then
                uuid1 = uuid
            end
            if data.pos == pos2 then
                uuid2 = uuid
            end
        end
        
        self.own[uuid1].pos = pos2
        self.own[uuid2].pos = pos1
    else
        local uuid1
        local uuid2
        for uuid, data in pairs(self.enemy) do
            if data.pos == pos1 then
                uuid1 = uuid
            end
            if data.pos == pos2 then
                uuid2 = uuid
            end
        end
        self.enemy[uuid1].pos = pos2
        self.enemy[uuid2].pos = pos1
    end    
end

function BattleManager:GetMoveAtkPos(isOwn , nowPos , skillConfig)
    if skillConfig.typ == "cure" then
        return skillConfig.atkPos
    end

    if skillConfig.range == "own" then
        return skillConfig.atkPos
    end

    local atkPos = skillConfig.atkPos
    local allData = self:GetOrderData()

    if nowPos ~= 8 then
        for i = nowPos + 1, 8 do
            local charData = allData[i]
            if charData ~= nil and charData.isDead == nil then
                break
            end
            if isOwn then
                atkPos[2] = math.min(4,atkPos[2]+1)
            end
            if not isOwn then
                atkPos[1] = math.max(1,atkPos[1]-1)
            end
        end        
    end
    if nowPos ~= 1 then
        for i = nowPos - 1, 1,-1 do
            local charData = allData[i]
            if charData ~= nil and charData.isDead == nil then
                break
            end
            if isOwn then
                atkPos[1] = math.max(1,atkPos[1]-1)
            end
            if not isOwn then
                atkPos[2] = math.min(4,atkPos[2]+1)
            end
        end        
    end
    return atkPos
end

function BattleManager:GetCharTempMovePos(isOwn , pos)
    local nowPos = self:GetOrderPos(isOwn , pos)
    local canMovePos = {}
    local allData = self:GetOrderData()

    if nowPos ~= 8 then
        for i = nowPos + 1, 8 , 1 do
            local charData = allData[i]
            if charData ~= nil and charData.isDead == nil then
                break
            end
            table.insert(canMovePos , i)
        end        
    end
    if nowPos ~= 1 then
        for i = nowPos - 1, 1,-1 do
            local charData = allData[i]
            if charData ~= nil and charData.isDead == nil then
                break
            end
            table.insert(canMovePos , i)
        end        
    end
    
    if #canMovePos ~= 0 then
        table.insert(canMovePos , nowPos)
    end
    return canMovePos
end

function BattleManager:GetOrderPos(isOwn , nowPos)
    local posIndex
    if isOwn then
        if nowPos == 1 then
            posIndex = 4
        elseif nowPos == 2 then
            posIndex = 3
        elseif nowPos == 3 then
            posIndex = 2
        elseif nowPos == 4 then
            posIndex = 1
        end
    else
        if nowPos == 1 then
            posIndex = 5
        elseif nowPos == 2 then
            posIndex = 6
        elseif nowPos == 3 then
            posIndex = 7
        elseif nowPos == 4 then
            posIndex = 8
        end
    end

    return posIndex
end

function BattleManager:GetCampPos(orderPos)
    if orderPos == 1 then
        return true , 4
    elseif orderPos == 2 then
        return true , 3
    elseif orderPos == 3 then
        return true , 2
    elseif orderPos == 4 then
        return true , 1
    end

    if orderPos == 5 then
        return false , 1
    elseif orderPos == 6 then
        return false , 2
    elseif orderPos == 7 then
        return false , 3
    elseif orderPos == 8 then
        return false , 4
    end
end

function BattleManager:GetOrderData()
    local allData = {}
    for uuid, data in pairs(self.own) do
        local index = self:GetOrderPos(true , data.pos)
        print(index)
        printJson(data)
        allData[index] = data
    end
    for uuid, data in pairs(self.enemy) do
        local index = self:GetOrderPos(false , data.pos)
        allData[index] = data
    end

    return allData
end

