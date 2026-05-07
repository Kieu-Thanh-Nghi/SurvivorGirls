using UnityEngine;

public class CharacterPagePayButton : MonoBehaviour
{
    [SerializeField] protected GameObject equipMe, equipped;
    [SerializeField] protected PayButton buttonPayByDia, buttonPayByMoney;
    protected GameObject usingButton;

    public void SelectToEquip()
    {
        usingButton.SetActive(false);
        SetPayButton(equipped);
    }
    internal void ChoosePayButton(ChoosingButton theSkinButton, PlayerItemsData itemsData)
    {
        usingButton?.SetActive(false);
        bool HasBought = itemsData.CheckIfItemHasBought(theSkinButton.theSkinIndex);
        if (HasBought)
        {
            if (theSkinButton.theSkinIndex == itemsData.equippingItemIndex)
            {
                SetPayButton(equipped);
            }
            else
            {
                SetPayButton(equipMe);
            }
        }
        else
        {
            BuyInfo buyInfo = theSkinButton.skinBuyInfo;
            var type = buyInfo.currencyType;
            IPayable payable = UIManager.instance.CharacterPageChanger;
            switch (type)
            {
                case Currency.Diamond:
                    SetPayButton(buttonPayByDia.gameObject);
                    buttonPayByDia.SetBuyInfoAndCheckEnough(buyInfo.neededAmount, payable);
                    break;
                case Currency.Money:
                    SetPayButton(buttonPayByMoney.gameObject);
                    buttonPayByMoney.SetBuyInfoAndCheckEnough(buyInfo.neededAmount, payable);
                    break;
            }
        }
    }
    internal void SetPayButton(GameObject theButton)
    {
        theButton.SetActive(true);
        usingButton = theButton;
    }
}