BattleUI = {}
BattleUI.__index = BattleUI
setmetatable(BattleUI, ViewBase)

BattleUI.instance = nil

function BattleUI:Create()
    local copy = ViewBase:Create({canClose = false})
    setmetatable(copy, self)

    copy:Init()

    return copy
end

function BattleUI:Init()
    self.root = self:Add("Prefab/UI/Battle/BattleUI")
end

function BattleUI:OnClickButton()

end