using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyMoreMaterial : MonoBehaviour, IPayable
{
    [SerializeField] TMP_Text neededQuantityText;
    [SerializeField] Currency currencyType;
    [SerializeField] float priceForAMaterial;
    [SerializeField] PayButton payButton;
    int neededQuantity;

    public void DonePaying()
    {
        Database.instance.currencyData[currencyType] += neededQuantity;
        gameObject.SetActive(false);
    }

    public void OpenBuyMoreUI(int quantityToBuy)
    {
        neededQuantity = quantityToBuy;
        neededQuantityText.text = quantityToBuy.ToString();
        int totalPrice = Mathf.FloorToInt(priceForAMaterial * quantityToBuy);
        payButton.SetBuyInfoAndCheckEnough(totalPrice, this);
        gameObject.SetActive(true);
    }
}
