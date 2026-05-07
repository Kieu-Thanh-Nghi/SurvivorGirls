using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrencyQuanText : MonoBehaviour
{
    [SerializeField] TMP_Text quanText;
    [SerializeField] Currency currency;
    // Start is called before the first frame update
    void Start()
    {
        var currencyData = Database.instance.currencyData;
        quanText.text = currencyData[currency].ToString("N0");

        currencyData.AfterSetCurrency += UpdateText;
    }

    void UpdateText(Currency currencyType, int quantity)
    {
        if(currencyType == currency)
        {
            quanText.text = quantity.ToString("N0");
        }
    }

    private void OnDestroy()
    {
        Database.instance.currencyData.AfterSetCurrency -= UpdateText;
    }
}
