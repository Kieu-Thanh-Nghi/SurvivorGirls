using UnityEngine;
using System.Collections.Generic;

public class SpawnSample : MonoBehaviour
{
    [SerializeField] Transform[] EnemyPos;
    [SerializeField] SpawnChecker enemyPrefab;

    [SerializeField] bool isValidate = true;
    private void OnValidate()
    {
        if (!isValidate) return;
        Transform[] poss = GetComponentsInChildren<Transform>();
        EnemyPos = new Transform[poss.Length - 1];
        for (int i = 0; i < poss.Length - 1; i++)
        {
            EnemyPos[i] = poss[i + 1];
        }
    }

    [ContextMenu("inst")]
    internal virtual void InstantiateEnemies()
    {
        foreach(var pos in EnemyPos)
        {
            //Instantiate(enemyPrefab, pos.position, transform.rotation);
            Instantiate(enemyPrefab, pos.position, transform.rotation).StartCheck();
        }
    }
}
