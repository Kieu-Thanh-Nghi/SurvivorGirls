using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] int enemyQuantity;
    [SerializeField] int enemyQuantityLimiter = 300;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float SpawnRadius = 10;
    [SerializeField] float bonusRudius = 5;
    [SerializeField] float timeBetweenSpawn = 0.5f;
    float countingTime = 0;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 1);
        Handles.color = new Color(0, 0, 1, 0.1f);
        Handles.DrawSolidDisc(transform.position, transform.up, SpawnRadius);
    }

    Vector3 GetSpawnPosition()
    {
        Vector3 SpawnerPos = transform.position;
        float AngleRandom = Random.Range(-180, 181);
        float x = Mathf.Cos(AngleRandom);
        float z = Mathf.Sin(AngleRandom);
        float finalRadius = SpawnRadius + Random.Range(0, bonusRudius + 1);
        Vector3 finalPos = new Vector3(x * finalRadius, SpawnerPos.y+1, z * finalRadius) + SpawnerPos;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(finalPos, out hit, 10f, NavMesh.AllAreas))
        {
            finalPos = hit.position;
        }
        return finalPos;
    }

    private void Update()
    {
        if (enemyQuantity >= enemyQuantityLimiter) return;
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
        Vector3 enemyForward = EnemyPos - transform.position;
        enemyForward.y = 0;
        Quaternion enemyQuaternion = Quaternion.LookRotation(enemyForward);
        Instantiate(enemyPrefab, EnemyPos, enemyQuaternion);
        enemyQuantity += 6;
    }
}
