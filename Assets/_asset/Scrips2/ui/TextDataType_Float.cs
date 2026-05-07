using UnityEngine;

public class TextDataType_Float : TextDataType
{
    [SerializeField] FloatPlayerData data;
    public override string GetStringData()
    {
        return Database.instance.playerData[data].ToString()+"%";
    }
}