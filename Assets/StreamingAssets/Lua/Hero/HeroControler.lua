local FSMachine = require "Framework.FSMachine"
local Notifier = require "Framework.Notifier"

HeroControler = {}
HeroControler.__index = HeroControler

HeroState = {}
HeroState.IdelState = "IdelState"
HeroState.ActionState = "ActionState"
HeroState.HurtState = "HurtState"
HeroState.DyingState = "DyingState"
HeroState.DeadState = "DeadState"

function HeroControler.Create(uuid,pos,id,isOwn)
    local copy = {}
    setmetatable(copy, HeroControler)
    HeroControler.__index = HeroControler
    copy:Init(uuid,pos,id,isOwn)
    return copy
end

function HeroControler:Init(uuid,pos,id,isOwn)
    local heroData = ConfigManager:GetConfig("Hero")[id]

    self.isOwn = isOwn
    self.pos = pos
    self.uid = id
    self.uuid = uuid
    self.name = heroData.name
    self.prefab = heroData.prefab
    self.hp = heroData.hp
    self.atk = heroData.atk
    self.spd = heroData.spd
    self.vol = heroData.vol
    self.isDead = false
    self.skill = heroData.skill
    self.skillCD = heroData.skillcd

    self.isPlayAction = false

    if self.vol ~= 1 then
        Notifier.Dispatch("SetHeroVol" , self.pos , self.vol)
    end

    self.state = HeroState.IdelState
    self:InitState()
    self:ChangeState(self.state)
end

function HeroControler:InitState()
    self.fsmManager = FSMachine.Create(self)
    self.fsmManager:Add(HeroState.IdelState , IdelState:Create(self))
    self.fsmManager:Add(HeroState.ActionState , ActionState:Create(self))
    self.fsmManager:Add(HeroState.HurtState , HurtState:Create(self))
    self.fsmManager:Add(HeroState.DyingState , DyingState:Create(self))
    self.fsmManager:Add(HeroState.DeadState , DeadState:Create(self))
end

function HeroControler:ChangeState(newState , ...)
    self.fsmManager:Switch(newState , ...)
end

function HeroControler:OnBattleStart()
    
end

function HeroControler:OnBattleEnd()
    
end

function HeroControler:OnRoundStart()
    if self.uid == "1" then
        local text = "吞噬所有小怪，之后对敌方全体造成大量伤害，每吞噬一只伤害提升100%"
        Notifier.Dispatch("SetBuff2" , self.pos , self.skillCD[1] , text)
    end
end

function HeroControler:OnRoundEnd()
    for index, cd in ipairs(self.skillCD) do
        if cd > 0 then
            self.skillCD[index] = self.skillCD[index] - 1
        end
    end

    if self.uid == "1" then
        for i = 8, 10 do
            local hero = BattleManager:GetHeroByPos(i)
            if hero == nil or hero.isDead then
                Notifier.Dispatch("ShowEffectText" , self.pos , "召唤")
                BattleManager:CreatePlayer(i , "2" , false)
                break
            end
        end
    end

    if self.buff ~= nil then
        for index, buff in ipairs(self.buff) do
            buff.round = buff.round - 1
            if buff.round <= 0 then
                if buff.name == "嘲讽" then
                    Notifier.Dispatch("ShowBuff1" , self.pos , false)
                end
                self.buff[index] = nil
            end
        end
    end
end

function HeroControler:OnActionStart()
    
end

function HeroControler:OnActionEnd()
    
end

function HeroControler:Update()
    self.fsmManager:Update()
end


---------------------Tool-------------------------
function HeroControler:GetHeroData(id)
    local config = ConfigManager:GetConfig("Hero")
    if config ~= nil then
        return config[id]
    end
    print(id .. " id is not found")
end

function HeroControler:AddHeroHp(hp)
    local maxHp = BattleManager:GetHeroMaxHp(self.uid)
    self.hp = math.max(0,math.min(self.hp + hp , maxHp))
    if self.hp == 0 then
        self:ChangeState(HeroState.DyingState)
    end
end

function HeroControler:GetDmg(skillId)
    local skillConfig = ConfigManager:GetConfig("Skill") 
    local skillConfig = skillConfig[skillId]
    if skillConfig == nil then
        printError("技能" .. skillId .. "表中缺失")
        return
    end
    if skillConfig.typ == "atk" or skillConfig.typ == "special" then
        return -math.ceil(math.random(skillConfig.dmg[1] ,skillConfig.dmg[2] ) * 0.01 * self.atk)
    elseif skillConfig.typ == "cure" then
        return math.random(skillConfig.dmg[1] ,skillConfig.dmg[2] )
    end
end

function HeroControler:SetBuff(buffName , round)
    if self.buff == nil then
        self.buff = {}
    end
    local buff = {}
    buff.name = buffName
    buff.round = round + 1
    table.insert(self.buff , buff)
end