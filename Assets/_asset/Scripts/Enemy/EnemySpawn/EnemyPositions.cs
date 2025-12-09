using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Spawn/EnemyPosis")]
public class EnemyPositions : ScriptableObject
{
    [SerializeField] internal Vector3[] EnemyPoses;

#if UNITY_EDITOR
    [SerializeField] internal Vector3[] tempPoses;
    [SerializeField] protected bool isValidate = true;
    protected void OnValidate()
    {
        if (!isValidate) return;
        EnemyPoses = tempPoses;
    }
#endif
}

