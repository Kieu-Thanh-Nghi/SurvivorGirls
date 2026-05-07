using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipments : MonoBehaviour
{
    [SerializeField] internal List<ListOfEquipInfos> EquipInfosListses;
    [SerializeField] string check_extendName;
    [SerializeField] bool check_BackupVal = false;
    internal EquipFrameComparer equipFrameComparer = new();

#if UNITY_EDITOR
    [SerializeField] bool isValidate;
    private void OnValidate()
    {
        if (isValidate)
        {
            foreach (var type in System.Enum.GetValues(typeof(TypeOfEquipment)))
            {
                EquipInfosListses.Add(new ListOfEquipInfos());
            }
        }
    }
#endif
    public ListOfEquipInfos this[TypeOfEquipment theType]
    {
        get
        {
            return EquipInfosListses[(int)theType];
        }
    }
    public Equipment this[TypeOfEquipment type, int index]
    {
        get
        {
            return EquipInfosListses[(int)type].GetEquipment(index);
        }
    }
    public Equipment GetCurrentEquipment(TypeOfEquipment type)
    {
        if (!CheckIsUsing(type)) return null;
        List<Equipment> equipments = this[type].equipInfos;
        if (equipments.Count < 1) return null;
        return equipments[0];
    }
    public bool CheckIsUsing(TypeOfEquipment type)
    {
        return Database.instance.saveSystem.Load(check_extendName + type.ToString(), check_BackupVal);
    }
    public void SetUsingEquipment(TypeOfEquipment type, bool isUsing)
    {
        Database.instance.saveSystem.Save(check_extendName + type.ToString(), isUsing);
    }
    public void ConfigCurrentEquipments()
    {
        foreach (var type in System.Enum.GetValues(typeof(TypeOfEquipment)))
        {
            var itemType = (TypeOfEquipment)type;
            this[itemType].LoadEquipInfos(itemType.ToString());
            GetCurrentEquipment(itemType)?.Equip();
        }
    }
    public void EquipmentEquip(Equipment equipment)
    {
        var type = equipment.equipType;
        var listOfEquipInfos = this[type];
        var equipList = listOfEquipInfos.equipInfos;

        int index = equipList.IndexOf(equipment);
        GetCurrentEquipment(type)?.UnEquip();
        (equipList[0], equipList[index]) = (equipList[index], equipList[0]);
        equipment.Equip();
        listOfEquipInfos.SaveEquipInfos(type.ToString());
        SetUsingEquipment(type, true);
    }

    public void EquipmentUnequip(Equipment equipment)
    {
        var type = equipment.equipType;
        SetUsingEquipment(type, false);
        equipment.UnEquip();
    }
}
