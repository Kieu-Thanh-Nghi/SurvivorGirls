using TMPro;
using UnityEngine;

public class ItemBonusInfo : MonoBehaviour
{
    [SerializeField] TMP_Text bonusPoint;

    public void SetBonusPoint(int val)
    {
        bonusPoint.text = "+" + val.ToString();
    }
    public void SetBonusPoint(float val)
    {
        bonusPoint.text = "+" + val.ToString() + "%";
    }
}
