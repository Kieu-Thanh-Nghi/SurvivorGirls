using System;
using System.Collections.Generic;
using UnityEngine;

public class UIDatas : MonoBehaviour
{
    [SerializeField] internal EquipFrame equipFramePrefab;
    [SerializeField] internal List<Sprite> CurrencyIcon;
    [SerializeField] internal List<Sprite> rankBg;
    [SerializeField] internal List<Sprite> rankIcon;
    [SerializeField] internal List<Sprite> rankFrame;
    [SerializeField] internal List<Sprite> rankWeaponBGs;
    [SerializeField] internal List<Sprite> Frame_wskillicons;
    [SerializeField] internal List<int> equipmentMaxLvEachRank;
    [SerializeField] internal List<EquipIconsByType> equipIconsList;
    [SerializeField] internal EquipSpecsInfo equipSpecs;
    public static UIDatas Instance;
    private void Awake()
    {
        Instance = this;
    }
}

[Serializable]
public class EquipIconsByType
{
    [SerializeField] internal List<Sprite> icons;
}

[Serializable]
public class EquipSpecsInfo
{
    [SerializeField] ItemBonusInfo[] InfoStatusPrefab_Int;
    [SerializeField] ItemBonusInfo[] InfoStatusPrefab_Float;
    [SerializeField] internal List<EquipContextList> EquipContexLists;
    [SerializeField] internal List<QualitySkillInfo> qualitySkillInfos;

    public QualitySkillInfo CreateQualitySkillInfo(EquipMat mat, Transform qualitySkillSlot)
    {
        var qualitySkillPrefab = qualitySkillInfos[(int)mat];
        var qualitySkill = UnityEngine.Object.Instantiate(qualitySkillPrefab, qualitySkillSlot);
        return qualitySkill;
    }
    public EquipmentContex CreateEquipContext(TypeOfEquipment type, EquipMat mat, Transform contexSlot)
    {
        var contexPrefab = EquipContexLists[(int)mat].equipContexes[(int)type];
        var contex = UnityEngine.Object.Instantiate(contexPrefab, contexSlot);
        return contex;
    }
    public ItemBonusInfo GetInfoStatus(IntPlayerData intPlayerData)
    {
        return InfoStatusPrefab_Int[(int)intPlayerData];
    }
    public ItemBonusInfo GetInfoStatus(FloatPlayerData floatPlayerData)
    {
        return InfoStatusPrefab_Float[(int)floatPlayerData];
    }
}

[Serializable]
public class EquipContextList
{
    [SerializeField] internal List<EquipmentContex> equipContexes;
}