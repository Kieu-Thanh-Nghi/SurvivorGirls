using System.Collections;
using UnityEngine;
using AASave;
using System.Collections.Generic;
using System;

public class Database : MonoBehaviour
{
    [SerializeField] internal SaveSystem saveSystem;

    [SerializeField] internal SaveSystem PlayStageSaveSystem;
    [SerializeField] internal PLStagePreparing pLStagePreparing;

    [SerializeField] internal PlayerNecessaries playerItems;
    [SerializeField] internal PlayerEquipments playerEquipments;
    [SerializeField] internal EquipmentCreater equipmentCreater;
    public static Database instance;
    internal CurrencyData currencyData = new();
    [SerializeField] internal PlayerData playerData;
    [SerializeField] internal List<EquipType> equipTypes;
    [SerializeField] internal List<EquipMaterial> equipMaterials;
    internal Array ItemRankArr, EquipTypeArr, EquipMatArr;

    private void Awake()
    {
        instance = this;
        EquipMatArr = Enum.GetValues(typeof(EquipMat));
        ItemRankArr = Enum.GetValues(typeof(ItemRank));
        EquipTypeArr = Enum.GetValues(typeof(TypeOfEquipment));
        DontDestroyOnLoad(gameObject);
        //test();
        playerEquipments.ConfigCurrentEquipments();
    }

#if UNITY_EDITOR
    [ContextMenu("testUsingEquipmentOn")]
    void test1()
    {
        playerEquipments.SetUsingEquipment(TypeOfEquipment.Hat, true);
        playerEquipments.SetUsingEquipment(TypeOfEquipment.gloves, true);
        playerEquipments.SetUsingEquipment(TypeOfEquipment.armor, true);
        playerEquipments.SetUsingEquipment(TypeOfEquipment.pants, true);
        playerEquipments.SetUsingEquipment(TypeOfEquipment.shoes, true);
    }
    [ContextMenu("testUsingEquipmentOff")]
    void test2()
    {
        playerEquipments.SetUsingEquipment(TypeOfEquipment.Hat, false);
        playerEquipments.SetUsingEquipment(TypeOfEquipment.gloves, false);
        playerEquipments.SetUsingEquipment(TypeOfEquipment.armor, false);
        playerEquipments.SetUsingEquipment(TypeOfEquipment.pants, false);
        playerEquipments.SetUsingEquipment(TypeOfEquipment.shoes, false);
    }

    public void MoreDia()
    {
        currencyData[Currency.Diamond] += 100;
    }

    [ContextMenu("ResetDia")]
    void ResetDia()
    {
        currencyData[Currency.Diamond] = 0;
    }    
    [ContextMenu("ResetChip")]
    void ResetChip()
    {
        currencyData[Currency.Chip] = 0;
    }
    public void MoreGold()
    {
        currencyData[Currency.Gold] += 100;
    }
#endif
}
