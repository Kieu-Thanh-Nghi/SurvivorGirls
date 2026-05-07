using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ListOfEquipInfos
{
    [SerializeField] internal List<Equipment> equipInfos;

    public Equipment GetEquipment(int index)
    {
        if (index < 0 || index >= equipInfos.Count) return null;
        return equipInfos[index];
    }
    public void SaveEquipInfos(string name)
    {
        string json = GetThisJson();
        Database.instance.saveSystem.Save(name, json);
    }

    public void LoadEquipInfos(string name)
    {
        string json = Database.instance.saveSystem.Load(name, GetThisJson());
        equipInfos = JsonUtility.FromJson<ListOfEquipInfos>(json).equipInfos;
    }

    string GetThisJson()
    {
        return JsonUtility.ToJson(this, true);
    }
}

[System.Serializable]
public class Equipment : IEquipable
{
    [SerializeField] internal TypeOfEquipment equipType;
    [SerializeField] internal EquipMat equipMat;
    [SerializeField] internal ItemRank rank;
    [SerializeField] internal int id;
    [SerializeField] int level = 1;
    internal int Level
    {
        get => level;
        set
        {
            level = value;
            DoWhenLvlChange?.Invoke(value);
        }
    }
    internal UnityAction<int> DoWhenLvlChange;

    public Equipment() { Level = 1; }
    public Equipment(TypeOfEquipment type, EquipMat mat, ItemRank itemRank, int lvl, int theId)
    {
        equipType = type;
        equipMat = mat;
        rank = itemRank;
        Level = lvl;
        id = theId;
    }
    public Equipment(TypeOfEquipment type, EquipMat mat, ItemRank itemRank, int lvl)
    {
        equipType = type;
        equipMat = mat;
        rank = itemRank;
        Level = lvl;
    }
    public void Equip()
    {
        Database.instance.equipTypes[(int)equipType].EquipUpdate(Level);
    }

    public void UnEquip()
    {
        Database.instance.equipTypes[(int)equipType].UnEquipUpdate(Level);
    }
}

public interface IEquipable
{
    public void Equip();
    public void UnEquip();
}

public enum EquipMat
{
    Bio = 0,
    Digital = 1,
    Leather = 2,
    metal = 3,
    Military = 4
}

public enum TypeOfEquipment
{
    Hat = 0,
    gloves = 1,
    shoes = 2,
    armor = 3,
    pants = 4
}

public enum ItemRank
{
    C = 0,
    B = 1,
    A = 2,
    S = 3,
    SS = 4,
    SSS = 5
}
