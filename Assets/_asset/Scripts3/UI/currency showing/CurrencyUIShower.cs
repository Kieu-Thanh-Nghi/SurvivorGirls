using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TigerForge;
using TMPro;

public class CurrencyUIShower : MonoBehaviour
{
    [SerializeField] CurrencyType currencyType;
    [SerializeField] TMP_Text amount;
    private void Start()
    {
        EventManager.StartListening(currencyType.ToString(), ShowCurrencyAmount);
        Debug.Log("CurrencyUIShower: StartListening | " + currencyType.ToString());
        amount.text = DatabaseManager.Instance.currencyDatas.LoadCurrencyData(currencyType).ToString("N0");
    }

    void ShowCurrencyAmount()
    {
        var currencyAmount = EventManager.GetInt(currencyType.ToString()).ToString("N0");
        amount.text = currencyAmount;
        Debug.Log("CurrencyUIShower: ShowAmount | " + currencyAmount);
    }
}
