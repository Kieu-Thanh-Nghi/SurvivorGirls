using UnityEngine;
using Lean.Pool;

public class StatusPool : MonoBehaviour
{
    [SerializeField] LeanGameObjectPool thePool;

    public GameObject SpawnStatusEff(Transform effContainer)
    {
        return thePool.Spawn(effContainer);
    }
}
