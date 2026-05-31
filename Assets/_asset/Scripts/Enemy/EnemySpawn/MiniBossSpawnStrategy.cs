using UnityEngine;

public class MiniBossSpawnStrategy : SpawnStrategy
{
    [SerializeField] HealthBar hpBarForMiniboss;
    [SerializeField] float buffSize;
    [SerializeField] float buffPower;
    [SerializeField] float buffSpeed;
    [SerializeField] float buffHealth;

    [ContextMenu("test spawn")]
    public void TestSpawn() => SpawnEnemy(transform);
    internal override void SpawnEnemy(Transform spawner)
    {
        base.SpawnEnemy(spawner);
        var bossHP = realEnemy.GetComponent<Health>();
        AddHealthBar(bossHP);
        ModifyZombie(realEnemy.EnemyBody);
    }

    void ModifyZombie(Enemy theEnemy)
    {
        theEnemy.powerBuff = buffPower;
        theEnemy.speedBuff = buffSpeed;
        theEnemy.healthBuff = buffHealth;
        realEnemy.ChangeSize(buffSize);
    }

    void AddHealthBar(Health bossHP)
    {
        var bossHpBar = Instantiate(hpBarForMiniboss, realEnemy.transform, false);
        bossHpBar.SetHealth(bossHP);
    }
}

