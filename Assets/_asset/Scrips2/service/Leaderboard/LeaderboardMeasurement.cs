using UnityEngine;
using TigerForge;

public class LeaderboardMeasurement : MonoBehaviour
{
    internal int killCount => GamePlayCtrler.Instance.killedZomCount.counted;

    public void LeaderboardUpdate()
    {
        GooglePlayLeaderboard.Instance.SubmitScore(killCount);
    }
}
