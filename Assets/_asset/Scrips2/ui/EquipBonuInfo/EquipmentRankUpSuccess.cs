using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EquipmentRankUpSuccess : MonoBehaviour
{
    [SerializeField] Image equipmentIcon;
    [SerializeField] Image newRankIcon;
    [SerializeField] TMP_Text maxLvlFrom, maxLvlTo;
    [SerializeField] TMP_Text skillDetail;
    [SerializeField] GameObject skillDetailHeader;

    public void ShowRankUpSuccess(ItemRank newRank, 
        Sprite ItemIcon, 
        string lvlFrom, 
        string lvlTo,
        string theSkillDetail)
    {
        equipmentIcon.sprite = ItemIcon;
        newRankIcon.sprite = UIDatas.Instance.rankIcon[(int)newRank];
        maxLvlFrom.text = lvlFrom;
        maxLvlTo.text = lvlTo;
        gameObject.SetActive(true);
        Invoke(nameof(TurnThisOff), 3);
        SetEquipDetail(theSkillDetail);
    }

    void SetEquipDetail(string theSkillDetail)
    {
        if(theSkillDetail.CompareTo("") == 0)
        {
            skillDetail.gameObject.SetActive(false);
            skillDetailHeader.SetActive(false);
        }
        else
        {
            skillDetail.text = theSkillDetail;
            skillDetail.gameObject.SetActive(true);
            skillDetailHeader.SetActive(true);
        }
    }

    void TurnThisOff()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        skillDetail.gameObject.SetActive(false);
        skillDetailHeader.SetActive(false);
    }
}
