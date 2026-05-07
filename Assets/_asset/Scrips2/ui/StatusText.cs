using TMPro;
using UnityEngine;

public class StatusText : MonoBehaviour
{
    [SerializeField] protected TMP_Text dataText;
    [SerializeField] internal TextDataType textDataType;

    protected void OnValidate()
    {
        textDataType = GetComponent<TextDataType>();
    }

    private void OnEnable()
    {
        dataText.text = textDataType.GetStringData();
    }
}

public abstract class TextDataType : MonoBehaviour
{
    public abstract string GetStringData();
}
