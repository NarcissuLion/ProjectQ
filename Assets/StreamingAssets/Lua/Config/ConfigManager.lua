--region *.lua
--Date
--此文件由[BabeLua]插件自动生成

ConfigManager = {}

local files = {
	"TestBattle",
    "Character"
}

local sysFiles = {
	"game",
	"version"
}

function ConfigManager:Init()
    if self.init == true then
        return
    end

    self.configs = {}
    self.sysConfigs = {}

    for i, file in ipairs(files) do
        self:LoadConfig("Config", file, self.configs)
    end
    for i, file in ipairs(sysFiles) do
        self:LoadConfig("SysConfig", file, self.sysConfigs)
    end

    self.textConfig = CS.ConfigManager.GetTextConfig()
    self.cache = {}
    self.init = true

    local gameConfig = self:GetSysConfig("game")
    self.region = gameConfig["region"]
end

function ConfigManager:Clear()
    self.configs = {}
    self.sysConfigs = {}
    self.cache = {}
    self.init = false
end

function ConfigManager:LoadConfig(path, fileName, configs)
    local text = GameUtil.LoadDecryptTextAndTrim(string.format("%s/%s.json", path, fileName))
    if text == nil then
        printfError("Config not found: {0}", fileName)
        return nil
    end

    local json = RapidJson.decode(text)
    if json == nil then
        printfError("Config isn't json: {0}", fileName)
        return nil
    end
    configs[fileName] = json

    return json
end

function ConfigManager:GetConfig(name, loadIfNonExist)
    local config = self.configs[name]
    if config == nil and loadIfNonExist then
        config = self:LoadConfig("Config", name, self.configs)
    end
    if config == nil then
        print("Config not found:".. name)
    end
    return config
end

function ConfigManager:GetSysConfig(name, loadIfNonExist)
    local config = self.sysConfigs[name]
    if config == nil and loadIfNonExist then
        config = self:LoadConfig("SysConfig", name, self.sysConfigs)
    end
    if config == nil then
        print("Config not found:".. name)
    end
    return config
end

function ConfigManager:GetText(key, ignoreEmpty)
    if key == nil then
        printError("Text key in nil")
        return ""
    end

    local text = nil
    if self.textConfig ~= nil then
        text = self.textConfig:Get(key)
    end

    if text ~= nil then
        return text
    elseif ignoreEmpty == true then
        return ""
    else
        return key
    end
end

function ConfigManager:GetNameText(key)
    if key == nil then
        printError("text key is nil")
        return "None"
    end
    return self:GetText("name_" .. key)
end

function ConfigManager:GetDescText(key)
    if key == nil then
        printError("text key is nil")
        return "None"
    end
    return self:GetText("desc_" .. key)
end

function ConfigManager:GetFormatText(key, ...)
    local text = self:GetText(key)
    if text ~= nil then
        local args = {...}
        for i = 1, select("#", ...) do
            if args[i] == nil then
                args[i] = "Null"
            end
        end

        return CommonUtil.FormatText(text, unpack(args))
    end
    return key
end


--endregion
