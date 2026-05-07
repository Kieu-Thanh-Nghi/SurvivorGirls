using UnityEngine;
using Lean.Pool;

public class RockPools : MonoBehaviour
{
    [SerializeField] internal LeanGameObjectPool[] rockPools;

    public LeanGameObjectPool GetRockPool(RockType rockType)
    {
        if ((int)rockType >= rockPools.Length) return null;
        return rockPools[(int)rockType];
    }
}
public enum RockType
{
    NormalRock = 0,
    BossRock = 1,
    IceRock = 2,
    FireRock = 3,
    IceBossRock = 4,
    FireBossRock = 5
}