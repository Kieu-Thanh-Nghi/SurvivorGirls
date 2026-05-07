using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AMissionProgressUI : MonoBehaviour
{
    [SerializeField] protected Image fillMask;
    [SerializeField] protected TMP_Text progressNumber;

    public void UpdateUI(int havingAmount, int neededAmount)
    {
        if (havingAmount > neededAmount) havingAmount = neededAmount;
        fillMask.fillAmount = (float)havingAmount / neededAmount;
        progressNumber.text = havingAmount + " / " + neededAmount;
    }
}
