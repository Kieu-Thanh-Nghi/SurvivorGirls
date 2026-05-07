using UnityEngine;

[System.Serializable]
public class EquipmentBonusPoint_Float : EquipmentBonusPoint<FloatPlayerData, float>
{
    public override void IncreasePlayerData(int currentLvl)
    {
        Database.instance.playerData[dataType] += CalculateRealBonusValue(currentLvl);
    }

    public override void DecreasePlayerData(int currentLvl)
    {
        Database.instance.playerData[dataType] -= CalculateRealBonusValue(currentLvl);
    }

    public override ItemBonusInfo GetAndSetBonusInfo(int currentLvl)
    {
        var bonusInfo = Object.Instantiate(UIDatas.Instance.equipSpecs.GetInfoStatus(dataType));
        bonusInfo.SetBonusPoint(CalculateRealBonusValue(currentLvl));
        return bonusInfo;
    }

    public override float CalculateRealBonusValue(int currentLvl)
    {
        var bonusVal = startValue + bonusEachLvl * Mathf.FloorToInt((currentLvl + startStep - 1) / eachLvls);
        return bonusVal;
    }
}
