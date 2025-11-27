using UnityEngine;

public class SpawnerData : MonoBehaviour
{
    [SerializeField] internal float StartTime;
    [SerializeField] internal SimpleSpawnSample sample;

    internal virtual bool Spawn()
    {
        return true;
    }
}

