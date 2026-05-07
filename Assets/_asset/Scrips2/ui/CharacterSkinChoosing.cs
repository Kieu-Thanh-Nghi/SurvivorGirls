using UnityEngine;
using UnityEngine.Events;

public class CharacterSkinChoosing : MonoBehaviour
{
    [SerializeField] internal ChoosingButton currentSkinButton;
    internal ChoosingButton tempSkinButton;
    [SerializeField] protected Transform SkinButtonsContainer;
    [SerializeField] protected CharacterPagePayButton payButtons;
    [SerializeField] protected GameObject equipMe, equipped;
    [SerializeField] protected PayButton_CurrencyInGame buttonPayByDia, buttonPayByMoney;
    [SerializeField] UnityEvent<int> OnSelectASkin;
    [SerializeField] UnityEvent<int, int> OnEquipSkin;
    protected GameObject usingButton;

    public virtual PlayerItemsData itemsData => Database.instance.playerItems.skinData;
    public virtual SkinPreview thePreview => UIManager.instance.skinPreview;

    protected void OnDisable()
    {
        var newSkinPrefab = itemsData.itemList[currentSkinButton.theSkinIndex];
        thePreview.ChangeCurrentSkin(newSkinPrefab, true);
    }
    protected void OnEnable()
    {
        ResetToUsingSkin();
    }
    public void ResetToUsingSkin()
    {
        tempSkinButton.SelectThisSkin(false);
        currentSkinButton.SelectThisSkin(true);
        var itemsData = this.itemsData;
        if(itemsData.equippingItemIndex != currentSkinButton.theSkinIndex)
        {
            ShowSkinPreview(currentSkinButton.theSkinIndex, itemsData, false);
        }
        payButtons.ChoosePayButton(currentSkinButton, itemsData);
        tempSkinButton = currentSkinButton;
    }
    public void EquipToSelectingSkin()
    {
        currentSkinButton.DeactiveEquippedMark();
        tempSkinButton.ActiveEquippedMark();
        OnEquipSkin?.Invoke(currentSkinButton.theSkinIndex, tempSkinButton.theSkinIndex);
        currentSkinButton = tempSkinButton;
        payButtons.SelectToEquip();
    }
    public void ConfigUsingSkin()
    {
        var itemsData = this.itemsData;
        int currentSkinIndex = itemsData.equippingItemIndex;
        ChoosingButton currentSkinButton;
        if (currentSkinIndex <= -1)
        {
            currentSkinButton = SkinButtonsContainer.GetChild(0)?
                .GetComponent<ChoosingButton>();
            currentSkinButton.SelectThisSkin(true);
        }
        else
        {
            currentSkinButton = SkinButtonsContainer.GetChild(currentSkinIndex)?
                .GetComponent<ChoosingButton>();
            currentSkinButton.ActiveEquippedMark();
        }
        this.currentSkinButton = currentSkinButton;
        tempSkinButton = currentSkinButton;
        ShowSkinPreview(currentSkinIndex, itemsData, true);
    }

    internal void ShowSkinPreview(int skinIndex, PlayerItemsData skinData, bool isEquipped)
    {
        if (skinIndex <= -1) return;
        var newSkinPrefab = skinData.itemList[skinIndex];
        thePreview.ChangeCurrentSkin(newSkinPrefab, isEquipped);
        OnSelectASkin?.Invoke(tempSkinButton.theSkinIndex);
    }

    public void SelectNewCharSkin(ChoosingButton newSkinButton)
    {
        tempSkinButton?.SelectThisSkin(false);
        var itemsData = this.itemsData;
        payButtons.ChoosePayButton(newSkinButton, itemsData);
        tempSkinButton = newSkinButton;
        ShowSkinPreview(tempSkinButton.theSkinIndex, itemsData, false);
    }
}
public interface IDonePaying
{
    public void GetWhatWeWant();
}
