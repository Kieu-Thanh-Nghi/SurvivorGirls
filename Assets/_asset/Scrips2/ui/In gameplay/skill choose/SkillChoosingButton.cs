using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillChoosingButton : MonoBehaviour
{
    [SerializeField] AlternativeButton alternative;
    [SerializeField] TMP_Text skillName;
    [SerializeField] Image titleBg;
    [SerializeField] Image skillIcon;
    [SerializeField] GameObject[] star_lvl;
    [SerializeField] Transform starsContainer;
    [SerializeField] TMP_Text skillDescribe;

    public void SetButton(string skill_name, Color skillTypeColor, Sprite skill_icon,
        int skill_lvl, string skill_describe)
    {
        skillName.text = skill_name;
        titleBg.color = skillTypeColor;
        skillIcon.sprite = skill_icon;
        int n = star_lvl.Length;

        for (int i = 0; i < n; i++)
        {
            if(i < skill_lvl)
            {
                star_lvl[i].SetActive(true);
            }
            else
            {
                star_lvl[i].SetActive(false);
            }
        }

        skillDescribe.text = skill_describe;
    }

    public void TurnOnAlternative()
    {
        alternative.SetupThis();
        alternative.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        alternative.gameObject.SetActive(false);
    }
}
