--region *.lua
--Date
--此文件由[BabeLua]插件自动生成

HotfixModel = {}
HotfixModel.RESULT_NONE    = 1 -- 无更新
HotfixModel.RESULT_NEW_APP = 2 -- 有新版本
HotfixModel.RESULT_HOTFIX  = 3 -- 有热更新
HotfixModel.RESULT_HIGH_APP  = 4 -- 本地版本高

--https://topgun.pythonera.com:8092/topgun/clientupdate/0/test/

-- 初始化
-- onComplete 检查更新完成回调
function HotfixModel:Init(onComplete, onError)
    self.onComplete = onComplete
    self.onError = onError

    self.latest = nil
    self.remoteList = nil
    self.localList = self:LoadLocalFileList()
    self.rootUrl = nil
    self.verConfig = ConfigManager:GetSysConfig("version")
end

function HotfixModel:CompareVersion(v1, v2)
    local str = HotfixUtil.CompareVersion(v1, v2)
    return tonumber(str)
end

-- 开始检查更新
function HotfixModel:StartCheck()
    self:DownloadLatest(function()
        -- 本地版本
        local localApp = self.verConfig["app"]
        local localRes = self.verConfig["res"]
        -- 服务器版本
        local remoteApp = self.latest["app"]
        local remoteRes = self.latest["res"]

        printf("local app: {0}, res: {1}", localApp, localRes)
        printf("remote app: {0}, res: {1}", remoteApp, remoteRes)

        -- 比较app版本
        local compareApp = self:CompareVersion(remoteApp, localApp)

        -- 服务器版本 > 当前版本，需要下载新安装包
        if compareApp > 0 then
            local url = self.latest["url"]  -- 新版app下载地址
            local hint = self.latest["hint"]    -- 提示信息
            self:OnCheckComplete(HotfixModel.RESULT_NEW_APP, url, hint)
            return
        end

        -- 服务器版本 < 当前版本, 审核模式
        --if compareApp < 0 then
            local compareAppRes = self:CompareVersion(remoteRes, localApp)
            if compareAppRes < 0 then
                local hint = self.latest["nh"]  -- 提示信息
                self:OnCheckComplete(HotfixModel.RESULT_HIGH_APP, hint)
                return
            end
        --end

        -- 比较res版本
        local compareRes = self:CompareVersion(remoteRes, localRes)

        -- 服务器版本 > 当前版本，需要下载更新包
        if compareRes > 0 then
            self:DownloadList(function()
--                if self.remoteList == nil then
--                    self:HandleError("")
--                    return
--                end
                self.downloadList = self:CompareFileList()

                if table.getCount(self.downloadList.list) > 0 then
                    -- 有更新
                    self:OnCheckComplete(HotfixModel.RESULT_HOTFIX, self.downloadList["totalSize"])
                else
                    -- 没有文件要更新
                    self:SyncLocalVersion()
                    self:OnCheckComplete(HotfixModel.RESULT_NONE)
                end
            end)
            return
        end

        -- 服务器版本 < 当前版本，What happened?
        if compareRes < 0 then
            print("remote res < local res")
            self:OnCheckComplete(HotfixModel.RESULT_NONE)
            return
        end

        -- 无更新
        self:OnCheckComplete(HotfixModel.RESULT_NONE)
    end)
end

function HotfixModel:HandleError(err)
    if self.onError ~= nil then
        return self.onError(err)
    end
    return false
end

function HotfixModel:OnCheckComplete(resultCode, ...)
    SafeCall(self.onComplete, resultCode, ...)
end

-- 同步res版本到更新目录
function HotfixModel:SyncLocalVersion()
    self.verConfig["res"] = self.latest["res"]
    
    GameUtil.SavePersistentData("update/SysConfig/version.json", CJson.encode(self.verConfig))
    GameUtil.CheckEncryptState()
    if GameUtil.PersistantEncrypted then
        GameUtil.EncryptPersistentFile("update/SysConfig/version.json")
    end
end

-- 开始下载更新包
function HotfixModel:StartDownloadHotfix(onProgress, onFinished)
    local json = CJson.encode(self.downloadList)

    local downloader = HotfixDownloader.CreateInstance()
    downloader.maxDownloadThread = 3
    downloader.validateMD5 = true
    downloader.streamFragmentSize = 1024 * 256
    downloader.downloadToTemp = true
    downloader.completeOperation = HotfixDownloader.OPERATION_UNLOAD_AND_REENTER

    downloader.onProgress = onProgress
    downloader.onFinished = function(success)
        if success then
            self:SyncLocalVersion()
        end
        SafeCall(onFinished, success)
    end

    downloader:Init(json)
    downloader:StartDownload()
end

-- 下载latest.json
function HotfixModel:DownloadLatest(callback)
    local url = GameInfo:GetHotfixUrl()
    HttpHandler:Get(url, function(result)
        self.latest = CJson.decode(CommonUtil.Trim(result))

        if CommonUtil.IsIOS() then
            self.rootUrl = self.latest["ir"]
        else
            self.rootUrl = self.latest["ar"]
        end

        SafeCall(callback)
    end, function(err)
        return self:HandleError(err)
    end, ConfigManager:GetText("hint_check_update"))
end

-- 下载list.json
function HotfixModel:DownloadList(callback)
    local url = CombineUrl(self.rootUrl, "list.json")

    HttpHandler:Get(url, function(result)
        self.remoteList = CJson.decode(CommonUtil.Trim(result))
        SafeCall(callback)
    end, function(err)
        return self:HandleError(err)
    end, ConfigManager:GetText("hint_check_update"))
end

-- 加载本地list.json
function HotfixModel:LoadLocalFileList()
    local text = GameUtil.LoadText("list.json")
    if not IsNilOrEmptyStr(text) then
        return CJson.decode(text)
    end
    return nil
end

-- 对比文件列表，并生成下载列表
function HotfixModel:CompareFileList()
    local downloadList = {}
    downloadList.totalSize = 0
    downloadList.list = {}
    downloadList.listJson = CJson.encode(self.remoteList)

    for path, remoteFile in pairs(self.remoteList["list"]) do 
        local localFile = self:GetLocalFile(path)

        -- 是新文件，或者版本号更新
        if localFile == nil or remoteFile["version"] > localFile["version"] or self:DownloadAnyway(path) then
            table.insert(downloadList.list, self:CreateDownloadInfo(path, remoteFile))
            downloadList.totalSize = downloadList.totalSize + remoteFile.size
        end
    end

    printf("Changed files: {0}", table.getCount(downloadList.list))
    return downloadList
end

-- 是否强行更新
function HotfixModel:DownloadAnyway(path)
    return EndsWith(path, "encrypt.txt")
end

function HotfixModel:GetLocalFile(path)
    return self.localList["list"][path]
end

-- 生成下载信息
function HotfixModel:CreateDownloadInfo(path, file)
    local data = {}
    data.index = i
    data.url = CombineUrl(self.rootUrl, path)
    data.md5 = file.md5
    data.size = file.size
    data.path = path
    data.savePath = GameUtil.GetUpdatePath(path)
    return data
end



--endregion
