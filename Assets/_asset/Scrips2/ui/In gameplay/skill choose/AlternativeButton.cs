using UnityEngine;
using TMPro;

public class AlternativeButton : MonoBehaviour
{
    [SerializeField] int minRewardAmount, maxRewardAmount;
    [SerializeField] Product_InGameCurrency product;
    [SerializeField] string frontText, backText;
    [SerializeField] TMP_Text detail;
    public void SetupThis()
    {
        int rewardAmount = Random.Range(minRewardAmount, maxRewardAmount);
        product.ProductAmount = rewardAmount;
        detail.text = frontText + rewardAmount + backText;
    }
}
