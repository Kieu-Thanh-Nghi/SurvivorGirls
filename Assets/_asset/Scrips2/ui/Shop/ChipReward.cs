using System.Collections.Generic;
using UnityEngine;

public class ChipReward : ShopReward<int>
{
    [SerializeField] int randomFrom, randomTo;

    public override int GetReward() => RandomChipReward();

    public int RandomChipReward()
    {
        int randomQuantity = Random.Range(randomFrom, randomTo);
        Database.instance.currencyData[Currency.Chip] += randomQuantity;
        return randomQuantity;
    }
}

public class RandomWeighted
{
    public static T GetRandom<T>(T[] items, int[] weights)
    {
        int totalWeight = 0;

        // Tính tổng weight
        for (int i = 0; i < weights.Length; i++)
        {
            totalWeight += weights[i];
        }

        // Random từ 0 -> totalWeight
        int randomValue = Random.Range(0, totalWeight);

        // Duyệt để tìm phần tử
        int currentWeight = 0;
        int n = items.Length;
        for (int i = 0; i < n; i++)
        {
            currentWeight += weights[i];

            if (randomValue < currentWeight)
            {
                return items[i];
            }
        }

        return default;
    }
}