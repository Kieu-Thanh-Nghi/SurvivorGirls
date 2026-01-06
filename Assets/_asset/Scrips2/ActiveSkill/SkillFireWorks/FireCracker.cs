using Lean.Pool;
using UnityEngine;

public class FireCracker : MonoBehaviour, IPoolable
{
    [SerializeField] internal LeanGameObjectPool ExplotionPool;
    public void OnDespawn()
    {
        ExplotionPool.Spawn(transform.position, transform.rotation).transform.localScale
            = transform.localScale;
    }

    public void OnSpawn()
    {
        
    }
}
