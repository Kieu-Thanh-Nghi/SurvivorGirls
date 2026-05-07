using UnityEngine;
using UnityEngine.Events;

public class Product_InGameCurrency : ShopProduct
{
    [SerializeField] internal Currency currencyType;
    [SerializeField] UnityEvent<int> DoWhenAchive;
    public override void AchiveProduct()
    {
        Debug.Log(ProductAmount);
        Database.instance.currencyData[currencyType] += ProductAmount;
        DoWhenAchive?.Invoke(ProductAmount);
    }

    public override Sprite GetIcon()
    {
        return UIDatas.Instance.CurrencyIcon[(int)currencyType];
    }
}
