using System.Collections.Generic;

public class ClaimScreenOpener_chip : ClaimScreenOpener<int>
{
    internal override RewardShower<int> rewardShower => claimScreenUI.chipRewardShower;
}
