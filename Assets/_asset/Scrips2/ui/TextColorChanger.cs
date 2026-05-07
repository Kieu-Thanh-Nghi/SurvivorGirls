using UnityEngine;
using TMPro;

public class TextColorChanger : MonoBehaviour
{
    [SerializeField] TMP_Text theText;
    [SerializeField] Color color;

    public void ChangeTextColor()
    {
        theText.color = color;
    }
}