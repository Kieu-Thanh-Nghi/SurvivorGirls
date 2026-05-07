using UnityEngine;
using UnityEngine.Events;

public class EquippingSkin : PlayerEquipableItem
{
    [SerializeField] internal int bonusAtk;
    [SerializeField] internal GameObject SkinInfoUI;

    public override void Equip()
    {
        base.Equip();
        Database.instance.playerData[IntPlayerData.Atk] += bonusAtk;
    }

    public override void UnEquip()
    {
        base.UnEquip();
        Database.instance.playerData[IntPlayerData.Atk] -= bonusAtk;
    }
}