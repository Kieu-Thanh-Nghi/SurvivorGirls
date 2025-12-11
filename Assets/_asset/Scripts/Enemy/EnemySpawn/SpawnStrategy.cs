using UnityEngine;
using Lean.Pool;

public class SpawnStrategy : ASpawnStrategy
{
    //[SerializeField] float SpawnSampleRadius = 10;
    [SerializeField] float bonusRudius = 5;
    [SerializeField] SpawnChecker enemyPrefab;

    internal virtual Vector3 GetPosition(Transform spawner)
    {
        float x = spawner.forward.x;
        float z = spawner.forward.z;
        float finalRadius = 1 + UnityEngine.Random.Range(0, bonusRudius + 1);
        Vector3 finalPos = new Vector3(x * finalRadius + spawner.position.x, -1, z * finalRadius + spawner.position.z);

        return finalPos;
    }

    internal override void SpawnEnemy(Transform spawner)
    {
        Vector3 pos = GetPosition(spawner);
        Object.Instantiate(enemyPrefab, pos, spawner.rotation).StartCheck();
    }
}

public abstract class ASpawnStrategy : MonoBehaviour
{
    internal abstract void SpawnEnemy(Transform spawner);
}

[System.Serializable]
public class EnemyAndPercentage
{
    [SerializeField] internal LeanGameObjectPool poolForAPrefab;
    [SerializeField] internal int Percent;
}
