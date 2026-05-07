using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QualitySkillInfo : MonoBehaviour
{
    [SerializeField] internal List<QualitySkillDetail> details;

    public void SetQSkillInfo(ItemRank theRank)
    {
        foreach(var detail in details)
        {
            detail.SetQSkill(theRank);
        }
    }

    public string GetSkillDetail(int theRank_Int)
    {
        foreach (var detail in details)
        {
            if ((int)detail.rank == theRank_Int)
            {
                return detail.skillContent.text;
            }
        }
        return "";
    }
}
