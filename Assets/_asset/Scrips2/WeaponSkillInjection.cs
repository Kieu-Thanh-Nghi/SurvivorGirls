using UnityEngine;

public class WeaponSkillInjection : SkillInjection
{
    [SerializeField] internal WeaponData weaponData;
    internal int weaponRank;

    protected virtual void OnEnable()
    {
        var info = Database.instance.playerItems.weaponData.GetEpuippingWeaponInfo();
        PlayerDataManager.Instance.weaponType = weaponData.WeaponType;
    }
    protected override void Start()
    {
        skillQuantity = weaponRank + 1;
        skillIndex.Clear();
        foreach(var skill in skillList)
        {
            int enumInt = skill.thisEnumInt;
            if (skill.thisEnumInt <= weaponRank)
            {
                skillIndex.Add(enumInt);
            }
        }
        base.Start();
    }
    public virtual void WeaponSetUp(AllWeaponMuzzle weaponMuzzles = null)
    {
    }
}
