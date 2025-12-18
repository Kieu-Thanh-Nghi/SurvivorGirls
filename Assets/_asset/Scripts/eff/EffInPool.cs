using Lean.Pool;
using UnityEngine;

public class EffInPool : MonoBehaviour
{
    [SerializeField] LeanGameObjectPool myPool;
    private void OnParticleSystemStopped()
    {
        myPool.Despawn(gameObject);
    }
}
