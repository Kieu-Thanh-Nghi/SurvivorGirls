using UnityEngine;

public class WeaponChoosingUI : MonoBehaviour
{
    [SerializeField] int weaponDataIndex;
    [SerializeField] ItemRank firstRank;
    [SerializeField] internal WeaponConcreteInfo weaponConcreteInfo;
    [SerializeField] WeaponUIInfoManager weaponInfoManager;
    [SerializeField] WeaponUIButtons weaponUIButtons;
    [SerializeField] WeaponFrameColorChanger weaponFrameColorChanger;
    [SerializeField] GameObject weaponIcon;
    [SerializeField] internal GameObject EquipMark;

    internal PlayerWeaponData weaponData
        => Database.instance.playerItems.weaponData;
    internal WeaponInfo weaponInfo => weaponData.GetAnWeaponInfo(weaponDataIndex);
    internal WeaponSkillInfos weaponSkillInfos => weaponConcreteInfo.skillInfosPrefab;
    internal int thisMaxlvl => weaponUI.maxLvls[weaponInfo.rank];

    internal int CurrentRankInt => weaponInfo.rank + (int)firstRank;
    internal WeaponUI weaponUI => UIManager.instance.weaponUI;

    WeaponSpecs weaponSpecs => UIManager.instance.weaponSpecs;

    internal int GetMaxLvl(int rankInt)
    {
        return weaponUI.maxLvls[rankInt];
    }

    private void OnEnable()
    {
        weaponUIButtons.ConfigButtons(
            weaponData.CheckIfItemHasBought(weaponDataIndex), weaponInfo.level,
            weaponInfo, weaponConcreteInfo);
    }
    public void ConfigUI(WeaponUI weaponUI)
    {
        var theMaxLvl = weaponUI.maxLvls[weaponInfo.rank];

        //WeaponUIInfoManager
        weaponInfoManager.UpdateLvl(weaponInfo, theMaxLvl);
        weaponInfoManager.UpdateTotalAtk(weaponConcreteInfo.GetTotalDamage(weaponInfo.level));
        weaponInfoManager.UpdateWeaponSkillUI(weaponInfo);

        //weaponFrameColorChanger
        weaponFrameColorChanger.changeFrameAndBGByRank(CurrentRankInt);
    }

    public void BuyThis()
    {
        weaponData.ChangeAndSaveSkinBoughtInfo(weaponDataIndex, true);
        weaponUIButtons.DoIfBuyOrNot(true, weaponInfo.level);
    }

    public void UpdateWhenLvlChange()
    {
        weaponInfoManager.UpdateLvl(weaponInfo, thisMaxlvl);
        weaponInfoManager.UpdateTotalAtk(weaponConcreteInfo.GetTotalDamage(weaponInfo.level));
        if (weaponSpecs.gameObject.activeInHierarchy)
        {
            weaponSpecs.LvlUpdate(
            thisMaxlvl,
            weaponInfo,
            weaponConcreteInfo);
        }
    }

    public void UpdateWhenRankChange()
    {
        weaponInfoManager.UpdateLvl(weaponInfo, thisMaxlvl);
        weaponInfoManager.UpdateWeaponSkillUI(weaponInfo);
        weaponFrameColorChanger.changeFrameAndBGByRank(CurrentRankInt);
        weaponUIButtons.SetupRankupButton(weaponInfo, weaponConcreteInfo);
    }

    public void OpenWeaponSpecs()
    {
        weaponSpecs.SetupWeaponSpecs(
            weaponData.equippingItemIndex == weaponDataIndex,
            CurrentRankInt,
            thisMaxlvl,
            weaponIcon,
            weaponInfo,
            weaponConcreteInfo,
            this,
            weaponUIButtons.weaponLvlUp,
            weaponData.CheckIfItemHasBought(weaponDataIndex));
        weaponSpecs.gameObject.SetActive(true);
    }

    public void ChangeDamageData(bool isAdd)
    {
        int i = 1;
        if (isAdd)
        {
            i = 1;
        }
        else
        {
            i = -1;
        }
        Database.instance.playerData[IntPlayerData.Atk] += i*weaponConcreteInfo.GetTotalDamage(weaponInfo.level);
    }

    public void EquipWeapon()
    {
        weaponData.equippingItemIndex = weaponDataIndex;
        ChangeDamageData(true);
        weaponUI.ChangeEquippedWeapon(this);
    }

    public void UnEquipThisWeapon()
    {
        ChangeDamageData(false);
    }
}
