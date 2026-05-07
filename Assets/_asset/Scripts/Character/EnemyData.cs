using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/EnemyData")]
public class EnemyData : ScriptableObject
{
    [SerializeField] internal float moveSpeed;
    [SerializeField] internal int health = 50;
    [SerializeField] internal int damage;
}