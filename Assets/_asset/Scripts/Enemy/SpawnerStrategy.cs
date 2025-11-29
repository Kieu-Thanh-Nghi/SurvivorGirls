using UnityEngine;

public class SpawnerStrategy : AbstractSpawnerStrategy
{
    [SerializeField] SpawnChecker enemyPrefab;
    [SerializeField] float SpawnSampleRadius = 10;
    [SerializeField] float bonusRudius = 5;

    internal override bool Spawn(float time)
    {
        RotateEnemySpawner();
        SpawnEnemy();
        return true;
    }

    internal virtual Vector3 GetPosition()
    {
        float x = transform.forward.x;
        float z = transform.forward.z;
        float finalRadius = 1 + UnityEngine.Random.Range(0, bonusRudius + 1);
        Vector3 finalPos = new Vector3(x * finalRadius + transform.position.x, -1, z * finalRadius + transform.position.z);

        return finalPos;
    }

    internal virtual void SpawnEnemy()
    {
        Vector3 pos = GetPosition();
        Instantiate(enemyPrefab, pos, transform.rotation).StartCheck();
    }
}

public abstract class AbstractSpawnerStrategy : MonoBehaviour
{
    [SerializeField] internal float StartTime;

    internal abstract bool Spawn(float time);
    protected void RotateEnemySpawner()
    {
        float AngleRandom = Random.Range(-180, 181);
        transform.rotation = Quaternion.Euler(0, AngleRandom, 0);
    }
}

[System.Serializable]
public class EnemyAndPercentage
{
    [SerializeField] internal SpawnChecker enemyPrefab;
    [SerializeField] internal int Percent;
}

