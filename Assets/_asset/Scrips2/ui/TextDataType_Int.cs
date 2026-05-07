using UnityEngine;

public class TextDataType_Int : TextDataType
{
    [SerializeField] IntPlayerData data;
    public override string GetStringData() => Database.instance.playerData[data].ToString();
}
