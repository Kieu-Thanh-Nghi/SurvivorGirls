public class PayButton_Money : PayButton
{
    public override void AcceptPay()
    {
        payable.DonePaying();
    }

    public override string GetCurrencyAmountText()
    {
        return CurrencyAmount.ToString("N0");
    }

    public override int GetHaveAmount()
    {
        return 0;
    }

    public override void DoWhenQuanityChange(int haveAmount)
    {
        
    }

    public override void CheckIfEnough(int haveAmount)
    {
        
    }
}
