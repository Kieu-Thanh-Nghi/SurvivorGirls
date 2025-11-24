using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] int enemyQuantity;
    [SerializeField] int enemyQuantityLimiter = 300;
    [SerializeField] SpawnSample enemySample;
    [SerializeField] float timeBetweenSpawn = 0.5f;
    float countingTime = 0;

    private void Update()
    {
        if (enemyQuantity >= enemyQuantityLimiter) return;
        countingTime += Time.deltaTime;
        if(countingTime > timeBetweenSpawn)
        {
            ActiveEnemySample();
            countingTime = 0;
        }
    }

    void ActiveEnemySample()
    {
        enemyQuantity += enemySample.InstantiateEnemies();
    }
}
