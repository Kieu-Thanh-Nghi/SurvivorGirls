using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponData : PlayerItemsData
{
    [SerializeField] WeaponInfoContainer weaponInfoContainer;
    [SerializeField] string weaponInfoSaveName;

    public override void ConfigItemBoughtInfo()
    {
        base.ConfigItemBoughtInfo();
        weaponInfoContainer.ConfigWeaponInfos(
            weaponInfoSaveName,
            itemList.Count,
            itemSaveQuantityUpdater);
    }
    public override Transform SetItemIn(PlayerSetup playerSetup, Transform playerTransform)
    {
        currentItem = Instantiate(itemList[equippingItemIndex], playerTransform);
        var weaponInject = currentItem.GetComponent<WeaponSkillInjection>();
        playerSetup.weaponInjection = weaponInject;
        weaponInject.weaponRank = GetEpuippingWeaponInfo().rank;
        return currentItem.transform;
    }

    public WeaponInfo GetEpuippingWeaponInfo() => weaponInfoContainer.GetAnInfo(equippingItemIndex);

    public WeaponInfo GetAnWeaponInfo(int index) => weaponInfoContainer.GetAnInfo(index);

    public void SaveWeaponInfo() => weaponInfoContainer.SaveInfos(weaponInfoSaveName);

    public List<WeaponInfo> GetWeaponInfos() => weaponInfoContainer.weaponInfos;
}

[System.Serializable]
public class WeaponInfoContainer
{
    [SerializeField] internal List<WeaponInfo> weaponInfos;

    public void ConfigWeaponInfos(string saveName, int numberOfWeapon, ItemSaveQuantityUpdater itemSaveQuantityUpdater)
    {
        LoadInfos(saveName, numberOfWeapon);
        UpdateWeaponInfosQuantity(itemSaveQuantityUpdater, numberOfWeapon, saveName);
    }

    public void LoadInfos(string saveName, int numberOfWeapon)
    {
        string json = Database.instance.saveSystem.Load(saveName, null);
        if(json == null)
        {
            SetupDefaultInfosJson(numberOfWeapon);
            SaveInfos(saveName);
        }
        else
        {
            weaponInfos = JsonUtility.FromJson<WeaponInfoContainer>(json).weaponInfos;
        }
    }
    protected void UpdateWeaponInfosQuantity(ItemSaveQuantityUpdater itemSaveQuantityUpdater,
        int numberOfWeapon,
        string saveName)
    {
        int savedWeaponInfosCount = weaponInfos.Count;

        if (savedWeaponInfosCount != numberOfWeapon)
        {
            weaponInfos = itemSaveQuantityUpdater.UpdateBoughtInfosQuantity(
                weaponInfos.ToArray(), numberOfWeapon, savedWeaponInfosCount);
            SaveInfos(saveName);
        }
    }
    internal void SaveInfos(string name)
    {
        string json = GetThisJson();
        Database.instance.saveSystem.Save(name, json);
    }

    internal WeaponInfo GetAnInfo(int index)
    {
        if (index < 0 || index >= weaponInfos.Count) return null;
        return weaponInfos[index];
    }

    string GetThisJson()
    {
        return JsonUtility.ToJson(this, true);
    }

    void SetupDefaultInfosJson(int numberOfWeapon)
    {
        for (int i = 0; i < numberOfWeapon; i++)
        {
            weaponInfos.Add(new WeaponInfo());
        }
    }
}

[System.Serializable]
public class WeaponInfo
{
    [SerializeField] internal int level;
    [SerializeField] internal int rank;

    public WeaponInfo()
    {
        level = 1;
        rank = 0;
    }
    public WeaponInfo(int theLevel, int theRank)
    {
        level = theLevel;
        rank = theRank;
    }
}