using UnityEngine;

public class SpawnStarter : MonoBehaviour
{
    [SerializeField] internal float StartTime;
    [SerializeField] internal ASpawnStrategy spawnStrategy;

    internal virtual bool Spawn(float time)
    {
        RotateEnemySpawner();
        spawnStrategy.SpawnEnemy(transform);
        return true;
    }
    protected void RotateEnemySpawner()
    {
        float AngleRandom = Random.Range(-180, 181);
        transform.rotation = Quaternion.Euler(0, AngleRandom, 0);
    }
}

