using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/EnemyData")]
public class EnemyData : ScriptableObject
{
    [SerializeField] internal float moveSpeed, speedBehind = 0.2f;
    [SerializeField] internal float maxObsDetectDistance;
    [SerializeField] internal LayerMask layerMask;
    public Vector3 SetFaceDirect(Vector3 enemyPosition, Vector3 playerPosition)
    {
        return (playerPosition - enemyPosition).normalized;
    }
}