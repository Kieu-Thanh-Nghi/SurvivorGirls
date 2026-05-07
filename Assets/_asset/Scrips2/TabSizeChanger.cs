using UnityEngine;
using UnityEngine.Events;

public class TabSizeChanger : MonoBehaviour
{
    [SerializeField] RectTransform rectTransform;
    [SerializeField] SelectTabSize tabSize;
    [SerializeField] UnityEvent WhenResetSize;

    [ContextMenu("test1")] 
    public void SetTabSize()
    {
        Vector2 offsetMin = rectTransform.offsetMin;
        Vector2 offsetMax = rectTransform.offsetMax;
        offsetMin.x = tabSize.MinX;
        offsetMax.x = tabSize.MaxX;
        offsetMax.y = tabSize.MaxY;

        rectTransform.offsetMin = offsetMin;
        rectTransform.offsetMax = offsetMax;
        SetCurrentTab();
    }
    void SetCurrentTab()
    {
        var tabManager = transform.parent.GetComponent<MenuTabManager>();
        tabManager?.ResetCurrentTab();
        tabManager?.SetCurrentTab(this);
    }
    [ContextMenu("test2")]
    public void ResetTabSize()
    {
        rectTransform.offsetMin = Vector2.zero;
        rectTransform.offsetMax = Vector2.zero;
        WhenResetSize?.Invoke();
    }
}
