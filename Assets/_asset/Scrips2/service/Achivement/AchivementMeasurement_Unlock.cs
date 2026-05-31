public class AchivementMeasurement_Unlock : AchivementMeasurement
{
    public override void AchivementUpdate()
    {
        GooglePlayAchievement.Instance.UnlockAchievement(achievementId);
    }
}
