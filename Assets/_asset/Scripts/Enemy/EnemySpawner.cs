using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] int enemyQuantity;
    [SerializeField] int enemyQuantityLimiter = 300;
    [SerializeField] SimpleSpawnSample enemySample;
    [SerializeField] float timeBetweenSpawn = 0.5f;
    float countingTime = 0;

    private void Update()
    {
        if (enemyQuantity >= enemyQuantityLimiter) return;
        countingTime += Time.deltaTime;
        if(countingTime > timeBetweenSpawn)
        {
            RotateEnemySpawner();
            ActiveEnemySample();
            countingTime = 0;
        }
    }

    void ActiveEnemySample()
    {
        enemyQuantity += enemySample.InstantiateEnemies();
    }
    void RotateEnemySpawner()
    {
        float AngleRandom = Random.Range(-180, 181);
        enemySample.transform.rotation = Quaternion.Euler(0, AngleRandom, 0);
    }
}
