using UnityEngine;
using Lean.Pool;

public class SpawnStrategy : ASpawnStrategy
{
    //[SerializeField] float SpawnSampleRadius = 10;
    [SerializeField] protected float bonusRudius = 5;
    [SerializeField] protected float spawnRadius = 5;
    [SerializeField] protected SpawnChecker enemyPrefab;
    protected SpawnChecker realEnemy;

    internal virtual Vector3 GetPosition(Transform spawner)
    {

        float x = spawner.forward.x;
        float z = spawner.forward.z;
        float finalRadius = spawnRadius + UnityEngine.Random.Range(0, bonusRudius + 1);
        Vector3 finalPos = new Vector3(x * finalRadius + spawner.position.x, -1, z * finalRadius + spawner.position.z);

        return finalPos;
    }

    internal override void SpawnEnemy(Transform spawner)
    {
        Vector3 pos = GetPosition(spawner);
        realEnemy = Instantiate(enemyPrefab, pos, spawner.rotation);
        realEnemy.StartCheck();
    }
}

public abstract class ASpawnStrategy : MonoBehaviour
{
    internal abstract void SpawnEnemy(Transform spawner);
}

