using UnityEngine;

public class PlayerDataChanger_Int : PlayerDataChanger
{
    [SerializeField] IntPlayerData pData;
    [SerializeField] int bonusValue; 
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
