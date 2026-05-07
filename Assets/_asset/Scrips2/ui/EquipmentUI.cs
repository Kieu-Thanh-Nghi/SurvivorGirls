using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EquipmentUI : AEquipUI
{
    [SerializeField] internal TypeOfEquipment type;
    [SerializeField] internal int totalEquipmentQuantity;
    internal EquipFrame equipedOne;
    internal List<List<EquipFrame>> equipsLists = new();
    EquipFrameComparer equipFrameComparer => Database.instance.playerEquipments.equipFrameComparer;

    internal void Setup()
    {
        foreach (var rank in System.Enum.GetValues(typeof(ItemRank)))
        {
            equipsLists.Add(new List<EquipFrame>());
        }
        GetEquipmentFromDatabase();
    }
    void GetEquipmentFromDatabase()
    {
        var equips = Database.instance.playerEquipments[type].equipInfos;
        var equipFramePrefab = UIDatas.Instance.equipFramePrefab;
        int start = 0;
        if (Database.instance.playerEquipments.CheckIsUsing(type))
        {
            equipedOne = Instantiate(equipFramePrefab, transform);
            equipedOne.SetupEquipPresent(equips[0]);
            equipedOne.IsEquipping = true;
            start = 1;
        }
        totalEquipmentQuantity = equips.Count;
        for(int i = start; i < totalEquipmentQuantity; i++)
        {
            var aFrame = Instantiate(equipFramePrefab, transform);
            aFrame.SetupEquipPresent(equips[i]);
            equipsLists[(int)equips[i].rank].Add(aFrame);
        }
        //foreach(var anEquipment in equips)
        //{
        //    equipsLists[(int)anEquipment.rank].Add(new EquipPresent(anEquipment));
        //}

        int n = equipsLists.Count;
        for(int i = 0; i < n; i++)
        {
            SortEquipList(i);
        }
    }
    internal void AddNewEquipment(Equipment newOne, Transform FramesContainer, int preIndex)
    {
        var newEquipFrame = BornANewEquipFrame(newOne, FramesContainer);
        int rankInt = (int)newOne.rank;

        var theList = equipsLists[rankInt];
        //theList.Add(newEquipPresent);
        //SortEquipList(rankInt);
        int theIndex = GetEquipFrameIndex(newEquipFrame, theList);
        theList.Insert(theIndex, newEquipFrame);

        totalEquipmentQuantity++;
        newEquipFrame.transform.SetSiblingIndex(preIndex + theIndex);
    }
    internal EquipFrame BornANewEquipFrame(Equipment newOne, Transform FramesContainer)
    {
        var equipFramePrefab = UIDatas.Instance.equipFramePrefab;
        var newEquipFrame = Instantiate(equipFramePrefab, transform);
        newEquipFrame.SetupEquipPresent(newOne);
        newEquipFrame.transform.SetParent(FramesContainer, false);

        return newEquipFrame;
    }
    internal void SortEquipList(int rankIndex)
    {
        equipsLists[rankIndex].Sort(equipFrameComparer);
    }
    internal void SetParentFramesByRank(Transform FramesContainer, int index)
    {
        foreach (var equipFrame in equipsLists[index])
        {
            equipFrame.transform.SetParent(FramesContainer, false);
        }
    }
    internal void SetParentEquipedFrame(Transform FramesContainer)
    {
        equipedOne?.transform.SetParent(FramesContainer);
    }

    internal void RemoveAEquipFrameInList(EquipFrame equipFrame, ItemRank rank)
    {
        var theList = equipsLists[(int)rank];
        int theIndex = GetEquipFrameIndex(equipFrame, theList);
        theList.RemoveAt(theIndex);
    }
    public void RemoveEquipedOne(int preIndex)
    {
        var theList = equipsLists[(int)equipedOne.equipment.rank];
        int theIndex = GetEquipFrameIndex(equipedOne, theList);
        theList.Insert(theIndex, equipedOne);
        equipedOne.transform.SetSiblingIndex(preIndex + theIndex - 1);
        equipedOne.IsEquipping = false;
        equipedOne = null;
    }
    internal void EquipAnEquipmentFrame(EquipFrame equipFrame, 
        int oldOnePreIndex,
        int newEquippedIndex)
    {
        if (equipedOne != null)
        {
            RemoveEquipedOne(oldOnePreIndex);
        }
        RemoveAEquipFrameInList(equipFrame, equipFrame.equipment.rank);
        equipFrame.transform.SetSiblingIndex(newEquippedIndex);
        equipFrame.IsEquipping = true;
        equipedOne = equipFrame;
    }
    public int GetEquipFrameIndex(EquipFrame equipFrame)
    {
        var theList = equipsLists[(int)equipFrame.equipment.rank];
        int theIndex = theList.BinarySearch(equipFrame, equipFrameComparer);
        if (theIndex < 0) theIndex = ~theIndex;
        return theIndex;
    }
    public int GetEquipFrameIndex(EquipFrame equipFrame, ItemRank rank)
    {
        var theList = equipsLists[(int)rank];
        int theIndex = theList.BinarySearch(equipFrame, equipFrameComparer);
        if (theIndex < 0) theIndex = ~theIndex;
        return theIndex;
    }
    public int GetEquipFrameIndex(EquipFrame equipFrame, List<EquipFrame> theList)
    {
        int theIndex = theList.BinarySearch(equipFrame, equipFrameComparer);
        if (theIndex < 0) theIndex = ~theIndex;
        return theIndex;
    }
    void GetEquipList(ref List<EquipFrame> equipList)
    {
        if(equipList == null)
        {
            equipList = new();
        }
        else
        {
            equipList.Clear();
        }
        if(equipedOne != null) equipList.Add(equipedOne);
        int n = equipsLists.Count;
        for(int i = n - 1; i >= 0; i--)
        {
            equipList.AddRange(equipsLists[i]);
        }
    }
    public override void EnableScreen()
    {
        scrollCtrler.framesQuantity = totalEquipmentQuantity;
        scrollCtrler.isAll = false;
        GetEquipList(ref scrollCtrler.framesList);
        scrollCtrler.SetPaddingsSize();
        scrollCtrler.RevealFirstFrames();
    }
    public override void DisableScreen()
    {
        scrollCtrler.HideCurrentFrames();
    }
}
