using Lean.Pool;
using UnityEngine;

public class FireCrackerExplotion : MonoBehaviour
{
    [SerializeField] internal LeanGameObjectPool BurnEffPool;

    private void OnTriggerEnter(Collider other)
    {
        BurnEffPool.Spawn(other.transform);
    }

    private void OnEnable()
    {
        Invoke(nameof(TurnOffExplode), 0.4f);
    }

    void TurnOffExplode()
    {
        LeanPool.Despawn(gameObject);
    }
}
