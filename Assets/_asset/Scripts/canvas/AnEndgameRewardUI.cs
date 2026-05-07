using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnEndgameRewardUI : MonoBehaviour
{
    [SerializeField] GameObject clearMark;
    [SerializeField] Image icon;
    [SerializeField] TMP_Text amount;

    public void SetThisUp(bool isClear, Sprite rewardIcon, int rewardAmount)
    {
        clearMark.SetActive(isClear);
        icon.sprite = rewardIcon;
        amount.text = rewardAmount.ToString("N0");
    }
}