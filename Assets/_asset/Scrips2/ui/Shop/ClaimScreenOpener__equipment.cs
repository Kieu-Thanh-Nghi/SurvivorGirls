public class ClaimScreenOpener__equipment : ClaimScreenOpener<Equipment>
{
    internal override RewardShower<Equipment> rewardShower 
        => claimScreenUI.equipmentRewardShower;
}
