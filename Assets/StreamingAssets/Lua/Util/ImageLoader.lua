---
--- Generated by EmmyLua(https://github.com/EmmyLua)
--- Created by Lion.
--- DateTime: 2019/4/22 20:54
---
ImageLoader = {}

-- 加载Sprite
function ImageLoader.LoadSprite(name)
    local sprite = GameUtil.LoadPrefabSprite(name)
    if sprite == nil then
        printf("Image load fail, name: {0}", name)
    end
    return sprite
end

-- 同步设置Image
function ImageLoader.SetImage(parent, path, name)
    local sprite = GameUtil.LoadPrefabSprite(name)
    if sprite == nil then
        print("Image load fail, name: ".. name)
    else
        CommonUtil.SetImage(parent, path , sprite)
    end
end

-- 设置多语言图片
function ImageLoader.SetRegionImage(parent, path, name)
    local region = ConfigManager:GetRegion()
    local suffix = ""
    if region == Const.LANGUAGE_CN then
        suffix = "cn"
    elseif region == Const.LANGUAGE_EN then
        suffix = "en"
    elseif region == Const.LANGUAGE_JP then
        suffix = "jp"
    elseif region == Const.LANGUAGE_KR then
        suffix = "kr"
    end
    local sprite = GameUtil.LoadPrefabSprite(name.. "_" .. suffix)
    if sprite == nil then
        print("Image load fail, name: ".. name.. "_" .. suffix)
    else
        CommonUtil.SetImage(parent, path , sprite)
    end
end

-- 设置奖励图片 金币，钻石，体力
function ImageLoader.SetRewardImage(parent, path, id)
    local config = ConfigManager:GetConfig("Currency")[id]
    ImageLoader.SetImage(parent, path, config.image)
end

function ImageLoader.SetJobImage(parent, path, breeds , jobId , isSetColor)
    local breedsIndex = CatModel.GetBreedsIndex(breeds)
    local jobImageName = JobModel.GetJobImageName(jobId)
    ImageLoader.SetImage(parent, path, jobImageName..breedsIndex)
    if isSetColor then
        local have = JobModel.HaveThisJob(jobId , breeds)
        if have then
            CommonUtil.SetImageColor(parent, path, Color(1,1,1,1))
        else
            CommonUtil.SetImageColor(parent, path, Const.COLOR_BLACK)
        end
    end
end

function ImageLoader.SetSubjectIcon(parent, path, effectId)
    local name = LessonMode.GetSubjectImageName(effectId)
    ImageLoader.SetImage(parent, path, name)
end