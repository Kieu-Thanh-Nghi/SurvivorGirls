using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AASave;
using TigerForge;

public class CurrencyDatas : MonoBehaviour
{
    [SerializeField] SaveSystem SSForCurrency;
    public int LoadCurrencyData(CurrencyType currencyType)
    {
        Debug.Log("CurrencyData: Load");
        return SSForCurrency.Load(currencyType.ToString(), 0);
    }

    public void ChangeCurrencyData(CurrencyType currencyType, int changeAmount)
    {
        Debug.Log("CurrencyData: Change");
        var oldAmount = LoadCurrencyData(currencyType);
        var newAmount = oldAmount + changeAmount;
        SSForCurrency.Save(currencyType.ToString(), newAmount);
        Debug.Log("CurrencyData: Save");
        EventManager.EmitEventData(currencyType.ToString(), newAmount);
        Debug.Log("CurrencyData: EmitData");
    }

#if UNITY_EDITOR
    [ContextMenu("test add")]
    public void TestAddAmount()
    {
        ChangeCurrencyData(CurrencyType.Gold, 100);
    }
#endif
}

public enum CurrencyType
{
    Chip = 0,
    Gold = 1,
    Diamon = 2,
}