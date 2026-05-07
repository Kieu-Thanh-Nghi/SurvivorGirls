using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    internal static PlayerDataManager Instance;

    internal int weaponType = 0;
    [SerializeField] PlayerData playerData;
    [SerializeField] internal float _moveSpeedScale = 1;
    [SerializeField] internal float _objectSpeedScale = 1;
    [SerializeField] internal float _areaRadiusScale = 1;
    [SerializeField] internal float _ASCoolDownScale = 1;
    [SerializeField] internal float _activeDuration = 1;
    [SerializeField] internal float _gotExpScale = 1;
    [SerializeField] internal float _damageScale = 1;
    [SerializeField] internal float _reloadTime = 1;
    [SerializeField] internal float _reloadPadding = 0;

    private void Awake()
    {
        Debug.Log("pdm");
        Instance = this;
    }

    private void OnDisable()
    {
        _moveSpeedScale = 1;
        _objectSpeedScale = 1;
        _areaRadiusScale = 1;
        _ASCoolDownScale = 1;
        _activeDuration = 1;
        _gotExpScale = 1;
        _damageScale = 1;
        _reloadTime = 1;
        _reloadPadding = 0;
}

    public float ElementBoost => playerData[FloatPlayerData.ElementBoost] * 0.01f;
    public float ElementReg => playerData[FloatPlayerData.ElementReg] * 0.01f;
    public int PlayerHealAmount()
    {
        return Mathf.CeilToInt(playerData[FloatPlayerData.Heal] * 0.01f * PlayerMaxHp);
    }
    public int PlayerMaxHp
    {
        get
        {
            Debug.Log(playerData == null);
            Debug.Log(playerData[IntPlayerData.Hp]);
            return playerData[IntPlayerData.Hp];
        }
    }
    float bonusDamage
    {
        get
        {
            if(weaponType == 0)
            {
                return playerData[FloatPlayerData.GunBonusAtk];
            }
            else
            {
                return playerData[FloatPlayerData.MeleeBonus];
            }
        }
    }
    internal float MoveSpeed => playerData[IntPlayerData.MoveSpeed] * _moveSpeedScale * 0.01f;
    internal int CalculateDamage(out DamageType damageType)
    {
        var atk = playerData[IntPlayerData.Atk];
        float critDame = 0;
        var critChance = playerData[FloatPlayerData.CritChance];

        bool isCrit = false;
        if(Random.Range(1, 101) <= critChance)
        {
            isCrit = true;
        }

        if (isCrit)
        {
            critDame = playerData[FloatPlayerData.CritDmg];
            damageType = DamageType.Crit;
        }
        else
        {
            damageType = DamageType.Normal;
        }

        float bonusAtk = atk * bonusDamage * 0.01f;

        return Mathf.CeilToInt((atk + bonusAtk) * _damageScale * (1 + critDame * 0.01f));
    }
}