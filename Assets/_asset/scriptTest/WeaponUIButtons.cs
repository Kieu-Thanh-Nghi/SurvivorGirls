using UnityEngine;

public class WeaponUIButtons : MonoBehaviour
{
    [SerializeField] GameObject functionButtons, buyButtonContainer;
    [SerializeField] GameObject rankUpButton;
    [SerializeField] internal WeaponLvlUp weaponLvlUp;
    [SerializeField] internal WeaponBuying weaponBuying;

    public void ConfigButtons(bool hasBought, int weaponLvl,
        WeaponInfo weaponInfo, WeaponConcreteInfo weaponConcreteInfo)
    {
        DoIfBuyOrNot(hasBought, weaponLvl);
        SetupRankupButton(weaponInfo, weaponConcreteInfo);
    }

    public void DoIfBuyOrNot(bool hasBought, int weaponLvl)
    {
        functionButtons.SetActive(hasBought);
        buyButtonContainer.SetActive(!hasBought);
        if (hasBought)
        {
            weaponLvlUp.lvlUpButton.SetBuyInfoAndCheckEnough(weaponLvlUp.GetTotalPayAmountToNextLvl(weaponLvl), weaponLvlUp);
        }
        else
        {
            weaponBuying.buyButton.SetBuyInfoAndCheckEnough(weaponBuying.BuyPrice, weaponBuying);
        }
    }

    public void SetupRankupButton(WeaponInfo weaponInfo, WeaponConcreteInfo weaponConcreteInfo)
    {
        if (weaponInfo.rank >= weaponConcreteInfo.weaponMaxRank)
        {
            rankUpButton.SetActive(false);
        }
        else
        {
            rankUpButton.SetActive(true);
        }
    }
}
