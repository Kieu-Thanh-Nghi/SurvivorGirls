using UnityEngine;

public class PageChanger : MonoBehaviour
{
    [SerializeField] internal APage currentPage;
    protected void Start()
    {
        currentPage.EnableThisPage();
    }
    public void ChangePageTo(APage newPage)
    {
        currentPage.DisableThisPage();
        newPage.EnableThisPage();
        currentPage = newPage;
    }
}