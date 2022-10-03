--region *.lua
--Date
--此文件由[BabeLua]插件自动生成
TestUI = {}
TestUI.__index = TestUI
setmetatable(TestUI, ViewBase)

TestUI.instance = nil

function TestUI:Create()
    local copy = ViewBase:Create()
    setmetatable(copy, self)

    copy:Init()

    return copy
end

function TestUI:Init()
    self.root = self:Add("Prefab/TestUI")

    CommonUtil.AddButtonClick(self.root, "Button", BindFunction(self, self.OnClickButton, "abc"))
end

function TestUI:OnClickButton(str)
--    print(str)

    CS.HotfixUtil.ReloadGameFromLua();
end

--endregion
