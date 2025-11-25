using UnityEngine;

public class SpawnSetUp : MonoBehaviour
{
    [SerializeField] internal float startTime, endTime, spawnRate;
    [SerializeField] int enemyQuantity;
    [SerializeField] SpawnTypeAndPercent[] spawnTypeAndPercent;
    [SerializeField] SimpleSpawnSample spawnSamples;

    internal virtual void InstantiateEnemies()
    {

    }
}

[System.Serializable]
public class SpawnTypeAndPercent
{
    [SerializeField] internal GameObject enemyPrefab;
    [SerializeField] int percent;
}
