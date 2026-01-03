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
            buttonInfos[i].index = CheckSkillType(i, out buttonInfos[i].skillEnumInt, out buttonInfos[i].lv);
        }
    }

    int CheckSkillType(int index, out int theEnumInt, out int theLV)
    {
        var skillInjection = skillInjections[index];
        var skillEnumInt = skillInjection.ChoseSkill(out int WSkillLV);
        if (skillEnumInt == -1)
        {
            for(int i = 0; i < skillInjections.Count; i++)
            {
                if (i == index) continue;
                skillEnumInt = skillInjections[i].ChoseSkill(out WSkillLV);
                if (skillEnumInt != -1)
                {
                    theEnumInt = skillEnumInt;
                    theLV = WSkillLV;
                    return i;
                }
            }
            theEnumInt = -1;
            theLV = WSkillLV;
            return index;
        }
        else
        {
            theEnumInt = skillEnumInt;
            theLV = WSkillLV;
            return index;
        }
    }
}

public struct SkillButtonInfo
{
    internal int index;
    internal int skillEnumInt;
    internal int lv;
}
