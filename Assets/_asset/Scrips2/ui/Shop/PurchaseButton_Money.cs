using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Purchasing;
using TMPro;

public class PurchaseButton_Money : MonoBehaviour
{
    [SerializeField] UnityEvent DoAfterPay;
    [SerializeField] TMP_Text priceNumber;
    public void WhenOrderConfirm(ConfirmedOrder confirmedOrder)
    {
        Product product = confirmedOrder.CartOrdered.Items()[0].Product;
        Debug.Log("PurchaseButton_Money: Done purchase - id: " + product.definition.id);
        DoAfterPay.Invoke();
    }

    public void DoWhenProductFetch(Product product)
    {
        priceNumber.text = product.metadata.localizedPriceString;
        Debug.Log("PurchaseButton_Money: DoWhenProductFetch - priceNumberText: " + product.metadata.localizedPriceString);
    }
}