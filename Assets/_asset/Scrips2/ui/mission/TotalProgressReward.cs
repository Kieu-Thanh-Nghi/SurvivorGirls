using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TotalProgressReward : MonoBehaviour
{
    [SerializeField] internal int neededEnergyPoint;
    [SerializeField] internal string rewardClaimed_SaveKey;
    [SerializeField] TotalMissionProgress totalMissionProgress;
    [SerializeField] Button claimButton;
    [SerializeField] GameObject RewardChecked, GlowMark;
    [SerializeField] UnityEvent DoGetReward;

    public void CheckIfGetReward()
    {
        var currentEnergyPoint = totalMissionProgress.GetCurrentEP();
        if (neededEnergyPoint > currentEnergyPoint) return;
        DoGetReward?.Invoke();
        totalMissionProgress.saveSystem.Save(rewardClaimed_SaveKey, true);
        TurnOnClaimedMark();
    }
    public bool IsClaimed() => totalMissionProgress.saveSystem.Load(rewardClaimed_SaveKey, false);
    public void AvalableButton()
    {
        GlowMark.SetActive(true);
        claimButton.enabled = true;
        //bat nut, bat glow
    }
    public void TurnOnClaimedMark()
    {
        GlowMark.SetActive(false);
        claimButton.enabled = false;
        RewardChecked.SetActive(true);
        //tat nut, tat glow, bat da nhan
    }
    public void RefreshThis()
    {
        //tat nut, tat glow, tat da nhan
        GlowMark.SetActive(false);
        claimButton.enabled = false;
        RewardChecked.SetActive(false);
    }
}
