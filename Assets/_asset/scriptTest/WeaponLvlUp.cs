using UnityEngine;
using TigerForge;

public class WeaponLvlUp : MonoBehaviour, IPayable
{
    [SerializeField] internal PayButton lvlUpButton;
    [SerializeField] WeaponChoosingUI weaponChoosing;
    [SerializeField] int startPayAmountToNextLvl;
    [SerializeField] int payAmountEachLvl;

    public void DonePaying()
    {
        var weaponInfo = weaponChoosing.weaponInfo;
        var newLvl = ++weaponInfo.level;
        weaponChoosing.weaponData.SaveWeaponInfo();
        weaponChoosing.UpdateWhenLvlChange();
        EventManager.EmitEvent(GameEvents.WeaponLvlUp.ToString());
        if(newLvl < weaponChoosing.thisMaxlvl)
        {
            lvlUpButton.SetBuyInfo(GetTotalPayAmountToNextLvl(newLvl), this);
        }
        else
        {
            lvlUpButton.gameObject.SetActive(false);
        }
    }

    public int GetTotalPayAmountToNextLvl(int theLvl)
    {
        return startPayAmountToNextLvl + (theLvl - 1) * payAmountEachLvl;
    }
}
