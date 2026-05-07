using UnityEngine;
using TigerForge;

public class MissionUpdater : MonoBehaviour
{
    internal int killCount => GamePlayCtrler.Instance.killedZomCount.counted;
    private void Start()
    {
        EventManager.StartListening(GameEvents.BossKilled.ToString(), BossKilledDataUpdate);
    }

    void BossKilledDataUpdate()
    {
        int currentDailyBossKilled = PlayerPrefs.GetInt("daily_BossKilled");
        PlayerPrefs.SetInt("daily_BossKilled", currentDailyBossKilled + 1);
    }

    public void KillCountDataUpdate()
    {
        int currentDailyZomKilled = PlayerPrefs.GetInt("daily_ZombiesKilled");
        PlayerPrefs.SetInt("daily_ZombiesKilled", currentDailyZomKilled + killCount);
    }
}