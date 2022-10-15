local FSMachine = require 'Framework.FSMachine'
local Notifier = require 'Framework.Notifier'
ActorInputState = {}
ActorInputState.__index = ActorInputState
setmetatable(ActorInputState, FSMachine.State)

function ActorInputState:Create(battle)
    local copy = {}
    setmetatable(copy, ActorInputState)
    copy.battle = battle
    copy.id = BattleState.Round
    copy:Init()
    return copy
end

function ActorInputState:Init()
    
end

function ActorInputState:OnEnter()
    self.hero = self.battle.nowActionHero
    self.battle.ownInfoUuid = self.hero.uuid
    print(self.hero.uuid)
    Notifier.Dispatch("SetOwnInfo" , self.hero)
    Notifier.Dispatch("SetHeroTempMove" , self.hero.pos )
    Notifier.AddListener("InputOver" , self.InputOver , self)
    -- 打开输入
end

function ActorInputState:Dispose()

end

function ActorInputState:OnUpdate()

end

function ActorInputState:OnExit()
    -- 屏蔽输入
    Notifier.RemoveListener("InputOver" , self.InputOver , self)
end

function ActorInputState:InputOver(skillIndex , targetUuid , movePos)
    local skillId = self.hero.skill[skillIndex]
    local skillConfig = ConfigManager:GetConfig("Skill")[skillId]
    if skillConfig.cd ~= 0 then
        self.hero.skillCD[skillIndex] = skillConfig.cd + 1
    end        
    local atkPos = self:GetAtkPos(skillConfig , targetUuid , movePos)

    self.battle:ChangeState(BattleState.ActorAction,skillId , atkPos , movePos)
end

function ActorInputState:GetAtkPos(skillConfig , targetUuid , movePos)
    if skillConfig.range == "aoe" or skillConfig.range == "all" then
        local atkPos = self.battle:GetNowAtkPos(self.hero.pos , movePos , skillConfig)
        return atkPos
    else
        local targetHeroData = self.battle:GetHeroData(targetUuid)
        local tmp = {}        
        table.insert(tmp , targetHeroData.pos)
        return tmp
    end
end