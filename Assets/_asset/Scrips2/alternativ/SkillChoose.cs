using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class SkillChoose : MonoBehaviour
{
    [SerializeField] List<SkillInjection> skillInjections = new();
    [SerializeField] List<SkillChoosingButton> buttons;

    SkillImportantData[] buttonInfos = new SkillImportantData[3];
    [SerializeField] Color[] skill_color;
    [SerializeField] UnityEvent<SkillImportantData> OnDoneChoosing;

    private void Awake()
    {
        skillInjections.Clear();
        skillInjections.Add(PlayerSetup.instance.weaponInjection);
        skillInjections.Add(PlayerSetup.instance.activeSkillInjection);
        skillInjections.Add(PlayerSetup.instance.passiveSkillInjection);
    }

    private void OnEnable()
    {
        foreach (var si in skillInjections)
        {
            si.selectedTimes = 0;
        }
        for(int i = 0; i < buttonInfos.Length; i++)
        {
            buttonInfos[i].index = CheckSkillType(i, out buttonInfos[i].skillEnumInt, out buttonInfos[i].lv);
            var skillInfo = skillInjections[buttonInfos[i].index].GetSkillInfos(buttonInfos[i].skillEnumInt);
            buttonInfos[i].skillInfos = skillInfo;
            SetSkillChoosingButton(buttons[i], buttonInfos[i].lv, buttonInfos[i].index, skillInfo);
        }
    }
    void SetSkillChoosingButton(SkillChoosingButton theButton, int lv, int skillType_index, SkillInfos skillInfos)
    {
        if(skillInfos == null)
        {
            theButton.TurnOnAlternative();
            return;
        }
        string skill_name = skillInfos.name;
        Sprite skillIcon = skillInfos.skill_icon;
        string skill_describe = skillInfos.skillDetails.GetSkillDetail(lv - 1);
        Color color = skill_color[skillType_index];
        theButton.SetButton(skill_name, color, skillIcon, lv, skill_describe);
    }

    int CheckSkillType(int skillTypeIndex, out int theEnumInt, out int theLV)
    {
        var skillInjection = skillInjections[skillTypeIndex];
        var skillEnumInt = skillInjection.ChoseSkill(out int WSkillLV);
        if (skillEnumInt == -1)
        {
            for (int i = 0; i < skillInjections.Count; i++)
            {
                if (i == skillTypeIndex) continue;
                skillEnumInt = skillInjections[i].ChoseSkill(out WSkillLV);
                if (skillEnumInt != -1)
                {
                    theEnumInt = skillEnumInt;
                    theLV = WSkillLV + 1;
                    return i;
                }
            }
            theEnumInt = -1;
            theLV = WSkillLV + 1;
            return skillTypeIndex;
        }
        else
        {
            theEnumInt = skillEnumInt;
            theLV = WSkillLV + 1;
            return skillTypeIndex;
        }
    }


    public void UpgradeSkillButton(int i)
    {
        skillInjections[buttonInfos[i].index].UpgradeASkill(buttonInfos[i].skillEnumInt);
        OnDoneChoosing?.Invoke(buttonInfos[i]);
        PlayerSetup.instance.levelManager.SetIsDoneChoosing(true);
    }
    public void DoneChoosing()
    {
        PlayerSetup.instance.levelManager.SetIsDoneChoosing(true);
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        GamePlayCtrler.Instance.IsPause = false;
    }
}

public struct SkillImportantData
{
    internal int index;
    internal int skillEnumInt;
    internal int lv;
    internal SkillInfos skillInfos;
}
