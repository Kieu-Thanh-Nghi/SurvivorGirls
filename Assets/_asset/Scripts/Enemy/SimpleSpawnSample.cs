using UnityEngine;

public class SimpleSpawnSample : MonoBehaviour
{
    [SerializeField] protected SpawnStrategy spawnStrategy;

    internal virtual int InstantiateEnemies()
    {
        spawnStrategy.SpawnEnemies();
        return spawnStrategy.NumberOfSpawnedEnemy();
    }
}
public abstract class ChangePosSpawnSample : SimpleSpawnSample
{
    internal override int InstantiateEnemies()
    {
        SetUpSample();
        spawnStrategy.SpawnEnemies();
        return spawnStrategy.NumberOfSpawnedEnemy();
    }
    protected virtual void SetUpSample()
    {
        Vector3 SampleFinalPos = GetSpawnSamplePosition();
        transform.rotation = GetSampleRotation(SampleFinalPos);
        transform.position = SampleFinalPos;
    }
    protected abstract Quaternion GetSampleRotation(Vector3 SampleFinalPos);

    protected abstract Vector3 GetSpawnSamplePosition();
}

