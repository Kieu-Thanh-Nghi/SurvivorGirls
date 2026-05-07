using UnityEngine;

public class CharacterPageChanger : PageChanger, IPayable
{
    internal CharacterPage currentCharPage 
    {
        get => currentPage as CharacterPage;
        set => currentPage = value;
    }

    public void DonePaying()
    {
        currentCharPage.AfterPaid();
    }

    public void Equip()
    {
        currentCharPage.EquipThisOne();
    }
}
public abstract class APage : MonoBehaviour
{
    public abstract void EnableThisPage();
    public abstract void DisableThisPage();
}
