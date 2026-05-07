using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerItemsData : MonoBehaviour
{
    [SerializeField] protected string saveName = "CurrentSkin";
    [SerializeField] protected string boughtInfoSaveName = "BoughtInfo";
    [SerializeField] protected int defaultEquippingItemIndex = 0;
    [SerializeField] internal List<Transform> itemList;
    [SerializeField] internal Transform currentItem;
    [SerializeField] protected bool[] hasBoughtInfos;
    protected ItemSaveQuantityUpdater itemSaveQuantityUpdater = new();

    internal int equippingItemIndex
    {
        get
        {
            return Database.instance.saveSystem.Load(saveName, defaultEquippingItemIndex);
        }
        set
        {
            Database.instance.saveSystem.Save(saveName, value);
        }
    }
    [ContextMenu("config skinEquipAndBuyInfo")]
    public virtual void ConfigItemBoughtInfo()
    {
        var saveSystem = Database.instance.saveSystem;
        hasBoughtInfos = saveSystem.LoadArray(boughtInfoSaveName, GetDefaultSkinBoughtInfo());

        UpdateBoughtInfosQuantity();
    }

    protected void UpdateBoughtInfosQuantity()
    {
        int savedBoughtInfosCount = hasBoughtInfos.Length;
        int numberOfItems = itemList.Count;

        if (savedBoughtInfosCount != numberOfItems)
        {
            hasBoughtInfos = itemSaveQuantityUpdater.UpdateBoughtInfosQuantity(
                hasBoughtInfos, numberOfItems, savedBoughtInfosCount,
                null, CheckIfItemIndexValable).ToArray();
            Database.instance.saveSystem.Save(boughtInfoSaveName, hasBoughtInfos);
        }
    }
    protected void CheckIfItemIndexValable(int numberOfItems)
    {
        if (equippingItemIndex > numberOfItems - 1)
        {
            equippingItemIndex = defaultEquippingItemIndex;
        }
    }
    protected bool[] GetDefaultSkinBoughtInfo()
    {
        bool[] hasBoughts = new bool[itemList.Count];
        if(defaultEquippingItemIndex != -1)
        {
            hasBoughts[defaultEquippingItemIndex] = true;
        }
        return hasBoughts;
    }

    public void ChangeAndSaveSkinBoughtInfo(int skinIndex, bool hasBought)
    {
        hasBoughtInfos[skinIndex] = hasBought;
        Database.instance.saveSystem.Save(boughtInfoSaveName, hasBoughtInfos);
    }

    public bool CheckIfItemHasBought(int skinIndex)
    {
        return hasBoughtInfos[skinIndex];
    }

    public virtual Transform SetItemIn(
        PlayerSetup playerSetup, 
        Transform playerTransform)
    {
        if (currentItem != null)
        {
            DestroyImmediate(currentItem);
        }

        currentItem = Instantiate(itemList[equippingItemIndex], playerTransform, false);
        return currentItem.transform;
    }
}

public class ItemSaveQuantityUpdater
{
    public List<T> UpdateBoughtInfosQuantity<T>(T[] saveArray,int numberOfItems, int savedBoughtInfosCount,
        UnityAction<int> DoWhenAddMore = null, UnityAction<int> DoWhenRemove = null)
    {
        List<T> saveList = new(saveArray);
        if (savedBoughtInfosCount < numberOfItems)
        {
            saveList.AddRange(new T[numberOfItems - savedBoughtInfosCount]);
            DoWhenAddMore?.Invoke(numberOfItems);
        }
        else if (savedBoughtInfosCount > numberOfItems)
        {
            saveList.RemoveRange(numberOfItems, savedBoughtInfosCount - numberOfItems);
            DoWhenRemove?.Invoke(numberOfItems);
        }
        return saveList;
    }
}
[System.Serializable]
public class SkinEquipAndBuyInfo
{
    [SerializeField] internal List<bool> hasBought;
}