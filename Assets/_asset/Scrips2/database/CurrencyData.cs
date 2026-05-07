using AASave;
using UnityEngine.Events;

public class CurrencyData : IntListOfDatas_EnumBase<Currency>
{
    internal UnityAction<Currency, int> AfterSetCurrency;
    protected override void SaveIndexes(Currency indexes, int val)
    {
        base.SaveIndexes(indexes, val);
        AfterSetCurrency?.Invoke(indexes, val);
    }
}
public enum Currency
{
    Chip = 0,
    Gold = 1,
    Diamond = 2,
    Money = 3
}