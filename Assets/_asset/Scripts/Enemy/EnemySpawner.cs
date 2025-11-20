using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float SpawnRadius = 10;
    [SerializeField] float timeBetweenSpawn = 0.5f;
    float countingTime = 0;
    Vector3 GetSpawnPosition()
    {
        float AngleRandom = Random.Range(-180, 181);
        float x = Mathf.Cos(AngleRandom);
        float z = Mathf.Sin(AngleRandom);
        return new Vector3(x * SpawnRadius,1 ,z * SpawnRadius);
    }

    private void Update()
    {
        countingTime += Time.deltaTime;
        if(countingTime > timeBetweenSpawn)
        {
            spawnAnEnemy();
            countingTime = 0;
        }
    }

    void spawnAnEnemy()
    {
        Vector3 EnemyPos = GetSpawnPosition();
        Instantiate(enemyPrefab).transform.position = EnemyPos;
    }
}
