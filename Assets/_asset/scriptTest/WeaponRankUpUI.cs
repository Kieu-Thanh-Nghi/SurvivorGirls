using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponRankUpUI : MonoBehaviour
{
    [SerializeField] Image frameFrom, frameTo;
    [SerializeField] internal Image rankIconFrom, rankIconTo;
    internal GameObject weaponIconFrom, weaponIconTo;

    [SerializeField] internal TMP_Text lvlFrom, lvlTo;

    [SerializeField] Transform skillIconBG;
    internal GameObject skillIcon;
    [SerializeField] internal TMP_Text skillDetail;

    [SerializeField] PayButton rankupButton;
    [SerializeField] WeaponRankupConfirm weaponRankupConfirm;
    [SerializeField] BuyMoreMaterial buyMoreMaterial;

    public void OpenTheRankupUI(
        GameObject weaponIcon, int rankIntFrom, int rankIntTo,
        int maxLvlFrom, int maxLvlTo,
        GameObject skillIconPrefab, TMP_Text skillInfo)
    {
        ShowRankFromTo(weaponIcon, rankIntFrom, rankIntTo);
        ShowMaxLvlFromTo(maxLvlFrom, maxLvlTo);
        ShowUnlockSkill(skillIconPrefab, skillInfo);
        gameObject.SetActive(true);
    }
    public void SetCurrencyAmount(int currencyAmount, IPayable payable)
    {
        if(currencyAmount <= -1)
        {
            Debug.Log("rank da max");
            return;
        }
        rankupButton.SetBuyInfoAndCheckEnough(currencyAmount, payable);
    }
    public void ShowRankFromTo(GameObject weaponIcon, int rankIntFrom, int rankIntTo)
    {
        SetRankIcon(
            ref weaponIconFrom,
            ref frameFrom,
            ref rankIconFrom,
            weaponIcon,
            rankIntFrom);
        SetRankIcon(
            ref weaponIconTo,
            ref frameTo,
            ref rankIconTo,
            weaponIcon,
            rankIntTo);
    }

    void SetRankIcon(
        ref GameObject theWeaponIcon,
        ref Image theFrame,
        ref Image theRankIcon,
        GameObject weaponIconPrefab, 
        int theRank)
    {
        theWeaponIcon = Instantiate(weaponIconPrefab, theFrame.transform, false);
        var frame = UIDatas.Instance.rankFrame[theRank];
        var rankIcon = UIDatas.Instance.rankIcon[theRank];

        theFrame.sprite = frame;
        theRankIcon.sprite = rankIcon;
    }

    public void ShowMaxLvlFromTo(int maxLvlFrom, int maxLvlTo)
    {
        lvlFrom.text = maxLvlFrom.ToString();
        lvlTo.text = maxLvlTo.ToString();
    }

    public void ShowUnlockSkill(GameObject skillIconPrefab, TMP_Text skillInfo)
    {
        skillIcon = Instantiate(skillIconPrefab, skillIconBG, false);
        skillIcon.SetActive(true);
        skillDetail.text = skillInfo.text;
    }

    public void ShowRankupComfirm()
    {
        var needAmount = rankupButton.CurrencyAmount;
        var haveAmount = rankupButton.GetHaveAmount();
        if (needAmount > haveAmount)
        {
            buyMoreMaterial.OpenBuyMoreUI(needAmount - haveAmount);
        }
        else
        {
            weaponRankupConfirm.OpenConfirmUI(rankupButton.CurrencyAmount);
        }
    }

    private void OnDisable()
    {
        if (skillIcon != null) Destroy(skillIcon);
        if (weaponIconFrom != null) Destroy(weaponIconFrom);
        if (weaponIconTo != null) Destroy(weaponIconTo);
        weaponRankupConfirm.gameObject.SetActive(false);
        buyMoreMaterial.gameObject.SetActive(false);
    }
}
