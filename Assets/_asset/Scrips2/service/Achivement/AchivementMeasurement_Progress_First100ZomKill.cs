public class AchivementMeasurement_Progress_First100ZomKill : AchivementMeasurement_Progress
{
    internal int killCount => GamePlayCtrler.Instance.killedZomCount.counted;

    protected override int GetProgressAmount() => killCount;
}