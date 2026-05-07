public class PayButton_WeaponRankUp : PayButton_CurrencyInGame
{
    public override string GetCurrencyAmountText()
    {
        return GetCurrencyAmountText(CurrencyAmount, GetHaveAmount());
    }
    public override void DoWhenQuanityChange(int haveAmount)
    {
        price.text = GetCurrencyAmountText(CurrencyAmount, haveAmount);
        base.DoWhenQuanityChange(haveAmount);
    }
    string GetCurrencyAmountText(int needAmount, int haveAmount)
    {
        return "[ " + needAmount + "/" + haveAmount + " ]";
    }
    public override void CheckIfEnough(int haveAmount)
    {
        var needAmount = CurrencyAmount;
        if (haveAmount >= needAmount)
        {
            WhenEnough?.Invoke();
        }
        else
        {
            WhenNotEnough?.Invoke();
        }
    }
}
