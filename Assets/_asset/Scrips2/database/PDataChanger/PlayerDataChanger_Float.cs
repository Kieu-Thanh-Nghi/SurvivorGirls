using UnityEngine;

public class PlayerDataChanger_Float : PlayerDataChanger
{
    [SerializeField] FloatPlayerData pData;
    [SerializeField] float bonusValue; 
    public override void ChangeData(bool isMinus = false)
    {
        if (isMinus)
        {
            Database.instance.playerData[pData] -= bonusValue;
        }
        else
        {
            Database.instance.playerData[pData] += bonusValue;
        }
    }
}
