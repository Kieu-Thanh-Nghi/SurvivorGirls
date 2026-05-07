using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "EquipType", menuName = "ScriptableObjects/PlayerEquipTypes")]
public class EquipType : ScriptableObject 
{
#if UNITY_EDITOR
    //[SerializeField] bool isAvalable;
    //[SerializeField] int dataType;
    //private void OnValidate()
    //{
    //    if (isAvalable)
    //    {
    //        if (dataType == 0)
    //        {
    //            var ebp_int = new EquipmentBonusPoint_Int();
    //            equipmentBonusPoints.Add(ebp_int);
    //        }
    //        if (dataType == 1)
    //        {
    //            var ebp_float = new EquipmentBonusPoint_Float();
    //            equipmentBonusPoints.Add(ebp_float);
    //        }
    //    }
    //}
    [ContextMenu("add int")]
    void AddInt()
    {
        var ebp_int = new EquipmentBonusPoint_Int();
        equipmentBonusPoints.Add(ebp_int);
    }
    [ContextMenu("add float")]
    void AddFloat()
    {
        var ebp_float = new EquipmentBonusPoint_Float();
        equipmentBonusPoints.Add(ebp_float);
    }
#endif
    [SerializeReference] internal List<IBonusPoint> equipmentBonusPoints = new();
    public void EquipUpdate(int currentLvl)
    {
        foreach(var changer in equipmentBonusPoints)
        {
            changer.IncreasePlayerData(currentLvl);
        }
    }
    public void UnEquipUpdate(int currentLvl)
    {
        foreach (var changer in equipmentBonusPoints)
        {
            changer.DecreasePlayerData(currentLvl);
        }
    }
}
