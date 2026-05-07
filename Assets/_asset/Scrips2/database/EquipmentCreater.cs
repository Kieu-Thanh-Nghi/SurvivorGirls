using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EquipmentCreater : MonoBehaviour
{
    [SerializeField] int createNumber = 200;
    [SerializeField] internal UnityEvent<Equipment, bool> DoWhenAddEquipment;

    //
    [ContextMenu("createRandomEquipments")]
    public void AddEquipments()
    {
        for(int i = 0; i < createNumber; i++)
        {
            AddAndSaveRandomEquipment();
        }
    }
    [ContextMenu("createRandom")]
    public void AddAndSaveRandomEquipment()
    {
        var newEquipment = RandomEquipmentInfo();
        AddAndSaveAnEquipment(newEquipment);
    }
    //

    public void AddAndSaveAnEquipment(Equipment newEquipment, bool isEquipThis = false)
    {
        Debug.Log(newEquipment.equipType + "-" + newEquipment.equipMat + "--" + newEquipment.rank);
        var theType = newEquipment.equipType;
        newEquipment.id = CreateEquipmentNewID(theType);
        var infosContainer = Database.instance.playerEquipments[theType];
        if (isEquipThis)
        {
            infosContainer.equipInfos.Insert(0, newEquipment);
        }
        else
        {
            infosContainer.equipInfos.Add(newEquipment);
        }
        infosContainer.SaveEquipInfos(theType.ToString());
        DoWhenAddEquipment.Invoke(newEquipment, isEquipThis);
    }
    public void RemoveAnEquimentAndSave(Equipment theEquipment)
    {
        var theType = theEquipment.equipType;
        var infosContainer = Database.instance.playerEquipments[theType];
        infosContainer.equipInfos.Remove(theEquipment);
        infosContainer.SaveEquipInfos(theType.ToString());
    }
    public void RemoveEquimentsAndSave(List<Equipment> equipments, TypeOfEquipment type)
    {
        var infosContainer = Database.instance.playerEquipments[type];
        foreach (var equipment in equipments)
        {
            infosContainer.equipInfos.Remove(equipment);
        }
        infosContainer.SaveEquipInfos(type.ToString());
    }
    public int CreateEquipmentNewID(TypeOfEquipment type)
    {
        var equipInfos = Database.instance.playerEquipments[type].equipInfos;
        int equipmentQuantity = equipInfos.Count;
        int id = 0;
        if (equipmentQuantity > 0)
        {
            id = equipInfos[equipmentQuantity - 1].id + 1;
            if (Database.instance.playerEquipments.CheckIsUsing(type))
            {
                if (id == equipInfos[0].id) id++;
            }
        }
        return id;
    }

    //
    Equipment RandomEquipmentInfo()
    {
        int randomMat = GetRandomVal<EquipMat>();
        int randomType = GetRandomVal<TypeOfEquipment>();
        int randomRank = GetRandomVal<ItemRank>();
        var equipInfos = Database.instance.playerEquipments[(TypeOfEquipment)randomType].equipInfos;
        int equipmentQuantity = equipInfos.Count;
        return new Equipment(
            (TypeOfEquipment)randomType, 
            (EquipMat)randomMat, 
            (ItemRank)randomRank,
            1);
    }
    //
    //
    int GetRandomVal<T>() where T : System.Enum
    {
        int n = GetEnumLength<T>();
        return Random.Range(0, n);
    }

    int GetEnumLength<T>() where T : System.Enum
    {
        return System.Enum.GetValues(typeof(T)).Length;
    }
    //
}