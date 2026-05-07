using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EquipmentContex : MonoBehaviour
{
    [SerializeField] Image rankIcon;
    [SerializeField] internal TMP_Text EquipName;

    public void SetEquipmentRank(ItemRank rank)
    {
        rankIcon.sprite = UIDatas.Instance.rankIcon[(int)rank];
    }
}
