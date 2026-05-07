using UnityEngine;

public class PageButton : MonoBehaviour
{
    [SerializeField] TabSizeChanger tabSizeChanger;
    [SerializeField] GameObject SelectTab;
    public void DeActive()
    {
        tabSizeChanger.ResetTabSize();
        SelectTab.SetActive(false);
        transform.SetSiblingIndex(0);
    }

    public void Active()
    {
        tabSizeChanger.SetTabSize();
        SelectTab.SetActive(true);
    }
}