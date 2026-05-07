using UnityEngine;
using TMPro;

public class QualitySkillDetail : MonoBehaviour
{
    [SerializeField] internal ItemRank rank;
    [SerializeField] Color ActiveColor;
    [SerializeField] internal TMP_Text skillContent;
    [SerializeField] GameObject onIcon, lockIcon;

    public void SetQSkill(ItemRank theRank)
    {
        if(theRank >= rank)
        {
            skillContent.color = ActiveColor;
            onIcon.SetActive(true);
            lockIcon.SetActive(false);
        }
        else
        {
            onIcon.SetActive(false);
            lockIcon.SetActive(true);
        }
    }
}
