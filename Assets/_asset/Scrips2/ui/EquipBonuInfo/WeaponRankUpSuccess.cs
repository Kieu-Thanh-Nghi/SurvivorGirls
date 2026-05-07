using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponRankUpSuccess : MonoBehaviour
{
    [SerializeField] Transform ItemIconHolder;
    GameObject itemIcon;
    [SerializeField] Image newRankIcon;
    [SerializeField] TMP_Text maxLvlFrom, maxLvlTo;
    [SerializeField] TMP_Text skillDetail;
    [SerializeField] Transform skillIconHolder;
    GameObject skillIcon;
    [SerializeField] GameObject skillDetailHeader;

    public void ShowRankUpSuccess(
        Sprite rankIconTo,
        GameObject itemIconPrefab,
        GameObject skillIconPrefab,
        string lvlFrom,
        string lvlTo,
        string theSkillDetail)
    {
        itemIcon = Instantiate(itemIconPrefab, ItemIconHolder, false);
        itemIcon.SetActive(true);
        newRankIcon.sprite = rankIconTo;
        maxLvlFrom.text = lvlFrom;
        maxLvlTo.text = lvlTo;
        gameObject.SetActive(true);
        SetSkillDetail(theSkillDetail, skillIconPrefab);
        Invoke(nameof(TurnThisOff), 3);
    }

    void SetSkillDetail(string theSkillDetail, GameObject skillIconPrefab)
    {
        skillIcon = Instantiate(skillIconPrefab, skillIconHolder, false);
        skillDetail.text = theSkillDetail;
        skillDetail.gameObject.SetActive(true);
        skillDetailHeader.SetActive(true);
    }

    void TurnThisOff()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        skillDetail.gameObject.SetActive(false);
        skillDetailHeader.SetActive(false);
        Destroy(itemIcon);
        Destroy(skillIcon);
    }
}