using UnityEngine;

public class BossSpawnStrategy : SpawnStrategy
{
    void EnableBossArea(Transform bossArea, Vector3 playerPos)
    {
        bossArea.position = playerPos;
        bossArea.gameObject.SetActive(true);
    }

    void StopClock(bool isStop)
    {
        GamePlayCtrler.Instance.isStopCounting = isStop;
    }

    void SetDoWhenBossDie(SpawnChecker enemy, Transform bossArea)
    {
        var onDead = enemy.GetComponentInChildren<ISetOnDead>();
        onDead?.SetDoWhenDie(() => BossDieFunc(bossArea));
    }

    void BossDieFunc(Transform bossArea)
    {
        StopClock(false);
        bossArea.gameObject.SetActive(false);
    }

    internal override void SpawnEnemy(Transform spawner)
    {
        var ctrler = GamePlayCtrler.Instance;
        var bossArea = ctrler.BossArea;
        EnableBossArea(bossArea, ctrler.Player.position);
        StopClock(true);
        base.SpawnEnemy(spawner);
        SetDoWhenBossDie(realEnemy, bossArea);
    }
}

