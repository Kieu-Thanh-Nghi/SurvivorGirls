using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AMissionUI : MonoBehaviour
{
    [SerializeField] MissionProgressClaimer missionProgressClaimer;
    [SerializeField] Product_InGameCurrency product_InGameCurrency;
    [SerializeField] TMP_Text energy_points, rewardNumber;
    [SerializeField] Image rewardIcon;

    private void Start()
    {
        energy_points.text = missionProgressClaimer.energyPoint.ToString();
        rewardNumber.text = product_InGameCurrency.ProductAmount.ToString("N0");
        var currencyIcon = UIDatas.Instance.CurrencyIcon[(int)product_InGameCurrency.currencyType];
        rewardIcon.sprite = currencyIcon;
    }
}