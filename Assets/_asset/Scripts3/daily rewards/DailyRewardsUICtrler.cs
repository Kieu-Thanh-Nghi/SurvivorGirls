using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AASave;

public class DailyRewardsUICtrler : MonoBehaviour
{
    [SerializeField] Button ClaimButton;
    [SerializeField] List<ADayRewardUI> rewardUIs;
    int todayIndex;

    DailyRewardsBackEnd dailyRewardsBackEnd
        => DatabaseManager.Instance.dailyRewardsBackEnd;

    //can biet cac ngay da nhan de bat tat Reward UI
    //can biet hom nay da nhan chua? de bat tat UI hom nay

    private void Start()
    {
        todayIndex = dailyRewardsBackEnd.ClaimedDays;
        int claimedDaysIndex = todayIndex - 1;
        //bat tat Rewards UI
        for (int i = claimedDaysIndex; i > -1 && i < rewardUIs.Count; i++)
        {
            rewardUIs[i].SetUIStatus(2);
        }
    }

    private void OnEnable()
    {
        //bat tat UI hom nay
        if (!dailyRewardsBackEnd.ClaimedToday)
        {
            rewardUIs[todayIndex].SetUIStatus(1);
            ClaimButton.gameObject.SetActive(true);
        }
        else
        {
            rewardUIs[todayIndex].SetUIStatus(2);
            ClaimButton.gameObject.SetActive(false);
        }
    }

    public void ClaimTodayReward()
    {
        if (dailyRewardsBackEnd.ClaimedToday) return;
        dailyRewardsBackEnd.ClaimedToday = true;
        dailyRewardsBackEnd.ClaimAReward(todayIndex);
        ClaimButton.gameObject.SetActive(false);
        rewardUIs[todayIndex].SetUIStatus(2);
    }
}
