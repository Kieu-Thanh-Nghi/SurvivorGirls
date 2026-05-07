using UnityEngine;

public class EquipmentReward : ShopReward<Equipment>
{
    [SerializeField] int[] rankWeight;
    public override Equipment GetReward()
    {
        var newEquipment 
            = new Equipment(RandomEquiType(), RandomMat(), RandomRank(), 1);
        Database.instance.equipmentCreater.AddAndSaveAnEquipment(newEquipment);
        return newEquipment;
    }

    EquipMat RandomMat()
    {
        return (EquipMat)Random.Range(0, Database.instance.EquipMatArr.Length);
    }
    TypeOfEquipment RandomEquiType()
    {
        return (TypeOfEquipment)Random.Range(0, Database.instance.EquipTypeArr.Length);
    }
    ItemRank RandomRank()
    {
        int[] rankArr = Database.instance.ItemRankArr as int[];
        return (ItemRank)RandomWeighted.GetRandom<int>(rankArr, rankWeight);
    }
}
