using UnityEngine;

public class BossRockThrowingSkill : BaseRockThrowingSkill
{
    private void OnEnable()
    {
        ActiveThrow();
    }

    protected override GameObject GetARock()
    {
        return EnemiesUpdate.Instance.rockPools.pool_BossRock.Spawn(null);
    }
}
