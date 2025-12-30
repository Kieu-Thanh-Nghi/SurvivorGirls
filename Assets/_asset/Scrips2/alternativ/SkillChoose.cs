using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillChoose : MonoBehaviour
{
    [SerializeField] WeaponInjection weaponInjection;
    [SerializeField] ActiveSkillInjection activeSkillInjection;
    [SerializeField] PassiveSkillInjection passiveSkillInjection;
    [SerializeField] List<SkillInjection> skillInjections;

    SkillButtonInfo[] buttonInfos = new SkillButtonInfo[3];

    private void OnEnable()
    {
        foreach(var si in skillInjections)
        {
            si.selectedTimes = 0;
        }
        for(int i = 0; i < buttonInfos.Length; i++)
        {
            buttonInfos[i].index = CheckSkillType(i, out buttonInfos[i].skillEnum, out buttonInfos[i].lv);
        }
    }

    int CheckSkillType(int index, out SkillEnum theEnum, out int theLV)
    {
        var skillInjection = skillInjections[index];
        var skillEnum = skillInjection.ChoseSkill(out int WSkillLV);
        if (skillEnum == SkillEnum.NoneSkill)
        {
            for(int i = 0; i < skillInjections.Count; i++)
            {
                if (i == index) continue;
                skillEnum = skillInjections[i].ChoseSkill(out WSkillLV);
                if (skillEnum != SkillEnum.NoneSkill)
                {
                    theEnum = skillEnum;
                    theLV = WSkillLV;
                    return i;
                }
            }
            theEnum = SkillEnum.NoneSkill;
            theLV = WSkillLV;
            return index;
        }
        else
        {
            theEnum = skillEnum;
            theLV = WSkillLV;
            return index;
        }
    }
}

public struct SkillButtonInfo
{
    internal int index;
    internal SkillEnum skillEnum;
    internal int lv;
}
