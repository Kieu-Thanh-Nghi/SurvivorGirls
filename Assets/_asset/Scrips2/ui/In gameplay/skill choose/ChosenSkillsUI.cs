using System.Collections.Generic;
using UnityEngine;

public class ChosenSkillsUI : MonoBehaviour
{
    [SerializeField] List<ChosenSkillUI> chosenSkillUIs;
    int skillQuantity = 0;
    public void SetSkillIn(int skill_index, int lv, Sprite skill_icon)
    {
        if(lv > 1)
        {
            foreach(var skillUI in chosenSkillUIs)
            {
                if(skillUI.skill_index == skill_index)
                {
                    skillUI.UpgradeASkill(lv);
                    break;
                }
            }
        }
        else
        {
            if(skillQuantity >= chosenSkillUIs.Count)
            {
                Debug.Log("so lg skill vuot qua o chua");
                return;
            }
            chosenSkillUIs[skillQuantity].SetNewSkill(skill_index, skill_icon);
            skillQuantity++;
        }
    }

}
