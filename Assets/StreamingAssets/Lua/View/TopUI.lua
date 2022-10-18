local Notifier = require 'Framework.Notifier'
TopUI = {}
TopUI.__index = TopUI

function TopUI:Create()
    self.root = GameUtil.CreatePrefab("Prefab/UI/Battle/TopUI_2")
    ViewManager:AddToTopCanvas(self.root , true)
    self:AddListener()
    return self
end

function TopUI:AddListener()
    Notifier.AddListener("SetRound",self.SetRound , self)
    Notifier.AddListener("SetOwnInfo",self.SetOwnInfo , self)
    Notifier.AddListener("SetEnemyInfo",self.SetEnemyInfo , self)
    Notifier.AddListener("SetSkillSelect",self.SetSkillSelect , self)
    Notifier.AddListener("ShowGameOver",self.ShowGameOver , self)
end

function TopUI:SetRound(index)
    CommonUtil.SetText(self.root,"Top/RoundIndex","第"..index.."回合")
    CommonUtil.DOLocalMoveY(self.root,"Top/RoundIndex" , -50 , 0.5)
    CommonUtil.DOScaleX(self.root,"Top/RoundIndex" , 2 , 0.5)
    CommonUtil.DOScaleY(self.root,"Top/RoundIndex" , 2 , 0.5)
    CommonUtil.DOScaleZ(self.root,"Top/RoundIndex" , 2 , 0.5)
    AsyncCall(function ()
        CommonUtil.DOLocalMoveY(self.root,"Top/RoundIndex" , 0 , 0.5)
        CommonUtil.DOScale(self.root,"Top/RoundIndex" ,Vector3.one  , 0.5)
    end ,0.5)
end

function TopUI:SetOwnInfo(heroData , newPos)
    local ownInfo = CommonUtil.GetChild(self.root,"UI/Own")
    CommonUtil.SetActive(ownInfo ,nil, heroData ~= nil)
    if heroData == nil then
        return
    end
    CommonUtil.SetActive(ownInfo ,nil, not heroData.isDead)
    if heroData.isDead then
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
                for index, pos in pairs(skillConfig.atkPos) do
                    if index == 1 then
                        text = text .. pos
                    else
                        text = text .. "&" .. pos
                    end
                end
                CommonUtil.SetText(ownInfo,"Skill/" .. i .. "/atkPos","射程:[" .. text .. "]")
            elseif skillConfig.range == "one" then
                local text = ""
                for index, pos in pairs(skillConfig.atkPos) do
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

            --检查被攻击的位置是否有人
            if skillConfig.range == "own" then
                canUse = true
            end
            if skillConfig.range == "all" then
                canUse = true
            end
            local atkPos = BattleManager:GetNowAtkPos(heroData.pos,newPos , skillConfig)
            for index, pos in pairs(atkPos) do
                local heroData = BattleManager:GetHeroByPos(pos)
                if heroData ~= nil and not heroData.isDead then
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

            self:SetOwnSkillEnable(i , canUse)

            --设置cd
            CommonUtil.SetText(ownInfo , "Skill/" .. i .. "/cd/value" , heroData.skillCD[i])
            CommonUtil.SetActive(ownInfo , "Skill/" .. i .. "/cd" , heroData.skillCD[i] ~= 0 )
        end
    end
end

function TopUI:SetEnemyInfo(uuid)
    local enemyInfo = CommonUtil.GetChild(self.root,"UI/Enemy")
    CommonUtil.SetActive(enemyInfo ,nil, uuid ~= nil)
    if uuid == nil then
        return
    end
    local heroData = BattleManager:GetHeroData(uuid)
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


function TopUI:SetOwnSkillEnable(index , canUse)
    CommonUtil.SetBtnInteractable(self.root,"UI/Own/Skill/" .. index , canUse)
end

function TopUI:SetOwnSkillAllDisenable()
    for i = 1, 4 do
        CommonUtil.SetBtnInteractable(self.root,"UI/Own/Skill/" .. i , false)
    end
end

function TopUI:SetSkillSelect(index , skillConfig , nowPos , newPos)    
    for i = 1, 4 do
        CommonUtil.SetActive(self.root,"UI/Own/Skill/" .. i .. "/Select",false)
    end
    if index == nil then
        return
    end

    Notifier.Dispatch("OnSelectSkill" , index , newPos)
    CommonUtil.SetActive(self.root,"UI/Own/Skill/" .. index .. "/Select",true)
    Notifier.Dispatch("SetHeroSelectedOff")

    local atkPos = BattleManager:GetNowAtkPos(nowPos , newPos , skillConfig)
    if skillConfig.typ == "cure" or skillConfig.typ == "buff" then
        for key, pos in pairs(atkPos) do
            if pos == 0 then
                BattleManager.view:SetHeroSelect(nowPos , "SelectedCure")
            else
                local heroData = BattleManager:GetHeroByPos(pos)
                if heroData ~= nil and not heroData.isDead and heroData.isOwn then
                    BattleManager.view:SetHeroSelect(pos , "SelectedCure")
                end
            end            
        end
    elseif skillConfig.typ == "atk" then
        for key, pos in pairs(atkPos) do
            local heroData = BattleManager:GetHeroByPos(pos)
            if heroData ~= nil and not heroData.isDead and not heroData.isOwn then
                BattleManager.view:SetHeroSelect(heroData.pos , "Selected")
            end
        end
    end
end

function TopUI:ShowGameOver(isWin)
    CommonUtil.SetActive(self.root,"Win" , isWin)
    CommonUtil.SetActive(self.root,"Lose" , not isWin)
end