BattleUI = {}
BattleUI.__index = BattleUI
setmetatable(BattleUI, ViewBase)

BattleUI.instance = nil

function BattleUI:Create(battleManager)
    local copy = ViewBase:Create({canClose = false})
    setmetatable(copy, self)

    copy:Init(battleManager)

    return copy
end

function BattleUI:Init(battleManager)
    self.root = self:Add("Prefab/UI/Battle/BattleUI")
    self.battleManager = battleManager
    self.own = {}
    self.enemy = {}
end

function BattleUI:CreatePlayer(isOwn , pos , charData)
    local player
    if isOwn then
        local parent = CommonUtil.GetChild(self.root,"Character/Own")
        self.own[pos] = GameUtil.CreatePrefabToParent("Prefab/Character/Player",parent,pos)
        player = self.own[pos]
        CommonUtil.AddButtonClick(player, "SelectedCure", BindFunction(self, self.OnClickUseSkillToChar, charData.uuid))
        CommonUtil.AddButtonClick(player, "SelectedMove", BindFunction(self, self.OnSelectMove, pos))
    else
        local parent = CommonUtil.GetChild(self.root,"Character/Enemy")
        self.enemy[pos] = GameUtil.CreatePrefabToParent("Prefab/Character/Player",parent,pos)
        player = self.enemy[pos]
        CommonUtil.AddButtonClick(player, "Btn", BindFunction(self, self.SetEnemyInfo, charData.uuid))
        CommonUtil.AddButtonClick(player, "Selected", BindFunction(self, self.OnClickUseSkillToChar, charData.uuid))
    end
    ImageLoader.SetImage(player,"Img" ,"Prefab/SpriteAssets/Character/"..charData.prefab)
    CommonUtil.SetText(player,"HpBar/Text" , charData.hp .. "/" .. charData.hp)
    CommonUtil.SetImageFillAmount(player,pos .. "/HpBar/Image" , charData.hp/charData.hp)
    CommonUtil.SetActive(player,"Select" , false)
    CommonUtil.SetActive(player,"Selected" , false)
end

function BattleUI:SetRound(index)
    CommonUtil.SetText(self.root,"Top/RoundIndex","第"..index.."回合")
end

function BattleUI:SetOwnInfo(charData,newPos)
    printJson(charData)
    local ownInfo = CommonUtil.GetChild(self.root,"UI/Own")
    CommonUtil.SetActive(ownInfo ,nil, charData ~= nil)
    if charData == nil then
        return
    end
    CommonUtil.SetActive(ownInfo ,nil, charData.isDead == nil)
    if charData.isDead ~= nil then
        return
    end

    local nowPos = charData.pos
    if newPos ~= nil then
        nowPos = newPos
    end
    local configData = ConfigManager:GetConfig("Character")
    local maxHp = configData[charData.uid].hp

    ImageLoader.SetImage(ownInfo,"Icon" ,"Prefab/SpriteAssets/Character/"..charData.prefab)
    CommonUtil.SetText(ownInfo,"Name" , charData.name)
    CommonUtil.SetText(ownInfo,"Hp" ,"HP:" .. charData.hp .. "/" .. maxHp)
    CommonUtil.SetText(ownInfo,"Speed" ,"SPD:" .. charData.spd)
    CommonUtil.SetText(ownInfo,"Atk" ,"ATK:" .. charData.atk)
    CommonUtil.SetActive(ownInfo, "Move",charData.move > 0)
    CommonUtil.AddButtonClick(ownInfo, "Move", BindFunction(self, self.OnClickMove, charData))
    for i = 1, 4 do
        local skillId = charData.skill[i]
        CommonUtil.SetActive(ownInfo,"Skill/" .. i , skillId ~= nil)
        if skillId ~= nil then
            local skillConfig = ConfigManager:GetConfig("Skill")[skillId]
            CommonUtil.SetText(ownInfo,"Skill/" .. i .. "/name", skillConfig.name)
            CommonUtil.AddButtonClick(ownInfo,"Skill/"..i , BindFunction(self,self.SetSkillSelect,i,skillConfig,nowPos))
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
            end

            --站位
            local text = ""
            for index, pos in ipairs(skillConfig.pos) do
                if index == 1 then
                    text = text .. pos
                else
                    text = text .. "," .. pos
                end
            end
            CommonUtil.SetText(ownInfo,"Skill/" .. i .. "/pos","站位:[" .. text .. "]")

            --伤害
            if skillConfig.typ == "atk" then
                CommonUtil.SetText(ownInfo,"Skill/" .. i .. "/dmg","伤害:"..skillConfig.dmg[1].."% - "..skillConfig.dmg[2] .. "%")
            elseif skillConfig.typ == "cure" then
                CommonUtil.SetText(ownInfo,"Skill/" .. i .. "/dmg","治疗:"..skillConfig.dmg[1].." - "..skillConfig.dmg[2])
            end

            --判断技能哪些可以用
            local canUse = false
            if self.battleManager.ownTurn then
                -- 检查站位
                local posRight = false
                for index, pos in ipairs(skillConfig.pos) do
                    if nowPos == pos then
                        posRight = true
                        break
                    end
                end
                if posRight then
                    if skillConfig.typ == "cure" then
                        canUse = true
                    else
                        --检查被攻击的位置是否有人（需要考虑移动问题）
                        for index, pos in ipairs(skillConfig.atkPos) do
                            local charData = self.battleManager:GetCharByPos(false,pos)
                            if charData ~= nil and charData.isDead == nil then
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
    local charData = self.battleManager:GetCharData(uuid)
    local configData = ConfigManager:GetConfig("Character")
    local maxHp = configData[charData.uid].hp

    ImageLoader.SetImage(enemyInfo,"Icon" ,"Prefab/SpriteAssets/Character/"..charData.prefab)
    CommonUtil.SetText(enemyInfo,"Name" , charData.name)
    CommonUtil.SetText(enemyInfo,"Hp" ,"HP:" .. charData.hp .. "/" .. maxHp)
    CommonUtil.SetText(enemyInfo,"Hp" ,"SPD:" .. charData.spd)
    CommonUtil.SetText(enemyInfo,"Hp" ,"ATK:" .. charData.atk)

    for i = 1, 4 do
        local skillId = charData.skill[i]
        CommonUtil.SetActive(enemyInfo,"Skill/" .. i , skillId ~= nil)
        if skillId ~= nil then
            local skillConfig = ConfigManager:GetConfig("Skill")
            CommonUtil.SetText(enemyInfo,"Skill/" .. i .. "/name", skillConfig[skillId].name)
        end
    end
end

function BattleUI:SetCharSelect(isOwn , pos ,state )
    if isOwn then
        CommonUtil.SetActive(self.own[pos],state , true)
    else
        CommonUtil.SetActive(self.enemy[pos],state , true)
    end
end

function BattleUI:SetCharSelectOff()
    for key, player in pairs(self.own) do
        CommonUtil.SetActive(player,"Select" , false)
        CommonUtil.SetActive(player,"Selected" , false)
        CommonUtil.SetActive(player,"SelectedCure" , false)
        CommonUtil.SetActive(player,"SelectedMove" , false)
    end
    for key, player in pairs(self.enemy) do
        CommonUtil.SetActive(player,"Select" , false)
        CommonUtil.SetActive(player,"Selected" , false)
        CommonUtil.SetActive(player,"SelectedCure" , false)
        CommonUtil.SetActive(player,"SelectedMove" , false)
    end
end

function BattleUI:SetCharSelectedOff()
    for key, player in pairs(self.own) do
        CommonUtil.SetActive(player,"Selected" , false)
        CommonUtil.SetActive(player,"SelectedCure" , false)
    end
    for key, player in pairs(self.enemy) do
        CommonUtil.SetActive(player,"Selected" , false)
        CommonUtil.SetActive(player,"SelectedCure" , false)
    end
end

function BattleUI:RefreshChar(charData)
    local configData = ConfigManager:GetConfig("Character")
    local maxHp = configData[charData.uid].hp
    if charData.isOwn then
        if charData.isDead then
            CommonUtil.SetActive(self.own[charData.pos] , nil , false)
            return
        end
        ImageLoader.SetImage(self.own[charData.pos],"Img" ,"Prefab/SpriteAssets/Character/"..charData.prefab)
        CommonUtil.SetText(self.own[charData.pos],"HpBar/Text" , charData.hp .. "/" .. maxHp)
        CommonUtil.SetImageFillAmount(self.own[charData.pos], "HpBar/Image" , charData.hp/maxHp)
    else
        if charData.isDead then
            CommonUtil.SetActive(self.enemy[charData.pos] , nil , false)
            return
        end
        ImageLoader.SetImage(self.enemy[charData.pos],"Img" ,"Prefab/SpriteAssets/Character/"..charData.prefab)
        CommonUtil.SetText(self.enemy[charData.pos],"HpBar/Text" , charData.hp .. "/" .. maxHp)
        CommonUtil.SetImageFillAmount(self.enemy[charData.pos] , "HpBar/Image" , charData.hp/maxHp)
    end
end

function BattleUI:ShowDamage(isOwn , pos , damage)
    if isOwn then
        CommonUtil.SetText(self.own[pos],"Damage" ,damage)
        CommonUtil.DOLocalMoveY(self.own[pos],"Damage" , 380 , 1.6)
        CommonUtil.DoTextFadeFromTo(self.own[pos],"Damage" , 1 , 0 ,1.6)
        CommonUtil.DoImageColor(self.own[pos],"Img" ,Color.red , 0.2)
        CommonUtil.DOShake(self.own[pos],"Img" , 0.2,10,10)        
        AsyncCall(function ()
            CommonUtil.DoImageColor(self.own[pos],"Img" ,Color.white, 0.2)
        end , 0.2)
        AsyncCall(function ()
            CommonUtil.SetAnchoredPositionY(self.own[pos],"Damage" , 90)
        end , 1.8)
    else
        CommonUtil.SetText(self.enemy[pos],"Damage" ,damage)
        CommonUtil.DOLocalMoveY(self.enemy[pos],"Damage" , 380 , 1.6)
        CommonUtil.DoTextFadeFromTo(self.enemy[pos],"Damage" , 1 , 0 ,1.6)
        CommonUtil.DoImageColor(self.enemy[pos],"Img" ,Color.red, 0.2)
        CommonUtil.DOShake(self.enemy[pos],"Img" , 0.2,10,10)
        AsyncCall(function ()
            CommonUtil.DoImageColor(self.enemy[pos],"Img" ,Color.white, 0.2)
        end , 0.2)
        AsyncCall(function ()
            CommonUtil.SetAnchoredPositionY(self.enemy[pos],"Damage" , 90)
        end , 1.8)
    end
end

function BattleUI:ShowCure(isOwn , pos , cure)
    if isOwn then
        CommonUtil.SetText(self.own[pos],"Cure" ,"+" .. cure)
        CommonUtil.DOLocalMoveY(self.own[pos],"Cure" , 380 , 1.6)
        CommonUtil.DoTextFadeFromTo(self.own[pos],"Cure" , 1 , 0 ,1.6)
        CommonUtil.DoImageColor(self.own[pos],"Img" ,Color.green , 0.2)
        AsyncCall(function ()
            CommonUtil.DoImageColor(self.own[pos],"Img" ,Color.white, 0.2)
        end , 0.2)
        AsyncCall(function ()
            CommonUtil.SetAnchoredPositionY(self.own[pos],"Cure" , 90)
        end , 1.8)
    else
        CommonUtil.SetText(self.enemy[pos],"Cure" ,"+" .. cure)
        CommonUtil.DOLocalMoveY(self.enemy[pos],"Cure" , 380 , 1.6)
        CommonUtil.DoTextFadeFromTo(self.enemy[pos],"Cure" , 1 , 0 ,1.6)
        CommonUtil.DoImageColor(self.enemy[pos],"Img" ,Color.green , 0.2)
        AsyncCall(function ()
            CommonUtil.DoImageColor(self.enemy[pos],"Img" ,Color.white, 0.2)
        end , 0.2)
        AsyncCall(function ()
            CommonUtil.SetAnchoredPositionY(self.enemy[pos],"Cure" , 90)
        end , 1.8)
    end
end

function BattleUI:SetOwnSkillEnable(index , canUse)
    CommonUtil.SetBtnInteractable(self.root,"UI/Own/Skill/" .. index , canUse)
end

function BattleUI:SetOwnSkillAllDisenable()
    for i = 1, 4 do
        CommonUtil.SetBtnInteractable(self.root,"UI/Own/Skill/" .. i , false)
    end
end

function BattleUI:SetSkillSelect(index , skillConfig , ownPos)    
    for i = 1, 4 do
        CommonUtil.SetActive(self.root,"UI/Own/Skill/" .. i .. "/Select",false)
    end
    if index == nil then
        return
    end

    self.selectSkillIndex = index
    CommonUtil.SetActive(self.root,"UI/Own/Skill/" .. index .. "/Select",true)

    self:SetCharSelectedOff()
    if skillConfig.typ == "cure" then
        for key, pos in ipairs(skillConfig.atkPos) do
            if pos == 0 then
                self:SetCharSelect(true , ownPos , "SelectedCure")
            else
                self:SetCharSelect(true , pos , "SelectedCure")
            end
        end
    elseif skillConfig.typ == "atk" then
        -- -- 增加移动后的攻击距离
        -- local atkPos = self.battleManager:GetMoveAtkPos(true , ownPos , skillConfig)
        for key, pos in ipairs(skillConfig.atkPos) do
            if not self.battleManager:GetCharByPos(false , pos).isDead then
                self:SetCharSelect(false , pos , "Selected")
            end
        end
    end
end

function BattleUI:SetCharTempMove(isOwn , nowPos , orderPos)
    if orderPos == nil then
        orderPos = self.battleManager:GetOrderPos(isOwn , nowPos)
    end
    local canMovePos = self.battleManager:GetCharTempMovePos(isOwn , nowPos)
    if #canMovePos == 0 then
        return
    end
    local charData = self.battleManager:GetCharByPos(isOwn , nowPos)
    local configData = ConfigManager:GetConfig("Character")
    local maxHp = configData[charData.uid].hp
    local allPos = {self.own[4],self.own[3],self.own[2],self.own[1],
                   self.enemy[1],self.enemy[2],self.enemy[3],self.enemy[4]}
    for index, pos in ipairs(canMovePos) do
        local player = allPos[pos]
        CommonUtil.SetActive(player,nil,true)
        if pos ~= orderPos then
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
            ImageLoader.SetImage(player,"Img2" ,"Prefab/SpriteAssets/Character/"..charData.prefab)
            CommonUtil.AddButtonClick(player, "SelectedMove", BindFunction(self, self.SetCharTempMove, isOwn , nowPos , pos))
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
            ImageLoader.SetImage(player,"Img" ,"Prefab/SpriteAssets/Character/"..charData.prefab)
            CommonUtil.SetText(player,"HpBar/Text" , charData.hp .. "/" .. maxHp)
            CommonUtil.SetImageFillAmount(player, "HpBar/Image" , charData.hp/maxHp)
        end        
    end
    local camp,newPos = self.battleManager:GetCampPos(orderPos)
    self:SetOwnInfo(charData , newPos)
end

function BattleUI:OnClickUseSkillToChar(uuid)
    self.battleManager:UseSkillToChar(self.selectSkillIndex , uuid)
end

function BattleUI:OnClickMove(charData)
    self:SetSkillSelect()
    if charData.move == 0 then
        ViewUtils.ShowHint("此角色不能移动",1)
        return
    end
    self:ShowMoveSelect(charData)
end

function BattleUI:ShowMoveSelect(charData)
    self:SetCharSelectedOff()
    local pos = charData.pos 
    local step = charData.move
    if step == 1 then
        for i = 1, 3 do
            if i == pos - step or i == pos + step then
                self:SetCharSelect(true , i , "SelectedMove")
            end
        end
    end

    if step == 2 then
        for i = 1, 3 do
            if i ~= pos then
                self:SetCharSelect(true , i , "SelectedMove")
            end
        end
    end
end

function BattleUI:OnSelectMove(moveTo)
    self.battleManager:OwnMove(moveTo)
end

function BattleUI:ExchangeChar(isOwn ,pos1 , pos2)
    if isOwn then
        --播动画
        local position1 = self.own[pos1].transform.position
        local position2 = self.own[pos2].transform.position
        CommonUtil.DOMove(self.own[pos1],nil , position2 , 0.8)
        CommonUtil.DOMove(self.own[pos2],nil , position1 , 0.8)
        --还原
        AsyncCall(function ()
            self.own[pos1].transform.position = position1
            self.own[pos2].transform.position = position2
        end,0.8)
    else
        --播动画
        local localPos1 = self.enemy[pos1].transform.localPosition
        local localPos2 = self.enemy[pos2].transform.localPosition
        CommonUtil.DOLocalMove(self.enemy[pos1],nil , localPos2 , 0.8)
        CommonUtil.DOLocalMove(self.enemy[pos2],nil , localPos1 , 0.8)
        --还原
        AsyncCall(function ()
            self.enemy[pos1].transform.localPosition = localPos1
            self.enemy[pos2].transform.localPosition = localPos2
        end,0.8)
    end
    
end
