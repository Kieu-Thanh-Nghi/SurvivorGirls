using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseButtonUIUpdater_InGameCurrency : PurchaseButtonUIUpdater
{
    [SerializeField] PurchaseButton_InGameCurrency theButton;
    [SerializeField] RectTransform rectTransform;
    [SerializeField] protected TMP_Text price;


    private void Start()
    {
        CheckIfEnough(GetHaveAmount());
        SetPriceText();
    }
    private void OnEnable()
    {
        Database.instance.currencyData.AfterSetCurrency += DoWhenQuanityChange;
    }
    private void OnDisable()
    {
        Database.instance.currencyData.AfterSetCurrency -= DoWhenQuanityChange;
    }
    public virtual void SetPriceText()
    {
        price.text = GetCurrencyAmountText();
        if (rectTransform != null) LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
    }
    public string GetCurrencyAmountText()
    {
        return theButton.price.ToString();
    }
    public void DoWhenQuanityChange(Currency theCurrencyType, int haveAmount)
    {
        if (theCurrencyType != theButton.currencyType) return;
        CheckIfEnough(GetHaveAmount());
    }
    public int GetHaveAmount()
    {
        var currencyData = Database.instance.currencyData;
        return currencyData[theButton.currencyType];
    }
    public void CheckIfEnough(int haveAmount)
    {
        if (haveAmount >= theButton.price)
        {
            TurnOnButton();
        }
        else
        {
            TurnOffButton();
        }
    }
}

public class PurchaseButtonUIUpdater : MonoBehaviour
{
    [SerializeField] protected Image buttonBG;
    [SerializeField] protected Sprite onSprite, offSprite;
    [SerializeField] protected Button thisButton;

    protected virtual void TurnOnButton()
    {
        thisButton.enabled = true;
        buttonBG.sprite = onSprite;
    }
    protected virtual void TurnOffButton()
    {
        thisButton.enabled = false;
        buttonBG.sprite = offSprite;
    }
}
