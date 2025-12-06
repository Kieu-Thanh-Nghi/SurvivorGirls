using UnityEngine;

[CreateAssetMenu(fileName = "SpawnOne", menuName = "ScriptableObject/Spawn/SpawnStra")]
public class SpawnStrategy : ASpawnStrategy
{
    [SerializeField] float SpawnSampleRadius = 10;
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

[CreateAssetMenu(fileName = "SpawnGroup", menuName = "ScriptableObject/Spawn/GroupSpawnStra")]
public class GroupSpawnerStrategy : ASpawnStrategy
{
    [SerializeField] EnemyPositions enemyPositions;
    [SerializeField] EnemyAndPercentage[] enemyAndPercentage;
    [SerializeField] int sumOfPercentage;
    [SerializeField] float bonusLength = 5;
    [SerializeField] int numberOfPosis;
    Vector3[] EnemyPoses { get => enemyPositions.EnemyPoses; }

    internal virtual Vector3[] GetPosition()
    {
        Vector3[] newPoses = new Vector3[numberOfPosis];
        int i = 0;
        foreach (var pos in EnemyPoses)
        {
            Vector3 pointAwayCenter = pos.normalized;
            pointAwayCenter *= Random.Range(0, bonusLength + 1);
            Vector3 newPos = pointAwayCenter + pos; newPos.y = pos.y;
            newPoses[i] = newPos;
            i++;
        }
        return newPoses;
    }

    internal override void SpawnEnemy(Transform spawner)
    {
        SpawnChecker enemyPrefab;
        foreach (var pos in GetPosition())
        {
            enemyPrefab = RandomEnemy();
            Instantiate(enemyPrefab, spawner.TransformPoint(pos), spawner.rotation).StartCheck();
        }
        GamePlayCtrler.Instance.enemyQuantity += numberOfPosis;
    }

    protected SpawnChecker RandomEnemy()
    {
        int randomVal = Random.Range(1, sumOfPercentage);
        int sum = enemyAndPercentage[0].Percent;
        int n = enemyAndPercentage.Length;
        for (int i = 0; i < enemyAndPercentage.Length - 1; i++)
        {
            if (randomVal < sum)
            {
                return enemyAndPercentage[i].enemyPrefab;
            }
            else
            {
                sum += enemyAndPercentage[i].Percent;
            }
        }

        return enemyAndPercentage[n - 1].enemyPrefab;
    }

#if UNITY_EDITOR
    protected void OnValidate()
    {
        numberOfPosis = EnemyPoses.Length;
        SumOfPercent();
    }

    [ContextMenu("sumOfPercent")]
    protected void SumOfPercent()
    {
        sumOfPercentage = 0;
        foreach (var e in enemyAndPercentage)
        {
            sumOfPercentage += e.Percent;
        }
    }
#endif
}

public abstract class ASpawnStrategy : ScriptableObject
{
    internal abstract void SpawnEnemy(Transform spawner);
}

[System.Serializable]
public class EnemyAndPercentage
{
    [SerializeField] internal SpawnChecker enemyPrefab;
    [SerializeField] internal int Percent;
}

