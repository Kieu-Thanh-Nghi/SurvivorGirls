using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutSkin : MonoBehaviour
{
    [SerializeField] Transform SkinInfoContainer;
    GameObject currentSkinInfo;
    [SerializeField] Transform DataBuffContainer;
    List<GameObject> DataBuffs = new();

    public void ChangeToNewSkinBuff(int oldSkinIndex, int newSkinIndex)
    {
        var skinData = Database.instance.playerItems.skinData;
        var oldSkin = skinData.itemList[oldSkinIndex].GetComponent<EquippingSkin>();
        var newSkin = skinData.itemList[newSkinIndex].GetComponent<EquippingSkin>();

        oldSkin.UnEquip();
        newSkin.Equip();
    }

    public void ShowSelectingSkinInfo(int skinIndex)
    {
        var skinData = Database.instance.playerItems.skinData;
        var equippingSkin = skinData.itemList[skinIndex].GetComponent<EquippingSkin>();

        if (equippingSkin != null)
        {
            ShowSkinInfo(equippingSkin.SkinInfoUI);
            ShowDataBuff(equippingSkin);
        }
    }

    void ShowSkinInfo(GameObject SkinInfoPrefab)
    {
        if(currentSkinInfo != null)
        {
            Destroy(currentSkinInfo);
        }
        currentSkinInfo = Instantiate(SkinInfoPrefab, SkinInfoContainer, false);
    }

    void ShowDataBuff(EquippingSkin equippingSkin)
    {
        foreach(var buff in DataBuffs)
        {
            Destroy(buff);
        }
        DataBuffs.Clear();
        foreach (var changer in equippingSkin.dataChangers)
        {
            DataBuffs.Add(Instantiate(changer.gameObject, DataBuffContainer, false));
        }
    }
}
