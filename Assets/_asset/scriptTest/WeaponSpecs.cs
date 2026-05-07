using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponSpecs : MonoBehaviour, IPayable
{
    [SerializeField] internal Image RankIcon, Frame;
    [SerializeField] internal TMP_Text WeaponName, Lv, Atk;
    [SerializeField] internal Transform SkillsContainer;
    [SerializeField] internal TMP_Text Range, FireRate, MaxAmmo, Reload;
    [SerializeField] Transform ButtonsHolder;
    [SerializeField] GameObject EquipButton;
    [SerializeField] PayButton thisLvlupButton;
    PayButton targetLvlupButton;
    WeaponLvlUp weaponLvlUp;
    WeaponChoosingUI weaponEquipper;
    GameObject currentWeaponIcon;
    WeaponSkillInfos currentSkillInfos;

    public void SetupWeaponSpecs(
        bool isEquipped,
        int rankInt,
        int thisMaxLvl,
        GameObject weaponIcon,
        WeaponInfo weaponInfo,
        WeaponConcreteInfo weaponConcreteInfo,
        WeaponChoosingUI weaponChoosingUI,
        WeaponLvlUp weaponLvlUp,
        bool hasBought)
    {
        Frame.sprite = UIDatas.Instance.rankFrame[rankInt];
        currentWeaponIcon = Instantiate(weaponIcon, Frame.transform, false);

        RankIcon.sprite = UIDatas.Instance.rankIcon[rankInt];
        WeaponName.text = weaponConcreteInfo.weaponName;

        Lv.text = weaponInfo.level.ToString() + " / " + thisMaxLvl.ToString();
        Atk.text = weaponConcreteInfo.GetTotalDamage(weaponInfo.level).ToString("N0");

        Range.text = weaponConcreteInfo.Range.ToString() + "m";
        FireRate.text = weaponConcreteInfo.FireRate.ToString();
        MaxAmmo.text = weaponConcreteInfo.MaxAmmo.ToString();
        Reload.text = weaponConcreteInfo.Reload.ToString() + "S";

        currentSkillInfos = Instantiate(weaponConcreteInfo.skillInfosPrefab, SkillsContainer, false);
        currentSkillInfos.ConfigSkillsLockOrOpen(weaponInfo);

        weaponEquipper = weaponChoosingUI;

        if (!hasBought)
        {
            ButtonsHolder.gameObject.SetActive(false);
            return;
        }
        else
        {
            ButtonsHolder.gameObject.SetActive(true);
        }
        this.weaponLvlUp = weaponLvlUp;
        targetLvlupButton = weaponLvlUp.lvlUpButton;
        thisLvlupButton.gameObject.SetActive(targetLvlupButton.gameObject.activeSelf);
        thisLvlupButton.SetBuyInfoAndCheckEnough(targetLvlupButton.CurrencyAmount, this);
        EquipButton.SetActive(!isEquipped);
    }

    public void LvlUpdate(
        int thisMaxLvl,
        WeaponInfo weaponInfo,
        WeaponConcreteInfo weaponConcreteInfo
        )
    {
        Lv.text = weaponInfo.level.ToString() + " / " + thisMaxLvl.ToString();
        Atk.text = weaponConcreteInfo.GetTotalDamage(weaponInfo.level).ToString("N0");
    }

    public void DoEquip()
    {
        weaponEquipper.EquipWeapon();
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        if (currentWeaponIcon != null) Destroy(currentWeaponIcon);
        if (currentSkillInfos != null) Destroy(currentSkillInfos.gameObject);
    }

    public void DonePaying()
    {
        weaponLvlUp.DonePaying();
        thisLvlupButton.gameObject.SetActive(targetLvlupButton.gameObject.activeSelf);
        thisLvlupButton.SetBuyInfo(targetLvlupButton.CurrencyAmount, this);
    }
}
