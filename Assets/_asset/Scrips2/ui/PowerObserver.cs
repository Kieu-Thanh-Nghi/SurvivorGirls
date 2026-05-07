using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PowerObserver : MonoBehaviour
{
    [SerializeField] RectTransform rectTransform;
    [SerializeField] TextDataType textDataType;
    [SerializeField] TMP_Text power;
    string atkNumber = "";

    private void Start()
    {
        UpdateText();
    }
    private void Update()
    {
        UpdateText();
    }
    void UpdateText()
    {
        var currentAtk = textDataType.GetStringData();
        if (atkNumber.CompareTo(currentAtk) != 0)
        {
            power.text = currentAtk;
            LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
            //gameObject.SetActive(false);
            //gameObject.SetActive(true);
        }
    }
}