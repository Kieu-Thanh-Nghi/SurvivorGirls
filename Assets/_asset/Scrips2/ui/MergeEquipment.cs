using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MergeEquipment : MonoBehaviour
{
    [SerializeField] GameObject mergeBG, EquipBG;
    [SerializeField] GameObject mergeButton, backButton;
    [SerializeField] EquipMergeFrame MergeToFrame;
    [SerializeField] EquipMergeFrame[] MergeFromFrames;
    [SerializeField] EquipMergeFrame mergeResultFrame;
    [SerializeField] MergeUpgradeInfo upgradeInfo;
    [SerializeField] GameObject tutorial;
    [SerializeField] GameObject DoUpgradeButton;
    [SerializeField] UnityEvent AfterMerge;
    internal List<List<bool>> isMergeables;
    internal bool isMergeStage;
    int phase;
    internal int Phase
    {
        get => phase;
        set
        {
            phase = value;
            if(value == 0)
            {
                tutorial.SetActive(true);
                upgradeInfo.gameObject.SetActive(false);
            }
            else if(value == 1)
            {
                tutorial.SetActive(false);
                upgradeInfo.gameObject.SetActive(true);
            }
            if(value > MergeFromFrames.Length)
            {
                DoUpgradeButton.SetActive(true);
            }
            else
            {
                DoUpgradeButton.SetActive(false);
            }
        }
    }

    internal void Setup(EquipmentUI[] EUIs)
    {
        var ranks = Database.instance.ItemRankArr;
        var types = Database.instance.EquipTypeArr;
        isMergeables = new();     
        for(int i = 0; i < types.Length; i++)
        {
            SetOneMergeableEUI(i, ranks.Length, EUIs[i]);
            //for (int j = 0; j < ranks.Length; j++)
            //{
            //    if(EUIs[i].equipsLists[j].Count >= 3)
            //    {
            //        isMergeables[i][j] = true;
            //    }
            //    else
            //    {
            //        isMergeables[i][j] = false;
            //    }
            //}
            //if (EUIs[i].equipedOne != null)
            //{
            //    var equippedRank = (int)EUIs[i].equipedOne.equipment.rank;
            //    if (EUIs[i].equipsLists[equippedRank].Count + 1 >= 3)
            //    {
            //        isMergeables[i][equippedRank] = true;
            //    }
            //}
        }
    }
    void SetOneMergeableEUI(int type, int ranksCount, EquipmentUI eui)
    {
        isMergeables.Add(new List<bool>(new bool[ranksCount]));
        for (int j = 0; j < ranksCount; j++)
        {
            if (eui.equipsLists[j].Count >= 3)
            {
                isMergeables[type][j] = true;
            }
            else
            {
                isMergeables[type][j] = false;
            }
        }
        if (eui.equipedOne != null)
        {
            var equippedRank = (int)eui.equipedOne.equipment.rank;
            if (eui.equipsLists[equippedRank].Count + 1 >= 3)
            {
                isMergeables[type][equippedRank] = true;
            }
        }

    }
    internal void UpdateMergeable(Equipment equipment, EquipmentUI[] EUIs)
    {
        var intType = (int)equipment.equipType;
        var intRank = (int)equipment.rank;
        var eui = EUIs[intType];
        var euiEquipmentsByRank = eui.equipsLists[intRank];

        int needQuantity = 3;
        if (eui.equipedOne != null)
        {
            if (eui.equipedOne.equipment.rank == equipment.rank)
            {
                needQuantity = 2;
            }
        }
        if (euiEquipmentsByRank.Count >= needQuantity)
        {
            isMergeables[intType][intRank] = true;
        }
        else
        {
            isMergeables[intType][intRank] = false;
        }
    }
    public void CompleteMerge()
    {
        var equipsUIManager = UIManager.instance.equipsUIManager;
        SaveNewUpgrade();
        RemoveMaterialEquipment(equipsUIManager);
        Phase = 0;
        equipsUIManager.DisableCurrentScreen();
        equipsUIManager.EnableCurrentScreen();
        AfterMerge?.Invoke();
    }
    void SaveNewUpgrade()
    {
        var upgradeOne = MergeToFrame.thisEquipFrame.equipment;
        var resultOne = new Equipment(
            upgradeOne.equipType,
            upgradeOne.equipMat,
            (ItemRank)((int)upgradeOne.rank + 1),
            upgradeOne.Level);
        Database.instance.equipmentCreater.AddAndSaveAnEquipment(
            resultOne, MergeToFrame.thisEquipFrame.IsEquipping);
        ShowUpgradeResult(resultOne);
    }
    void ShowUpgradeResult(Equipment upgradedEquipment)
    {
        var rank = upgradedEquipment.rank;
        var mat = upgradedEquipment.equipMat;
        var icon = UIDatas.Instance.equipIconsList[(int)upgradedEquipment.equipType].icons[(int)mat];
        var maxLvlFrom = UIDatas.Instance.equipmentMaxLvEachRank[(int)rank - 1].ToString();
        var maxLvlTo = UIDatas.Instance.equipmentMaxLvEachRank[(int)rank].ToString();
        UIManager.instance.rankUpSuccess.ShowRankUpSuccess(rank, icon, maxLvlFrom, maxLvlTo, upgradeInfo.aboutQualitySkill.text);
    }
    void RemoveMaterialEquipment(EquipsUIManager equipsUIManager)
    {
        var mergeToOne = MergeToFrame.thisEquipFrame.equipment;
        var type = mergeToOne.equipType;
        List<Equipment> mergeFromEquipments = new();
        mergeFromEquipments.Add(mergeToOne);
        foreach(var mergeFrom in MergeFromFrames)
        {
            mergeFromEquipments.Add(mergeFrom.thisEquipFrame.equipment);
            equipsUIManager.RemoveAnEquipFrame(mergeFrom.thisEquipFrame);
            mergeFrom.gameObject.SetActive(false);
        }
        equipsUIManager.RemoveAnEquipFrame(MergeToFrame.thisEquipFrame);
        MergeToFrame.gameObject.SetActive(false);
        mergeResultFrame.gameObject.SetActive(false);
        Database.instance.equipmentCreater.RemoveEquimentsAndSave(mergeFromEquipments, type);
    }
    int GetMergeListAll(ref List<EquipFrame> equipList, EquipmentUI[] EUIs)
    {
        if (equipList == null)
        {
            equipList = new();
        }
        else
        {
            equipList.Clear();
        }
        var ranks = Database.instance.ItemRankArr;
        var types = Database.instance.EquipTypeArr;

        foreach (var eui in EUIs)
        {
            if (eui.equipedOne != null)
            {
                var equippedEquipment = eui.equipedOne.equipment;
                var equippedRank = equippedEquipment.rank;
                var equippedType = equippedEquipment.equipType;
                if ((int)ItemRank.SSS > (int)equippedRank && isMergeables[(int)equippedType][(int)equippedRank])
                {
                    equipList.Add(eui.equipedOne);
                }
            }
        }
        int n = ranks.Length;
        for (int i = n - 2; i >= 0; i--)
        {
            for (int j = 0; j < types.Length; j++)
            {
                if (isMergeables[j][i])
                {
                    equipList.AddRange(EUIs[j].equipsLists[i]);
                }
            }
        }
        return equipList.Count;
    }
    int GetMergeListOne(ref List<EquipFrame> equipList, EquipmentUI eui)
    {
        if (equipList == null)
        {
            equipList = new();
        }
        else
        {
            equipList.Clear();
        }
        var ranks = Database.instance.ItemRankArr;

        if (eui.equipedOne != null)
        {
            var equippedEquipment = eui.equipedOne.equipment;
            var equippedRank = equippedEquipment.rank;
            var equippedType = equippedEquipment.equipType;
            if ((int)ItemRank.SSS > (int)equippedRank && isMergeables[(int)equippedType][(int)equippedRank])
            {
                equipList.Add(eui.equipedOne);
            }
        }
        int n = ranks.Length;
        for (int i = n - 2; i >= 0; i--)
        {
            if (isMergeables[(int)eui.type][i])
            {
                equipList.AddRange(eui.equipsLists[i]);
            }
        }
        return equipList.Count;
    }
    public void EnableScreenAll(ItemScrollCtrler scrollCtrler, EquipmentUI[] EUIs)
    {
        scrollCtrler.isAll = false;
        scrollCtrler.framesQuantity = GetMergeListAll(ref scrollCtrler.framesList, EUIs);
        scrollCtrler.SetPaddingsSize();
        scrollCtrler.RevealFirstFrames();
    }
    public void EnableScreenOne(ItemScrollCtrler scrollCtrler, EquipmentUI eui)
    {
        scrollCtrler.isAll = false;
        scrollCtrler.framesQuantity = GetMergeListOne(ref scrollCtrler.framesList, eui);
        scrollCtrler.SetPaddingsSize();
        scrollCtrler.RevealFirstFrames();
    }
    public void ToMergeStageOrBack(bool isToMerge)
    {
        OnOffMerge(isToMerge);
        if (isToMerge)
        {
            var equipsUIManager = UIManager.instance.equipsUIManager;
            equipsUIManager.DisableCurrentScreen();
            equipsUIManager.EnableCurrentScreen();
        }
        else
        {
            var equipsUIManager = UIManager.instance.equipsUIManager;
            equipsUIManager.DisableCurrentScreen();
            equipsUIManager.EnableCurrentScreen();
            Phase = 0;
        }
    }

    internal void OnOffMerge(bool isToMerge)
    {
        mergeBG.SetActive(isToMerge);
        mergeButton.SetActive(!isToMerge);
        EquipBG.SetActive(!isToMerge);
        backButton.SetActive(isToMerge);
        isMergeStage = isToMerge;
    }

    internal void DoReverse(EquipFrame theEquipFrame, EquipMergeFrame mergeFrame, int mergeFrameType)
    {
        ItemScrollCtrler scrollCtrler = UIManager.instance.equipsUIManager.scrollCtrler;
        if (mergeFrameType == 1)
        {
            ReverseOnlyOne(theEquipFrame, scrollCtrler);
            mergeFrame.gameObject.SetActive(false);
            DisableScreen(scrollCtrler);
            scrollCtrler.SetPaddingsSize();
            scrollCtrler.RevealFirstFrames();
            Phase--;
        }
        else if (mergeFrameType == 0)
        {
            ReverseAll(scrollCtrler);
            Phase = 0;
        }
    }

    void ReverseOnlyOne(EquipFrame theEquipFrame, ItemScrollCtrler scrollCtrler)
    {
        int theIndex = scrollCtrler.framesList.BinarySearch(theEquipFrame, Database.instance.playerEquipments.equipFrameComparer);
        if (theIndex < 0) theIndex = ~theIndex;
        scrollCtrler.framesList.Insert(theIndex, theEquipFrame);
        scrollCtrler.framesQuantity++;
    }
    void ReverseAll(ItemScrollCtrler scrollCtrler)
    {
        DisableScreen(scrollCtrler);
        var equipUI = UIManager.instance.equipsUIManager.currentScreen.EquipUI;
        if(equipUI is EquipmentUIAll all)
        {
            EnableScreenAll(scrollCtrler, all.EUIs);
        }
        else if(equipUI is EquipmentUI eui)
        {
            EnableScreenOne(scrollCtrler, eui);
        }
        foreach(var mff in MergeFromFrames)
        {
            if (mff.gameObject.activeSelf)
            {
                mff.gameObject.SetActive(false);
            }
        }
        MergeToFrame.gameObject.SetActive(false);
        mergeResultFrame.gameObject.SetActive(false);
    }
    internal void PrepareToMerge(EquipFrame equipFrame, EquipmentUIAll equipmentUIAll)
    {
        ItemScrollCtrler scrollCtrler = UIManager.instance.equipsUIManager.scrollCtrler;
        if (Phase == 0)
        {
            upgradeInfo.ShowUpgradeInfo(equipFrame.equipment);

            var theRank = equipFrame.equipment.rank;
            MergeToFrame.SetInfo(equipFrame.frameBG.sprite, equipFrame.icon.sprite, 
                equipFrame.IsEquipping, equipFrame.lvlText, equipFrame);
            MergeToFrame.gameObject.SetActive(true);
            mergeResultFrame.SetInfo(UIDatas.Instance.rankBg[(int)theRank + 1], equipFrame.icon.sprite, 
                equipFrame.IsEquipping, equipFrame.lvlText, equipFrame);
            mergeResultFrame.gameObject.SetActive(true);

            DisableScreen(scrollCtrler);
            EnableScreenPhase1(scrollCtrler, equipFrame, equipmentUIAll);
            Phase++;
        }
        else if(Phase >= 1)
        {
            foreach(var mff in MergeFromFrames)
            {
                if (!mff.gameObject.activeSelf)
                {
                    mff.SetInfo(equipFrame.frameBG.sprite, equipFrame.icon.sprite,
                        equipFrame.IsEquipping, equipFrame.lvlText, equipFrame);
                    mff.gameObject.SetActive(true);
                    break;
                }
            }
            DisableScreen(scrollCtrler);
            scrollCtrler.framesList.Remove(equipFrame);
            scrollCtrler.framesQuantity--;
            Phase++;
            if(Phase <= MergeFromFrames.Length)
            {
                scrollCtrler.SetPaddingsSize();
                scrollCtrler.RevealFirstFrames();
            }
            else
            {
                scrollCtrler.ResetRevealTo();
            }
        }
    }
    int GetMergeFromList(ref List<EquipFrame> equipFrames, EquipFrame equipFrame, EquipmentUIAll equipmentUIAll)
    {
        if (equipFrames == null)
        {
            equipFrames = new();
        }
        else
        {
            equipFrames.Clear();
        }

        var rank = equipFrame.equipment.rank;
        var type = equipFrame.equipment.equipType;
        equipFrames.AddRange(equipmentUIAll.EUIs[(int)type].equipsLists[(int)rank]);
        equipFrames.Remove(equipFrame);

        return equipFrames.Count;
    }
    public void EnableScreenPhase1(ItemScrollCtrler scrollCtrler, EquipFrame equipFrame, EquipmentUIAll equipmentUIAll)
    {
        scrollCtrler.isAll = false;
        scrollCtrler.framesQuantity = GetMergeFromList(ref scrollCtrler.framesList, equipFrame, equipmentUIAll);
        scrollCtrler.SetPaddingsSize();
        scrollCtrler.RevealFirstFrames();
    }
    public void EnableScreenPhase2(ItemScrollCtrler scrollCtrler, EquipFrame equipFrame)
    {
        scrollCtrler.framesList.Remove(equipFrame);
        scrollCtrler.framesQuantity--;
        scrollCtrler.SetPaddingsSize();
        scrollCtrler.RevealFirstFrames();
    }
    public void DisableScreen(ItemScrollCtrler scrollCtrler)
    {
        scrollCtrler.HideCurrentFrames();
    }
    public void GetMergeableList(EquipmentUIAll equipmentUIAll, ref List<EquipFrame> equipList)
    {
        if (equipList == null)
        {
            equipList = new();
        }
        else
        {
            equipList.Clear();
        }

        foreach(var eui in equipmentUIAll.EUIs)
        {
            if (eui.equipedOne != null)
            {
                var type = eui.equipedOne.equipment.equipType;
                if (eui.equipsLists[(int)type].Count >= 2)
                {
                    equipList.Add(eui.equipedOne);
                }
            }
        }
        var rankList = System.Enum.GetValues(typeof(ItemRank));
        int n = rankList.Length;
        for (int i = n - 1; i >= 0; i--)
        {
            foreach (var eui in equipmentUIAll.EUIs)
            {
                if (eui.equipedOne != null)
                {
                    if (eui.equipsLists[i].Count >= 2)
                    {
                        equipList.AddRange(eui.equipsLists[i]);
                    }
                }
                if (eui.equipsLists[i].Count >= 3)
                {
                    equipList.AddRange(eui.equipsLists[i]);
                }
            }
        }

        //if (equipedOne != null) equipList.Add(equipedOne);
        //int n = equipsLists.Count;
        //for (int i = n - 1; i >= 0; i--)
        //{
        //    equipList.AddRange(equipsLists[i]);
        //}
    }
}
