using System.Collections.Generic;
using UnityEngine;

public class WeaponUI : MonoBehaviour
{
    [SerializeField] internal int[] maxLvls;
    [SerializeField] List<WeaponChoosingUI> weaponChoosingUIs;
    WeaponChoosingUI currnetEquippedWeapon;

    private void Start()
    {
        foreach(var w in weaponChoosingUIs)
        {
            w.ConfigUI(this);
        }
    }

    public void ConfigWeapon()
    {
        var equippedIndex = Database.instance.playerItems.weaponData.equippingItemIndex;
        currnetEquippedWeapon = weaponChoosingUIs[equippedIndex];
        currnetEquippedWeapon.ChangeDamageData(true);
        currnetEquippedWeapon.EquipMark.SetActive(true);
    }

    public void ChangeEquippedWeapon(WeaponChoosingUI newWeapon)
    {
        if(currnetEquippedWeapon != null)
        {
            currnetEquippedWeapon.EquipMark.SetActive(false);
            currnetEquippedWeapon.UnEquipThisWeapon();
        }
        newWeapon.EquipMark.SetActive(true);
        currnetEquippedWeapon = newWeapon;
    }
}
