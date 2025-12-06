using UnityEngine;

public class SpawnStarterAndEnd : SpawnStarter
{
    [SerializeField] internal float endTime, spawnRate;
    float counting = 100;

    internal override bool Spawn(float time)
    {
        if (time > endTime)
        {
            counting = 100;
            return true;
        }
        if (counting >= spawnRate)
        {
            if (!GamePlayCtrler.Instance.CheckEnemyLimit())
            {
                counting = 0;
                RotateEnemySpawner();
                spawnStrategy.SpawnEnemy(transform);
            }
        }
        else
        {
            counting += Time.deltaTime;
        }
        return false;
    }
}


