using UnityEngine;

public class EnemyPositionsCreater : MonoBehaviour
{
    [SerializeField] internal Vector3[] EnemyPoses;
    [SerializeField] EnemyPositions poses;

#if UNITY_EDITOR
    [SerializeField] protected GameObject cubeObject;
    [SerializeField] protected bool isValidate = true;
    protected void OnValidate()
    {
        if (!isValidate) return;
        if (GetComponentsInChildren<Transform>().Length <= 1) return;
        Transform[] poss = GetComponentsInChildren<Transform>();
        EnemyPoses = new Vector3[poss.Length - 1];
        for (int i = 0; i < poss.Length - 1; i++)
        {
            EnemyPoses[i] = poss[i + 1].localPosition;
        }
    }
    [ContextMenu("CreateEmptyPos")]
    protected void CreateEmptyPos()
    {
        for (int i = 0; i < EnemyPoses.Length; i++)
        {
            GameObject thisGO = Instantiate(cubeObject, transform);
            thisGO.transform.localPosition = EnemyPoses[i];
        }
        Vector3 p = transform.localPosition;
        p.y = 1.5f;
        transform.localPosition = p;
    }
    [ContextMenu("DestroyEmptyPos")]
    protected void DestroyEmptyPos()
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

    [ContextMenu("transferPos")]
    void transferPos()
    {
        poses.EnemyPoses = EnemyPoses;
    }
#endif
}

[CreateAssetMenu(menuName = "ScriptableObject/Spawn/EnemyPosis")]
public class EnemyPositions : ScriptableObject
{
    [SerializeField] internal Vector3[] EnemyPoses;
}

