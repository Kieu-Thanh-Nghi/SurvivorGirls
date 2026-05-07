using System.Collections.Generic;
using UnityEngine;

public class AllChosenSkillsUI : MonoBehaviour
{
    [SerializeField] List<ChosenSkillsUI> chosenSkillsUIs;

    public void SetSkillIn(SkillImportantData skillImportantData)
    {
        int skill_type = skillImportantData.index;
        int skill_index = skillImportantData.skillEnumInt;
        Sprite skill_icon = skillImportantData.skillInfos.skill_icon;
        chosenSkillsUIs[skill_type].SetSkillIn(skill_index, skillImportantData.lv, skill_icon);
    }
}