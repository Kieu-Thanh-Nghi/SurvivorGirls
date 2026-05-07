using UnityEngine;

[CreateAssetMenu(fileName = "WeaponInfo", menuName = "ScriptableObjects/WeaponInfo")]
public class WeaponConcreteInfo : ScriptableObject
{
    [SerializeField] internal string weaponName;
    [SerializeField] internal int startDamage;
    [SerializeField] internal int damageBonusEachLvl;
    [SerializeField] internal WeaponSkillInfos skillInfosPrefab;
    [SerializeField] internal float Range, Reload;
    [SerializeField] internal int FireRate, MaxAmmo;
    [SerializeField] int[] rankupPriceEachRank;
    [SerializeField] internal int weaponMaxRank = 2;

    public int GetTotalDamage(int theLvl)
    {
        return startDamage + (theLvl - 1) * damageBonusEachLvl;
    }

    public int GetRankupPriceForNextRank(int currentRank)
    {
        if (currentRank >= rankupPriceEachRank.Length)
        {
            Debug.Log("nhap sai rank");
            return -1;
        }
        else
        {
            return rankupPriceEachRank[currentRank];
        }
    }
}
