using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipsUIManager : MonoBehaviour
{
    [SerializeField] internal ItemScrollCtrler scrollCtrler;
    [SerializeField] EquipmentUIAll equipmentUIAll;
    [SerializeField] internal EquipUIButton currentScreen;
    [SerializeField] ScrollRect scroll;
    [SerializeField] List<Transform> equipedEquipmentframes;
    [SerializeField] internal MergeEquipment mergeEquipment;
    bool isLoad;

    private void Awake()
    {
        Database.instance.equipmentCreater.DoWhenAddEquipment.AddListener(AddAnEquipFrame);
    }
    private void OnDestroy()
    {
        Database.instance.equipmentCreater.DoWhenAddEquipment.RemoveListener(AddAnEquipFrame);
    }
    private void OnEnable()
    {
        if (!isLoad)
        {
            isLoad = true;
            equipmentUIAll.StartSetUp();
            foreach (var eui in equipmentUIAll.EUIs)
            {
                if(eui.equipedOne != null)
                {
                    var frame = Instantiate(UIDatas.Instance.equipFramePrefab,
                        equipedEquipmentframes[(int)eui.type]);
                    frame.SetupEquipPresent(eui.equipedOne.equipment);
                    frame.gameObject.SetActive(true);
                    frame.EquipMarkWhenInEquippedFrame();
                }
            }
            mergeEquipment.Setup(equipmentUIAll.EUIs);
        }
        EnableCurrentScreen();
    }
    private void OnDisable()
    {
        mergeEquipment.OnOffMerge(false);
        DisableCurrentScreen();
    }
    public void ActiveEquipFrame(EquipFrame equipFrame)
    {
        if (mergeEquipment.isMergeStage)
        {
            mergeEquipment.PrepareToMerge(equipFrame, equipmentUIAll);
        }
        else
        {
            var equipSpecs = UIManager.instance.equipmentSpecs;
            equipSpecs.SetEquipSpecs(equipFrame);
            equipSpecs.gameObject.SetActive(true);
        }
    }
    public void DoWhenLvlUp(EquipFrame equipFrame)
    {
        equipmentUIAll.SetPositionInList(equipFrame);
    }
    public void EquipANewEquiment(EquipFrame equipFrame)
    {
        SetEquippedFrame(equipFrame.equipment);
        equipmentUIAll.SetEquipedOnes(equipFrame);
        //DisableCurrentScreen();
        //EnableCurrentScreen();
    }
    internal void SetEquippedFrame(Equipment equipment)
    {
        var equipedframes = equipedEquipmentframes[(int)equipment.equipType];
        var didEquipedOne = equipedframes.GetComponentInChildren<EquipFrame>();
        if (didEquipedOne != null)
        {
            Destroy(didEquipedOne.gameObject);
        }

        var frame = Instantiate(UIDatas.Instance.equipFramePrefab, equipedframes);
        frame.SetupEquipPresent(equipment);
        frame.gameObject.SetActive(true);
        frame.EquipMarkWhenInEquippedFrame();
    }
    public void UnequipAnEquipment(EquipFrame equipFrame)
    {
        var type = equipFrame.equipment.equipType;
        var equipedframes = equipedEquipmentframes[(int)type];
        var didEquipedOne = equipedframes.GetComponentInChildren<EquipFrame>();
        if (didEquipedOne != null)
        {
            Destroy(didEquipedOne.gameObject);
        }
        equipmentUIAll.RemoveAnEquipedFrame(type);
        //DisableCurrentScreen();
        //EnableCurrentScreen();
    }
    public void AddAnEquipFrame(Equipment equipment, bool isEquipThis)
    {
        if (!isLoad) return;
        Debug.Log("s1");
        equipmentUIAll.AddNewEquipment(equipment, isEquipThis);
        mergeEquipment.UpdateMergeable(equipment, equipmentUIAll.EUIs);
        if(isEquipThis) SetEquippedFrame(equipment);
    }
    public void RemoveAnEquipFrame(EquipFrame equipFrame)
    {
        if (!isLoad) return;
        Debug.Log("s2");
        equipmentUIAll.RemoveAFrame(equipFrame);
        mergeEquipment.UpdateMergeable(equipFrame.equipment, equipmentUIAll.EUIs);
    }
    public void ChangeScreenTo(EquipUIButton newScreen)
    {
        if (currentScreen != null)
        {
            DisableCurrentScreen();
        }
        currentScreen = newScreen;
        EnableCurrentScreen();
    }

    public void EnableCurrentScreen()
    {
        if (mergeEquipment.isMergeStage)
        {
            ItemScrollCtrler scrollCtrler = UIManager.instance.equipsUIManager.scrollCtrler;
            var equipUI = currentScreen.EquipUI;
            if (equipUI is EquipmentUIAll all)
            {
                mergeEquipment.EnableScreenAll(scrollCtrler, all.EUIs);
            }
            else if (equipUI is EquipmentUI one)
            {
                mergeEquipment.EnableScreenOne(scrollCtrler, one);
            }
        }
        else
        {
            currentScreen.EquipUI.EnableScreen();
        }
        currentScreen.activeEff.enabled = true;
        currentScreen.selectButton.enabled = false;
        scroll.verticalNormalizedPosition = 1;
    }
    public void DisableCurrentScreen()
    {
        currentScreen.EquipUI.DisableScreen();
        currentScreen.activeEff.enabled = false;
        currentScreen.selectButton.enabled = true;
    }
}