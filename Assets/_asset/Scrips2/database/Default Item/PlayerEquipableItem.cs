using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipableItem : MonoBehaviour, IEquipable
{
    [SerializeField] internal List<PlayerDataChanger> dataChangers;
    public virtual void Equip()
    {
        foreach(var changer in dataChangers)
        {
            changer.ChangeData();
        }
    }

    public virtual void UnEquip()
    {
        foreach (var changer in dataChangers)
        {
            changer.ChangeData(true);
        }
    }
}
