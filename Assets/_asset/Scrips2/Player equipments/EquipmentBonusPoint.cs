using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public abstract class EquipmentBonusPoint<T,K> : IBonusPoint
    where T : System.Enum
    where K : struct
{
    [SerializeField] internal int eachLvls, startStep;
    [SerializeField] internal T dataType;
    [SerializeField] internal K startValue;
    [SerializeField] internal K bonusEachLvl;

    public abstract void IncreasePlayerData(int currentLvl);
    public abstract void DecreasePlayerData(int currentLvl);
    public abstract K CalculateRealBonusValue(int currentLvl);
    public abstract ItemBonusInfo GetAndSetBonusInfo(int currentLvl);
}

public interface IBonusPoint
{
    public void IncreasePlayerData(int currentLvl);
    public void DecreasePlayerData(int currentLvl);
    public ItemBonusInfo GetAndSetBonusInfo(int currentLvl);  
}
