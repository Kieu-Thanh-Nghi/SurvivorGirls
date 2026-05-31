public class AchivementMeasurement_Progress : AchivementMeasurement
{
    protected virtual int GetProgressAmount()
    {
        return 1;
    }
    public override void AchivementUpdate()
    {
        GooglePlayAchievement.Instance.IncrementAchievement(achievementId, GetProgressAmount());
    }
}
