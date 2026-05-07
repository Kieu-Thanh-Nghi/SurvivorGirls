using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TigerForge;

public class WeaponRankup : MonoBehaviour, IPayable
{
    [SerializeField] WeaponChoosingUI weaponChoosingUI;
    [SerializeField] WeaponRankUpSuccess weaponRankUpSuccess;
    [SerializeField] GameObject weaponIcon;
    [SerializeField] GameObject[] skillIcons;
    WeaponRankUpUI weaponRankUpUI => UIManager.instance.weaponRankUpUI;

    public void DonePaying()
    {
        weaponChoosingUI.weaponInfo.rank++;
        weaponChoosingUI.weaponData.SaveWeaponInfo();
        weaponRankUpSuccess.ShowRankUpSuccess(
            weaponRankUpUI.rankIconTo.sprite,
            weaponRankUpUI.weaponIconFrom,
            weaponRankUpUI.skillIcon.gameObject,
            weaponRankUpUI.lvlFrom.text,
            weaponRankUpUI.lvlTo.text,
            weaponRankUpUI.skillDetail.text
            ) ;
        weaponRankUpUI.gameObject.SetActive(false);
        weaponChoosingUI.UpdateWhenRankChange();
        EventManager.EmitEvent(GameEvents.EvRankupWeapon.ToString());
    }

    public void ToRankupUI()
    {
        var currentRankInt = weaponChoosingUI.CurrentRankInt;
        var skillInfos = weaponChoosingUI.weaponSkillInfos.infos[weaponChoosingUI.weaponInfo.rank + 1];
        weaponRankUpUI.OpenTheRankupUI(
            weaponIcon, currentRankInt, currentRankInt + 1,
            weaponChoosingUI.GetMaxLvl(currentRankInt), weaponChoosingUI.GetMaxLvl(currentRankInt + 1),
            skillIcons[weaponChoosingUI.weaponInfo.rank + 1], skillInfos);
        weaponRankUpUI.SetCurrencyAmount(
            weaponChoosingUI.weaponConcreteInfo.GetRankupPriceForNextRank(weaponChoosingUI.weaponInfo.rank), 
            this);
    }
}
