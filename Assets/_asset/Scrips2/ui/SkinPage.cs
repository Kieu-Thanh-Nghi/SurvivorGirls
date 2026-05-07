using UnityEngine;
public class SkinPage : CharacterPage
{
    [SerializeField] CharacterSkinChoosing characterSkinChoosing;
    public override void EquipThisOne()
    {
        choosing.EquipToSelectingSkin();
        SaveToDatabase();
    }
    public void SaveToDatabase()
    {
        var skinData = Database.instance.playerItems.skinData;
        var charSkinIndex = choosing.currentSkinButton.theSkinIndex;
        if (!skinData.CheckIfItemHasBought(charSkinIndex))
        {
            skinData.ChangeAndSaveSkinBoughtInfo(charSkinIndex, true);
        }
        skinData.equippingItemIndex = charSkinIndex;
    }
    public override void AfterPaid()
    {
        EquipThisOne();
    }

    private void OnDisable()
    {
        characterSkinChoosing.thePreview.RevealNeededSkin(true);
    }
}
