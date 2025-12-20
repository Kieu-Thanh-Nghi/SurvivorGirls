using Lean.Pool;
using UnityEngine;

public class EXPpools : MonoBehaviour
{
    [SerializeField] LeanGameObjectPool[] pools;

    public void SpawnEXP(int type, Vector3 position)
    {
        pools[type].Spawn(position);
    }
}
