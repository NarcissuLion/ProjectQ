BattleUI = {}
BattleUI.__index = BattleUI
setmetatable(BattleUI, ViewBase)

BattleUI.instance = nil

IMG_HERO_PATH = "Prefab/SpriteAssets/Character/"

function BattleUI:Create(battleManager)
    local copy = ViewBase:Create({canClose = false})
    setmetatable(copy, self)

    copy:Init(battleManager)

    return copy
end

function BattleUI:Init(battleManager)
    self.root = self:Add("Prefab/UI/Battle/BattleUI")
    self.battleManager = battleManager
    self.hero = {}
    self:CreatePlayer()
end

function BattleUI:CreatePlayer()
    local parent = CommonUtil.GetChild(self.root,"Hero")
    for i = 1, 8 do
        self.hero[i] = GameUtil.CreatePrefabToParent("Prefab/Character/Player",parent,i)
    end    
end

function BattleUI:SetRound(index)
    CommonUtil.SetText(self.root,"Top/RoundIndex","第"..index.."回合")
end

function BattleUI:SetOwnInfo(heroData,newPos)
    local ownInfo = CommonUtil.GetChild(self.root,"UI/Own")
    CommonUtil.SetActive(ownInfo ,nil, heroData ~= nil)
    if heroData == nil then
        return
    end
    CommonUtil.SetActive(ownInfo ,nil, heroData.isDead == nil)
    if heroData.isDead ~= nil then
        return
    end

    local configData = ConfigManager:GetConfig("Hero")
    local maxHp = configData[heroData.uid].hp

    ImageLoader.SetImage(ownInfo,"Icon" ,IMG_HERO_PATH..heroData.prefab)
    CommonUtil.SetText(ownInfo,"Name" , heroData.name)
    CommonUtil.SetText(ownInfo,"Hp" ,"HP:" .. heroData.hp .. "/" .. maxHp)
    CommonUtil.SetText(ownInfo,"Speed" ,"SPD:" .. heroData.spd)
    CommonUtil.SetText(ownInfo,"Atk" ,"ATK:" .. heroData.atk)
    -- CommonUtil.SetActive(ownInfo, "Move",heroData.move > 0)
    -- CommonUtil.AddButtonClick(ownInfo, "Move", BindFunction(self, self.OnClickMove, heroData))
    for i = 1, 4 do
        local skillId = heroData.skill[i]
        CommonUtil.SetActive(ownInfo,"Skill/" .. i , skillId ~= nil)
        if skillId ~= nil then
            local skillConfig = ConfigManager:GetConfig("Skill")[skillId]
            CommonUtil.SetText(ownInfo,"Skill/" .. i .. "/name", skillConfig.name)
            CommonUtil.AddButtonClick(ownInfo,"Skill/"..i , BindFunction(self,self.SetSkillSelect,i,skillConfig,heroData.pos,newPos))
            --射程
            if skillConfig.range == "own" then
                CommonUtil.SetText(ownInfo,"Skill/" .. i .. "/atkPos","射程:自己")
            elseif skillConfig.range == "aoe" then
                local text = ""
                for index, pos in ipairs(skillConfig.atkPos) do
                    if index == 1 then
                        text = text .. pos
                    else
                        text = text .. "&" .. pos
                    end
                end
                CommonUtil.SetText(ownInfo,"Skill/" .. i .. "/atkPos","射程:[" .. text .. "]")
            elseif skillConfig.range == "one" then
                local text = ""
                for index, pos in ipairs(skillConfig.atkPos) do
                    if index == 1 then
                        text = text .. pos
                    else
                        text = text .. "," .. pos
                    end
                end
                CommonUtil.SetText(ownInfo,"Skill/" .. i .. "/atkPos","射程:[" .. text .. "]")
            elseif skillConfig.range == "all" then
                CommonUtil.SetText(ownInfo,"Skill/" .. i .. "/atkPos","射程:[all]")                
            end

            --伤害
            if skillConfig.typ == "atk" then
                CommonUtil.SetText(ownInfo,"Skill/" .. i .. "/dmg","伤害:"..skillConfig.dmg[1].."% - "..skillConfig.dmg[2] .. "%")
            elseif skillConfig.typ == "cure" then
                CommonUtil.SetText(ownInfo,"Skill/" .. i .. "/dmg","治疗:"..skillConfig.dmg[1].." - "..skillConfig.dmg[2])
            end

            --判断技能哪些可以用
            local canUse = false
            if self.battleManager.ownTurn then
                --检查被攻击的位置是否有人
                if skillConfig.range == "own" then
                    canUse = true
                end
                if skillConfig.range == "all" then
                    canUse = true
                end
                local atkPos = self.battleManager:GetNowAtkPos(heroData.pos,newPos , skillConfig)
                printJson(atkPos)
                for index, pos in ipairs(atkPos) do
                    local heroData = self.battleManager:GetHeroByPos(pos)
                    if heroData ~= nil and heroData.isDead == nil then
                        if skillConfig.typ == "cure" then
                            if heroData.isOwn then
                                canUse = true
                                break                                
                            end
                        else
                            if not heroData.isOwn then
                                canUse = true
                                break                                
                            end
                        end                        
                    end
                end
            end
            self:SetOwnSkillEnable(i , canUse)
        end
    end

end

function BattleUI:SetEnemyInfo(uuid)
    local enemyInfo = CommonUtil.GetChild(self.root,"UI/Enemy")
    CommonUtil.SetActive(enemyInfo ,nil, uuid ~= nil)
    if uuid == nil then
        return
    end
    local heroData = self.battleManager:GetHeroData(uuid)
    local configData = ConfigManager:GetConfig("Hero")
    local maxHp = configData[heroData.uid].hp

    ImageLoader.SetImage(enemyInfo,"Icon" ,IMG_HERO_PATH..heroData.prefab)
    CommonUtil.SetText(enemyInfo,"Name" , heroData.name)
    CommonUtil.SetText(enemyInfo,"Hp" ,"HP:" .. heroData.hp .. "/" .. maxHp)
    CommonUtil.SetText(enemyInfo,"Hp" ,"SPD:" .. heroData.spd)
    CommonUtil.SetText(enemyInfo,"Hp" ,"ATK:" .. heroData.atk)

    for i = 1, 4 do
        local skillId = heroData.skill[i]
        CommonUtil.SetActive(enemyInfo,"Skill/" .. i , skillId ~= nil)
        if skillId ~= nil then
            local skillConfig = ConfigManager:GetConfig("Skill")
            CommonUtil.SetText(enemyInfo,"Skill/" .. i .. "/name", skillConfig[skillId].name)
        end
    end
end

function BattleUI:SetHeroSelect(pos ,state )
    CommonUtil.SetActive(self.hero[pos] , state , true)
end

function BattleUI:SetHeroSelectOff()
    for key, player in pairs(self.hero) do
        CommonUtil.SetActive(player,"Select" , false)
        CommonUtil.SetActive(player,"Selected" , false)
        CommonUtil.SetActive(player,"SelectedCure" , false)
        CommonUtil.SetActive(player,"SelectedMove" , false)
    end
end

function BattleUI:SetHeroSelectedOff()
    for key, player in pairs(self.hero) do
        CommonUtil.SetActive(player,"Selected" , false)
        CommonUtil.SetActive(player,"SelectedCure" , false)
    end
end

function BattleUI:RefreshHero(heroData)
    local configData = ConfigManager:GetConfig("Hero")
    local maxHp = configData[heroData.uid].hp
    local player = self.hero[heroData.pos]
    if heroData.isDead then
        CommonUtil.SetActive(player , nil , false)
        return
    end
    CommonUtil.SetActive(player , nil , true)
    CommonUtil.SetActive(player,"Img",true)
    CommonUtil.SetActive(player,"Img2",false)
    CommonUtil.SetActive(player,"HpBar",true)
    CommonUtil.SetActive(player,"Damage",true)
    CommonUtil.SetActive(player,"Cure",true)
    CommonUtil.SetActive(player,"Select",false)
    CommonUtil.SetActive(player,"Selected",false)
    CommonUtil.SetActive(player,"SelectedCure",false)
    CommonUtil.SetActive(player,"SelectedMove",false)
    ImageLoader.SetImage(player,"Img" ,IMG_HERO_PATH..heroData.prefab)
    CommonUtil.SetText(player,"HpBar/Text" , heroData.hp .. "/" .. maxHp)
    CommonUtil.SetImageFillAmount(player, "HpBar/Image" , heroData.hp/maxHp)
    if heroData.isOwn then
        CommonUtil.AddButtonClick(player, "SelectedCure", BindFunction(self, self.OnClickUseSkillToHero, heroData.uuid))
        CommonUtil.AddButtonClick(player, "SelectedMove", BindFunction(self, self.OnSelectMove, heroData.pos))
    else
        CommonUtil.AddButtonClick(player, "Btn", BindFunction(self, self.SetEnemyInfo, heroData.uuid))
        CommonUtil.AddButtonClick(player, "Selected", BindFunction(self, self.OnClickUseSkillToHero, heroData.uuid))
    end
end

function BattleUI:RefreshAllHero()
    for uuid, data in pairs(self.battleManager.hero) do
        self:RefreshHero(data)
    end
end

function BattleUI:ShowDamage(pos , damage)
    CommonUtil.SetText(self.hero[pos],"Damage" ,damage)
    CommonUtil.DOLocalMoveY(self.hero[pos],"Damage" , 380 , 1.6)
    CommonUtil.DoTextFadeFromTo(self.hero[pos],"Damage" , 1 , 0 ,1.6)
    CommonUtil.DoImageColor(self.hero[pos],"Img" ,Color.red , 0.2)
    CommonUtil.DOShake(self.hero[pos],"Img" , 0.2,10,10)        
    AsyncCall(function ()
        CommonUtil.DoImageColor(self.hero[pos],"Img" ,Color.white, 0.2)
    end , 0.2)
    AsyncCall(function ()
        CommonUtil.SetAnchoredPositionY(self.hero[pos],"Damage" , 90)
    end , 1.8)
    
end

function BattleUI:ShowCure(pos , cure)
    CommonUtil.SetText(self.hero[pos],"Cure" ,"+" .. cure)
    CommonUtil.DOLocalMoveY(self.hero[pos],"Cure" , 380 , 1.6)
    CommonUtil.DoTextFadeFromTo(self.hero[pos],"Cure" , 1 , 0 ,1.6)
    CommonUtil.DoImageColor(self.hero[pos],"Img" ,Color.green , 0.2)
    AsyncCall(function ()
        CommonUtil.DoImageColor(self.hero[pos],"Img" ,Color.white, 0.2)
    end , 0.2)
    AsyncCall(function ()
        CommonUtil.SetAnchoredPositionY(self.hero[pos],"Cure" , 90)
    end , 1.8)
end

function BattleUI:SetOwnSkillEnable(index , canUse)
    CommonUtil.SetBtnInteractable(self.root,"UI/Own/Skill/" .. index , canUse)
end

function BattleUI:SetOwnSkillAllDisenable()
    for i = 1, 4 do
        CommonUtil.SetBtnInteractable(self.root,"UI/Own/Skill/" .. i , false)
    end
end

function BattleUI:SetSkillSelect(index , skillConfig , nowPos , newPos)    
    for i = 1, 4 do
        CommonUtil.SetActive(self.root,"UI/Own/Skill/" .. i .. "/Select",false)
    end
    if index == nil then
        return
    end

    self.selectSkillIndex = index
    CommonUtil.SetActive(self.root,"UI/Own/Skill/" .. index .. "/Select",true)

    self:SetHeroSelectedOff()
    self.newPos = newPos

    local atkPos = self.battleManager:GetNowAtkPos(nowPos , newPos , skillConfig)
    if skillConfig.typ == "cure" then
        for key, pos in ipairs(atkPos) do
            if pos == 0 then
                self:SetHeroSelect(nowPos , "SelectedCure")
            else
                local heroData = self.battleManager:GetHeroByPos(pos)
                if not heroData.isDead and heroData.isOwn then
                    self:SetHeroSelect(pos , "SelectedCure")
                end
            end            
        end
    elseif skillConfig.typ == "atk" then
        for key, pos in ipairs(atkPos) do
            local heroData = self.battleManager:GetHeroByPos(pos)
            if not heroData.isDead and not heroData.isOwn then
                self:SetHeroSelect(pos , "Selected")
            end
        end
    end
end

function BattleUI:SetHeroTempMove(nowPos , newPos)
    if newPos == nil then
        newPos = nowPos
    end
    local canMovePos = self.battleManager:GetHeroTempMovePos(nowPos)
    if #canMovePos == 0 then
        return
    end
    self:SetHeroSelectedOff()
    local heroData = self.battleManager:GetHeroByPos(nowPos)
    local configData = ConfigManager:GetConfig("Hero")
    local maxHp = configData[heroData.uid].hp
    for index, pos in ipairs(canMovePos) do
        local player = self.hero[pos]
        CommonUtil.SetActive(player,nil,true)
        if pos ~= newPos then
            CommonUtil.SetActive(player,"Img",false)
            CommonUtil.SetActive(player,"Img2",true)
            CommonUtil.SetActive(player,"HpBar",false)
            CommonUtil.SetActive(player,"Select",false)
            CommonUtil.SetActive(player,"Damage",false)
            CommonUtil.SetActive(player,"Cure",false)
            CommonUtil.SetActive(player,"Btn",false)
            CommonUtil.SetActive(player,"Selected",false)
            CommonUtil.SetActive(player,"SelectedCure",false)
            CommonUtil.SetActive(player,"SelectedMove",true)
            ImageLoader.SetImage(player,"Img2" ,IMG_HERO_PATH..heroData.prefab)
            CommonUtil.AddButtonClick(player, "SelectedMove", BindFunction(self, self.SetHeroTempMove , nowPos , pos))
        else
            CommonUtil.SetActive(player,"Img",true)
            CommonUtil.SetActive(player,"Img2",false)
            CommonUtil.SetActive(player,"HpBar",true)
            CommonUtil.SetActive(player,"Select",true)
            CommonUtil.SetActive(player,"Damage",false)
            CommonUtil.SetActive(player,"Cure",false)
            CommonUtil.SetActive(player,"Btn",false)
            CommonUtil.SetActive(player,"Selected",false)
            CommonUtil.SetActive(player,"SelectedCure",false)
            CommonUtil.SetActive(player,"SelectedMove",false)
            ImageLoader.SetImage(player,"Img" ,IMG_HERO_PATH..heroData.prefab)
            CommonUtil.SetText(player,"HpBar/Text" , heroData.hp .. "/" .. maxHp)
            CommonUtil.SetImageFillAmount(player, "HpBar/Image" , heroData.hp/maxHp)
        end        
    end
    self:SetOwnInfo(heroData , newPos)
    self:SetSkillSelect()
end

function BattleUI:OnClickUseSkillToHero(uuid)
    self.battleManager:UseSkillToHero(self.selectSkillIndex , uuid)
end

function BattleUI:OnClickMove(heroData)
    self:SetSkillSelect()
    if heroData.move == 0 then
        return
    end
    self:ShowMoveSelect(heroData)
end

function BattleUI:ShowMoveSelect(heroData)
    self:SetHeroSelectedOff()
    local pos = heroData.pos 
    local step = heroData.move
    if step == 1 then
        for i = 1, 3 do
            if i == pos - step or i == pos + step then
                self:SetHeroSelect(i , "SelectedMove")
            end
        end
    end

    if step == 2 then
        for i = 1, 3 do
            if i ~= pos then
                self:SetHeroSelect(i , "SelectedMove")
            end
        end
    end
end

function BattleUI:OnSelectMove(moveTo)
    self.battleManager:OwnMove(moveTo)
end

function BattleUI:ExchangeHero(pos1 , pos2)
    --播动画
    local position1 = self.hero[pos1].transform.position
    local position2 = self.hero[pos2].transform.position
    CommonUtil.DOMove(self.hero[pos1],nil , position2 , 0.8)
    CommonUtil.DOMove(self.hero[pos2],nil , position1 , 0.8)
    --还原
    AsyncCall(function ()
        self.hero[pos1].transform.position = position1
        self.hero[pos2].transform.position = position2
    end,0.8) 
end
