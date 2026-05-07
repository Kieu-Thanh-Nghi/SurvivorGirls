using UnityEngine;

public class RockData : MonoBehaviour
{
    [SerializeField] internal RockType rockType;
    [SerializeField] internal Vector3 projectileScale = Vector3.one * 2;
    [SerializeField] internal float projectileSpeed = 3;
    [SerializeField] internal int damage = 2;
}
