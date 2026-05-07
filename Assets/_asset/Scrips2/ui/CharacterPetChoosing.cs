public class CharacterPetChoosing : CharacterSkinChoosing
{
    public override PlayerItemsData itemsData => Database.instance.playerItems.PetData;
    public override SkinPreview thePreview => UIManager.instance.petPreview;
}
