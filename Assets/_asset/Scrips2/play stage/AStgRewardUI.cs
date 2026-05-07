using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AStgRewardUI : MonoBehaviour
{
    [SerializeField] Product_InGameCurrency product;
    [SerializeField] AStgReward aStgReward;
    [SerializeField] Image rewardIcon;
    [SerializeField] TMP_Text rewardQuantity;
    [SerializeField] TMP_Text requiredTime;

    private void Start()
    {
        rewardIcon.sprite = UIDatas.Instance.CurrencyIcon[(int)product.currencyType];
        rewardQuantity.text = product.ProductAmount.ToString("N0");
        if(requiredTime != null) requiredTime.text = aStgReward.requiredPlaytime + "m";
    }
}
