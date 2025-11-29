using UnityEngine;

public class GroupSpawnerStrategy : AbstractSpawnerStrategy
{
    [SerializeField] internal float endTime, spawnRate;
    [SerializeField] EnemyPositions enemyPositions;
    [SerializeField] EnemyAndPercentage[] enemyAndPercentage;
    [SerializeField] int sumOfPercentage;
    [SerializeField] float bonusLength = 5;
    float counting = 100;
    Vector3[] EnemyPoses { get => enemyPositions.EnemyPoses; }

    internal override bool Spawn(float time)
    {
        if(time > endTime)
        {
            counting = 100;
            return true;
        }
        if(counting >= spawnRate)
        {
            if (!GamePlayCtrler.Instance.CheckEnemyLimit())
            {
                counting = 0;
                RotateEnemySpawner();
                SpawnEnemy();
                GamePlayCtrler.Instance.enemyQuantity += EnemyPoses.Length;
            }
        }
        else
        {
            counting += Time.deltaTime;
        }
        return false;
    }

    internal virtual Vector3[] GetPosition()
    {
        Vector3[] newPoses = new Vector3[EnemyPoses.Length];
        int i = 0;
        foreach(var pos in EnemyPoses)
        {
            Vector3 pointAwayCenter = pos.normalized;
            pointAwayCenter *= Random.Range(0, bonusLength + 1);
            Vector3 newPos = pointAwayCenter + pos; newPos.y = pos.y;
            newPoses[i] = newPos;
            i++;
        }
        return newPoses;
    }

    internal virtual void SpawnEnemy()
    {
        SpawnChecker enemyPrefab;
        foreach(var pos in GetPosition())
        {
            enemyPrefab = RandomEnemy();
            Instantiate(enemyPrefab, transform.TransformPoint(pos), transform.rotation).StartCheck();
        }
    }

    protected SpawnChecker RandomEnemy()
    {
        int randomVal = Random.Range(1, sumOfPercentage);
        int sum = enemyAndPercentage[0].Percent;
        int n = enemyAndPercentage.Length;
        for (int i = 0; i < enemyAndPercentage.Length - 1; i++)
        {
            if(randomVal < sum)
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

