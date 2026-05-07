using UnityEngine;

public abstract class CharacterPage : APage
{
    [SerializeField] PageButton pageButton;
    [SerializeField] GameObject physicalPage;
    [SerializeField] GameObject aboutSkin;
    [SerializeField] internal CharacterSkinChoosing choosing;

    public override void DisableThisPage()
    {
        pageButton.DeActive();
        physicalPage.SetActive(false);
        aboutSkin.SetActive(false);
    }

    public override void EnableThisPage()
    {
        pageButton.Active();
        physicalPage.SetActive(true);
        aboutSkin.SetActive(true);
    }

    public abstract void AfterPaid();

    public abstract void EquipThisOne();
}
