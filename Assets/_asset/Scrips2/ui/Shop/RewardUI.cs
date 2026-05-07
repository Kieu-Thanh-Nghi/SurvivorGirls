using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RewardUI : MonoBehaviour
{
    [SerializeField] internal Image rewardIcon;
    [SerializeField] internal TMP_Text rewardNumber;

    public void OpenUI(Sprite icon, int number)
    {
        rewardIcon.sprite = icon;
        rewardNumber.text = number.ToString();
        gameObject.SetActive(true);
    }
}
