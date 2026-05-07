using UnityEngine;
using UnityEngine.Events;

public class PurchaseButton_InGameCurrency : PurchaseButton
{
    [SerializeField] internal int price;
    [SerializeField] internal Currency currencyType;
    [SerializeField] UnityEvent AfterPay;

    public override void PayThePrice()
    {
        Database.instance.currencyData[currencyType] -= price;
        AfterPay?.Invoke();
    }
}
