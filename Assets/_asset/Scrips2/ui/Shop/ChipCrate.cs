using System.Collections.Generic;
using UnityEngine;

public class ChipCrate : Crate<int> { }

public abstract class ClaimScreenOpener<T> : MonoBehaviour
{
    internal ClaimScreenUI claimScreenUI
        => UIManager.instance.menuShop.claimScreenUI;
    internal abstract RewardShower<T> rewardShower { get; }
    public void SetReward(T reward)
    {
        rewardShower.ShowOne(reward);
        claimScreenUI.OpenClaimScreen();
    }
    public void SetRewards(List<T> rewards)
    {
        rewardShower.ShowMany(rewards);
        claimScreenUI.OpenClaimScreen();
    }
}
