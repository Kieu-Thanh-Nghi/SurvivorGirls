using GooglePlayGames;

public class MissionProgress_Login1Time : MissionProgress
{
    public override int GetNeedProgressAmount() => 1;

    protected override void UpdateMission()
    {
        base.UpdateMission();
        if (PlayGamesPlatform.Instance.IsAuthenticated())
        {
            ProgressAmount = 1;
        }
        else
        {
            RefreshProgress();
        }
    }
}
