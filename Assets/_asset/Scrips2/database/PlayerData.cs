using UnityEngine;
using System.Collections.Generic;

public class PlayerData : MonoBehaviour
{
    [SerializeField] int[] IntAttribute;
    [SerializeField] float[] floatAttribute;

    private void OnValidate()
    {
        IntAttribute = new int[(int)IntPlayerData.endIndex];
        floatAttribute = new float[(int)FloatPlayerData.endIndex];
    }
    public int this[IntPlayerData data]
    {
        get => IntAttribute[(int)data];
        set => IntAttribute[(int)data] = value;
    }
    public float this[FloatPlayerData data]
    {
        get => floatAttribute[(int)data];
        set => floatAttribute[(int)data] = value;
    }
}
public enum IntPlayerData
{
    Hp = 0,
    Atk = 1,
    MoveSpeed = 2,
    endIndex = 3
}

public enum FloatPlayerData
{
    Heal = 0, CritChance = 1, CritDmg = 2, MeleeBonus = 3,
    GunBonusAtk = 4, ElementBoost = 5, ElementReg = 6,
    endIndex = 7
}

