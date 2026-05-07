using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class PayButton_CurrencyInGame : PayButton
{
    [SerializeField] Currency currencyType;
    [SerializeField] RectTransform rectTransform;
    [SerializeField] protected UnityEvent WhenNotEnough, WhenEnough;
    bool isClickingPaying;

    private void OnEnable()
    {
        Database.instance.currencyData.AfterSetCurrency += DoWhenQuanityChange;
        isClickingPaying = false;
    }
    private void OnDisable()
    {
        Database.instance.currencyData.AfterSetCurrency -= DoWhenQuanityChange;
    }
    public override void SetBuyInfo(int neededAmount, IPayable payable)
    {
        base.SetBuyInfo(neededAmount, payable);
        if(rectTransform != null) LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
    }
    public override string GetCurrencyAmountText()
    {
        return CurrencyAmount.ToString();
    }
    public override void AcceptPay()
    {
        var currencyData = Database.instance.currencyData;
        var gotAmount = currencyData[currencyType];
        var needAmount = CurrencyAmount;
        if (gotAmount >= needAmount)
        {
            isClickingPaying = true;
            currencyData[currencyType] = gotAmount - needAmount;
        }
    }
    
    public void DoWhenQuanityChange(Currency theCurrencyType, int haveAmount)
    {
        if (theCurrencyType != currencyType) return;
        DoWhenQuanityChange(haveAmount);
    }
    public override void DoWhenQuanityChange(int haveAmount)
    {
        if (isClickingPaying)
        {
            payable.DonePaying();
            isClickingPaying = false;
        }
        CheckIfEnough(GetHaveAmount());
    }

    public override int GetHaveAmount()
    {
        var currencyData = Database.instance.currencyData;
        return currencyData[currencyType];
    }

    public override void CheckIfEnough(int haveAmount)
    {
        var needAmount = CurrencyAmount;
        if (haveAmount >= needAmount)
        {
            thisButton.enabled = true;
            buttonBG.sprite = onSprite;
            WhenEnough?.Invoke();
        }
        else
        {
            thisButton.enabled = false;
            buttonBG.sprite = offSprite;
            WhenNotEnough?.Invoke();
        }
    }
}

public abstract class PayButton : MonoBehaviour
{
    internal int CurrencyAmount;
    internal IPayable payable;
    [SerializeField] protected TMP_Text price;
    [SerializeField] protected Image buttonBG;
    [SerializeField] protected Sprite onSprite, offSprite;
    [SerializeField] protected Button thisButton;

    public abstract int GetHaveAmount();
    public abstract void DoWhenQuanityChange(int haveAmount);
    public abstract void CheckIfEnough(int haveAmount);
    public virtual void SetBuyInfoAndCheckEnough(int neededAmount, IPayable payable)
    {
        SetBuyInfo(neededAmount, payable);
        CheckIfEnough(GetHaveAmount());
    }
    public virtual void SetBuyInfo(int neededAmount, IPayable payable)
    {
        CurrencyAmount = neededAmount;
        this.payable = payable;
        price.text = GetCurrencyAmountText();
    }
    public abstract void AcceptPay();
    public abstract string GetCurrencyAmountText();
}

public interface IPayable
{
    public void DonePaying();
}
