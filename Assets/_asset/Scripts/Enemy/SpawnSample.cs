using UnityEngine;
using UnityEditor;

public class SpawnSample : MonoBehaviour
{
    [SerializeField] Vector3[] EnemyPos;
    [SerializeField] SpawnChecker enemyPrefab;
    [SerializeField] float SpawnRadius = 10;
    [SerializeField] float bonusRudius = 5;
    [SerializeField] int enemiesEachSpawn = 6;
    
    //
    [SerializeField] GameObject cubeObject;
    [SerializeField] bool isValidate = true;
    private void OnValidate()
    {
        if (!isValidate) return;
        if (GetComponentsInChildren<Transform>().Length <= 1) return;
        Transform[] poss = GetComponentsInChildren<Transform>();
        EnemyPos = new Vector3[poss.Length - 1];
        for (int i = 0; i < poss.Length - 1; i++)
        {
            EnemyPos[i] = poss[i + 1].localPosition;
        }
    }
    [ContextMenu("CreateEmptyPos")]
    void CreateEmptyPos()
    {
        for (int i = 0; i < EnemyPos.Length; i++)
        {
            GameObject thisGO = Instantiate(cubeObject, transform);
            thisGO.transform.localPosition = EnemyPos[i];
        }
        Vector3 p = transform.localPosition;
        p.y = 1.5f;
        transform.localPosition = p;
    }
    [ContextMenu("DestroyEmptyPos")]
    void DestroyEmptyPos()
    {
        Transform[] poss = GetComponentsInChildren<Transform>();
        for (int i = 1; i < poss.Length; i++)
        {
            DestroyImmediate(poss[i].gameObject);
        }
        Vector3 p = transform.localPosition;
        p.y = -1;
        transform.localPosition = p;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 1);
        Handles.color = new Color(0, 0, 1, 0.1f);
        Handles.DrawSolidDisc(transform.position, transform.up, SpawnRadius);
    }
    //

    [ContextMenu("inst")]
    internal virtual int InstantiateEnemies()
    {
        SetUpSample();
        SpawnEnemies();
        return NumberOfSpawnedEnemy();
    }
    protected virtual void SetUpSample()
    {
        transform.localPosition = Vector3.zero;
        Vector3 SampleFinalPos = GetSpawnSamplePosition();
        transform.rotation = GetSampleRotation(SampleFinalPos);
        transform.position = SampleFinalPos;
    }
    protected virtual int NumberOfSpawnedEnemy() => enemiesEachSpawn;
    protected virtual void SpawnEnemies()
    {
        foreach (var pos in EnemyPos)
        {
            Instantiate(enemyPrefab, transform.TransformPoint(pos), transform.rotation).StartCheck();
        }
    }

    protected virtual Quaternion GetSampleRotation(Vector3 SampleFinalPos)
    {
        Vector3 SampleLookToPos = transform.position;
        Vector3 sampleForward =SampleLookToPos - SampleFinalPos;
        sampleForward.y = 0;
        return Quaternion.LookRotation(sampleForward);
    }

    protected virtual Vector3 GetSpawnSamplePosition()
    {
        float AngleRandom = Random.Range(-180, 181);
        float x = Mathf.Cos(AngleRandom);
        float z = Mathf.Sin(AngleRandom);
        float finalRadius = SpawnRadius + Random.Range(0, bonusRudius + 1);
        Vector3 finalPos = new Vector3(x * finalRadius, -1, z * finalRadius) + transform.position;

        return finalPos;
    }
}

public abstract class FixPosSpawnSample : MonoBehaviour
{
    [SerializeField] SpawnStrategy spawnStrategy;
    internal virtual int InstantiateEnemies()
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
public abstract class ChangePosSpawnSample : FixPosSpawnSample
{
    protected override void SetUpSample()
    {
        transform.localPosition = Vector3.zero;
        base.SetUpSample();
    }
}

public class SpawnStrategy : MonoBehaviour
{
    [SerializeField] Vector3[] EnemyPos;
    [SerializeField] SpawnChecker enemyPrefab;
    [SerializeField] int enemiesEachSpawn = 6;

    //
    [SerializeField] GameObject cubeObject;
    [SerializeField] bool isValidate = true;
    private void OnValidate()
    {
        if (!isValidate) return;
        if (GetComponentsInChildren<Transform>().Length <= 1) return;
        Transform[] poss = GetComponentsInChildren<Transform>();
        EnemyPos = new Vector3[poss.Length - 1];
        for (int i = 0; i < poss.Length - 1; i++)
        {
            EnemyPos[i] = poss[i + 1].localPosition;
        }
    }
    [ContextMenu("CreateEmptyPos")]
    void CreateEmptyPos()
    {
        for (int i = 0; i < EnemyPos.Length; i++)
        {
            GameObject thisGO = Instantiate(cubeObject, transform);
            thisGO.transform.localPosition = EnemyPos[i];
        }
        Vector3 p = transform.localPosition;
        p.y = 1.5f;
        transform.localPosition = p;
    }
    [ContextMenu("DestroyEmptyPos")]
    void DestroyEmptyPos()
    {
        Transform[] poss = GetComponentsInChildren<Transform>();
        for (int i = 1; i < poss.Length; i++)
        {
            DestroyImmediate(poss[i].gameObject);
        }
        Vector3 p = transform.localPosition;
        p.y = -1;
        transform.localPosition = p;
    }

    internal virtual int NumberOfSpawnedEnemy() => enemiesEachSpawn;

    internal virtual void SpawnEnemies()
    {
        foreach (var pos in EnemyPos)
        {
            Instantiate(enemyPrefab, transform.TransformPoint(pos), transform.rotation).StartCheck();
        }
    }
    //
}
