using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/EnemyData")]
public class EnemyData : ScriptableObject
{
    [SerializeField] internal float moveSpeed;
    [SerializeField] internal LayerMask layerMask;
    [SerializeField] internal int health = 50;
    public Vector3 SetFaceDirect(Vector3 enemyPosition, Vector3 playerPosition)
    {
        return (playerPosition - enemyPosition).normalized;
    }
}