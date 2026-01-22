using UnityEngine;

public class TabSizeChanger : MonoBehaviour
{
    [SerializeField] RectTransform rectTransform;
    [SerializeField] SelectTabSize tabSize;

    [ContextMenu("test")] 
    public void SetTabSize()
    {
        Vector2 offsetMin = rectTransform.offsetMin;
        Vector2 offsetMax = rectTransform.offsetMax;
        offsetMin.x = tabSize.MinX;
        offsetMax.x = tabSize.MaxX;
        offsetMax.y = tabSize.MaxY;

        rectTransform.offsetMin = offsetMin;
        rectTransform.offsetMax = offsetMax;
    }
}
