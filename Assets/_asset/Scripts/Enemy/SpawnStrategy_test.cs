using UnityEngine;

public class SpawnStrategy_test : MonoBehaviour
{
    [SerializeField] Vector3[] EnemyPos;
    [SerializeField] SpawnChecker enemyPrefab;
    [SerializeField] internal int enemiesEachSpawn = 6;

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
    //

    internal virtual int NumberOfSpawnedEnemy() => enemiesEachSpawn;

    internal virtual void SpawnEnemies()
    {
        foreach (var pos in EnemyPos)
        {
            Instantiate(enemyPrefab, transform.TransformPoint(pos), transform.rotation).StartCheck();
        }
    }
}
