using System.Collections.Generic;
using UnityEngine;

public class KatanaSkillsInjection : WeaponSkillInjection
{
    [SerializeField] internal Projectile SwordSlashSample;
    [SerializeField] internal KatanaSlash RootSlash;
    [SerializeField] MeleWeaponInjector meleWeaponInjector;
    internal AttackSystem atkSystem => meleWeaponInjector.atkSystem;
    List<int> tempList = new();

    protected override void Start()
    {
        base.Start();
    }

    protected override int CalculateChosenSkill(int n, List<int> theList, out int skillLvl)
    {
        tempList.Clear();
        tempList.AddRange(theList);
        return base.CalculateChosenSkill(tempList.Count, tempList, out skillLvl);
    }

    [ContextMenu("inject skill1")]
    void test1()
    {
        UpgradeASkill((int)KatanaSkillEnum.Slash);
    }
    [ContextMenu("inject skill2")]
    void test2()
    {
        UpgradeASkill((int)KatanaSkillEnum.BulletCut);
    }
    [ContextMenu("inject skill3")]
    void test3()
    {
        UpgradeASkill((int)KatanaSkillEnum.Deflect);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        //pistolMuzzle?.parent.gameObject.SetActive(false);
    }
}
public abstract class KatanaSkill : Skill
{
    [SerializeField] protected KatanaSkillsInjection katanaSI;
    public override void SetSkillInjection(ISkillInjection skillInjection)
    {
        if (skillInjection is KatanaSkillsInjection theKatanaSI)
        {
            katanaSI = theKatanaSI;
        }
    }
}

public enum KatanaSkillEnum
{
    NoneSkill = -1,
    //
    Slash = 0,
    BulletCut = 1,
    Deflect = 2,
}