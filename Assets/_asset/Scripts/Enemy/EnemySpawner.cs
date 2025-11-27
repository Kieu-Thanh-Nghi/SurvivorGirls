using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] SpawnerData[] spawnDatas;
    [SerializeField] int enemyQuantity;
    [SerializeField] int enemyQuantityLimiter = 300;
    [SerializeField] float timeBetweenSpawn = 0.5f;
    float countingTime = 0;
    int thefirstIndex = 0, theLastIndex = 0;

    void checkSampleActive()
    {
        if(spawnDatas[theLastIndex].StartTime <= countingTime)
        {
            theLastIndex += 1;
            checkSampleActive();
        }
        else
        {
            countingTime += Time.deltaTime;
        }
    }

    void UpdateActivatedSample()
    {
        if(thefirstIndex < theLastIndex)
        for(int i = thefirstIndex; i < theLastIndex; i++)
        {
            if (spawnDatas[i].Spawn())
            {
                Swap(spawnDatas[thefirstIndex], spawnDatas[i]);
                thefirstIndex++;
            }
        }
    }

    void Swap(SpawnerData a, SpawnerData b)
    {
        SpawnerData temp = a;
        a = b;
        b = temp;
    }
    //
    [ContextMenu("setup")]
    void SetUp()
    {
        spawnDatas = GetComponentsInChildren<SpawnerData>();
    }
    //

    private void Update()
    {
        if (enemyQuantity >= enemyQuantityLimiter) return;
        checkSampleActive();
        UpdateActivatedSample();
    }


    void ActiveEnemySample()
    {
        //enemyQuantity += enemySample.InstantiateEnemies();
    }
    void RotateEnemySpawner()
    {
        float AngleRandom = Random.Range(-180, 181);
        //enemySample.transform.rotation = Quaternion.Euler(0, AngleRandom, 0);
    }
}
