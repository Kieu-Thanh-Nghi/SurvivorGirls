using UnityEngine;
using UnityEngine.UI;

public class ChosenSkillUI : MonoBehaviour
{
    [SerializeField] Image skillIcon;
    [SerializeField] GameObject[] LvlStar;
    internal int skill_index = -1;

    public void SetNewSkill(int newSkill_index, Sprite skill_icon)
    {
        skillIcon.sprite = skill_icon;
        skillIcon.gameObject.SetActive(true);
        skill_index = newSkill_index;
        LvlStar[0].SetActive(true);
    }

    public void UpgradeASkill(int newLv)
    {
        for (int i = 0; i < newLv; i++)
        {
            LvlStar[i].SetActive(true);
        }
    }
}
