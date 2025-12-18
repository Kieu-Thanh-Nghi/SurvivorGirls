using UnityEngine;
using Lean.Pool;
public class GroupSpawnerStrategy : ASpawnStrategy
{
    [SerializeField] EnemyPositions enemyPositions;
    [SerializeField] EnemyAndPercentage[] enemyAndPercentage;
    [SerializeField] int sumOfPercentage;
    [SerializeField] float bonusLength = 5;
    [SerializeField] int numberOfPosis;
    Vector3[] EnemyPoses { get => enemyPositions.EnemyPoses; }

    internal virtual Vector3[] GetPosition(Transform spawner)
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
        spawner.TransformPoints(newPoses);
        return newPoses;
    }

    internal override void SpawnEnemy(Transform spawner)
    {
        LeanGameObjectPool enemyPrefab;
        foreach (var pos in GetPosition(spawner))
        {
            enemyPrefab = RandomEnemy();
            enemyPrefab.Spawn(pos);
        }
        //GamePlayCtrler.Instance.enemyQuantity += numberOfPosis;
    }

    protected LeanGameObjectPool RandomEnemy()
    {
        int randomVal = Random.Range(1, sumOfPercentage);
        int sum = enemyAndPercentage[0].Percent;
        int n = enemyAndPercentage.Length;
        for (int i = 0; i < enemyAndPercentage.Length - 1; i++)
        {
            if (randomVal < sum)
            {
                return enemyAndPercentage[i].poolForAPrefab;
            }
            else
            {
                sum += enemyAndPercentage[i].Percent;
            }
        }

        return enemyAndPercentage[n - 1].poolForAPrefab;
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

