using System.Collections.Generic;
using UnityEngine;

public class PistolSkillsInjection : WeaponSkillInjection
{
    [SerializeField] internal PlayerPistolAttack pistolGunAttack;

    //internal PistolFirstSkill firstSkill;
    //internal PistolSecondSkill secondSkill;
    internal PistolSkill_Third thirdSkill;
    List<int> tempList = new();

    protected override void Start()
    {
        base.Start();
        thirdSkill = skillList[(int)PistolSkillEnum.Magnum] as PistolSkill_Third;
    }

    protected override int CalculateChosenSkill(int n, List<int> theList, out int skillLvl)
    {
        thirdSkill = skillList[(int)PistolSkillEnum.Magnum] as PistolSkill_Third;
        tempList.Clear();
        tempList.AddRange(theList);

        if (!thirdSkill.CheckIfOK(skillList[(int)PistolSkillEnum.SixthSense] as PistolSkill_Second))
        {
            tempList.Remove((int)PistolSkillEnum.Magnum);
        }

        return base.CalculateChosenSkill(tempList.Count, tempList, out skillLvl);
    }

    [ContextMenu("inject skill1")]
    void test1()
    {
        UpgradeASkill((int)PistolSkillEnum.Training);
    }
    [ContextMenu("inject skill2")]
    void test2()
    {
        UpgradeASkill((int)PistolSkillEnum.SixthSense);
    }
    [ContextMenu("inject skill3")]
    void test3()
    {
        UpgradeASkill((int)PistolSkillEnum.Magnum);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        //pistolMuzzle?.parent.gameObject.SetActive(false);
    }
}