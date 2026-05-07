using System.Collections.Generic;
using UnityEngine;

public class ManyChipsReward : ManyRewards<int> { }

public class ManyRewards<T> : ShopReward<List<T>>
{
    [SerializeField] int NumberOfReward;
    [SerializeField] ShopReward<T> theReward;
    public override List<T> GetReward() => GetManyRewards();

    public List<T> GetManyRewards()
    {
        var rewards = new List<T>();

        for (int i = 0; i < NumberOfReward; i++)
        {
            rewards.Add(theReward.GetReward());
        }

        return rewards;
    }
}