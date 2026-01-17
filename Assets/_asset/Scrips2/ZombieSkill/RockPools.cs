using UnityEngine;
using Lean.Pool;

public class RockPools : MonoBehaviour
{
    [SerializeField] internal LeanGameObjectPool 
        pool_NormalRock,
        pool_BossRock;
}
