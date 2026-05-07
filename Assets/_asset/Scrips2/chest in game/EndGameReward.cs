using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameReward : MonoBehaviour
{
    [SerializeField] internal float conditionTime;
    [SerializeField] internal bool isClearGameRaward;
    [SerializeField] ShopProduct product;
    internal Sprite Icon => product.GetIcon();
    internal int Quantity => product.ProductAmount;

    public bool CheckIfMeetCondition()
    {
        return GamePlayCtrler.Instance.CountingTime >= conditionTime;
    }

    public void TakeTheReward()
    {
        product.AchiveProduct();
    }
}
