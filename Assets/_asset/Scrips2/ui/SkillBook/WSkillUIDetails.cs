using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WSkillUIDetails : MonoBehaviour
{
    [SerializeField] Image frame, skillIcon, rankIcon;
    [SerializeField] TMP_Text skillName, skillDescribe;
    [SerializeField] Transform detailsContainer;

    public void SetDetails(WSkillUIInfos wSkillInfo)
    {
        var skill_rank = (int)wSkillInfo.theRank;
        frame.sprite = UIDatas.Instance.Frame_wskillicons[skill_rank];
        rankIcon.sprite = UIDatas.Instance.rankIcon[skill_rank];
        skillIcon.sprite = wSkillInfo.skill_icon;
        skillName.text = wSkillInfo.name;
        skillDescribe.text = wSkillInfo.describe;

        Instantiate(wSkillInfo.skillDetailsPrefab, detailsContainer);
    }

    private void OnDisable()
    {
        var detail = detailsContainer.GetChild(0);
        if (detail != null)
        {
            Destroy(detail.gameObject);
        }
    }
}
