using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EquipmentUIAll : AEquipUI
{
    [SerializeField] internal EquipmentUI[] EUIs;
    [SerializeField] internal Transform framesContainder;

    public override void DisableScreen()
    {
        scrollCtrler.HideCurrentFrames();
    }
    public void SetEquipedOnes(EquipFrame equipFrame)
    {
        var type = equipFrame.equipment.equipType;

        int preIndex = -1;
        if(EUIs[(int)type].equipedOne != null)
        {
            preIndex = CalculatePreIndex(EUIs[(int)type].equipedOne.equipment);
        }

        EUIs[(int)type].EquipAnEquipmentFrame(equipFrame,
            preIndex,
            CalculateEquippedIndex(type));
    }
    internal void SetPositionInList(EquipFrame equipFrame)
    {
        if (!equipFrame.IsEquipping)
        {
            var equipment = equipFrame.equipment;
            var eui = EUIs[(int)equipment.equipType];
            eui.SortEquipList((int)equipment.rank);

            int preIndex = CalculatePreIndex(equipment);
            int theIndex = eui.GetEquipFrameIndex(equipFrame);
            equipFrame.transform.SetSiblingIndex(preIndex + theIndex);
        }
    }
    public void RemoveAnEquipedFrame(TypeOfEquipment type)
    {
        int preIndex = -1;
        if (EUIs[(int)type].equipedOne != null)
        {
            preIndex = CalculatePreIndex(EUIs[(int)type].equipedOne.equipment);
        }
        EUIs[(int)type].RemoveEquipedOne(preIndex);
    }
    public void RemoveAFrame(EquipFrame equipFrame)
    {
        var type = equipFrame.equipment.equipType;
        if (!equipFrame.IsEquipping)
        {
            var eui = EUIs[(int)type];
            eui.RemoveAEquipFrameInList(equipFrame, equipFrame.equipment.rank);
        }
        Destroy(equipFrame.gameObject);
    }
    int CalculateEquippedIndex(TypeOfEquipment type)
    {
        int count = 0;
        int n = (int)type;
        for (int i = 0; i < n; i++)
        {
            if (EUIs[i].equipedOne != null)
            {
                count++;
            }
        }
        return count;
    }
    public override void EnableScreen()
    {
        scrollCtrler.framesQuantity = framesContainder.childCount;
        scrollCtrler.isAll = true;
        scrollCtrler.SetPaddingsSize();
        scrollCtrler.RevealFirstFrames();
    }

    //private void OnValidate()
    //{
    //    EUIs = GetComponents<EquipmentUI>();
    //}
    //private void Start()
    //{
    //    foreach (var eui in EUIs)
    //    {
    //        eui.Setup();
    //    }
    //    var rankList = System.Enum.GetValues(typeof(ItemRank));

    //    int n = rankList.Length;
    //    for (int i = n - 1; i >= 0; i--)
    //    {
    //        foreach (var eui in EUIs)
    //        {
    //            eui.CreateEquipFramesByRank(framesContainder, i);
    //        }
    //    }
    //    EnableScreen();
    //}
    public void StartSetUp()
    {
        foreach (var eui in EUIs)
        {
            eui.Setup();
        }
        var rankList = System.Enum.GetValues(typeof(ItemRank));
        foreach (var eui in EUIs)
        {
            eui.SetParentEquipedFrame(framesContainder);
        }
        int n = rankList.Length;
        for (int i = n - 1; i >= 0; i--)
        {
            foreach (var eui in EUIs)
            {
                eui.SetParentFramesByRank(framesContainder, i);
            }
        }
    }
    public void AddNewEquipment(Equipment newOne, bool isEquipThis = false)
    {
        if (isEquipThis)
        {
            var eui = EUIs[(int)newOne.equipType];
            var newEquipFrame = eui.BornANewEquipFrame(newOne, framesContainder);
            newEquipFrame.transform.SetSiblingIndex(CalculateEquippedIndex(newOne.equipType));
            newEquipFrame.IsEquipping = true;

            EUIs[(int)newOne.equipType].equipedOne = newEquipFrame;
        }
        else
        {
            int preIndex = CalculatePreIndex(newOne);
            EUIs[(int)newOne.equipType].AddNewEquipment(newOne, framesContainder, preIndex);
        }
    }
    int CalculatePreIndex(Equipment equipment)
    {
        var neededEUI = EUIs[(int)equipment.equipType];
        int preIndex = 0;
        int rankInt = (int)equipment.rank;

        var rankList = System.Enum.GetValues(typeof(ItemRank));
        int n = rankList.Length;

        foreach (var eui in EUIs)
        {
            if (eui.equipedOne != null)
            {
                preIndex++;
            }
        }

        for (int i = n - 1; i >= 0; i--)
        {
            foreach (var eui in EUIs)
            {
                if (neededEUI == eui && rankInt == i)
                {
                    return preIndex;
                }
                preIndex += eui.equipsLists[i].Count;
            }
        }
        return preIndex;
    }
}

public abstract class AEquipUI : MonoBehaviour
{
    internal ItemScrollCtrler scrollCtrler => UIManager.instance.equipsUIManager.scrollCtrler;
    public abstract void EnableScreen();
    public abstract void DisableScreen();
}