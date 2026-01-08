using Lean.Pool;
using UnityEngine;

public class ThunderStrike : MonoBehaviour
{
    [SerializeField] LeanGameObjectPool ElecStatusPool;
    private void OnEnable()
    {
        LeanPool.Despawn(gameObject, 1);
    }
    private void OnTriggerEnter(Collider other)
    {
        var electricEff = other.GetComponentInChildren<ThunderBoltsElectricEff>();
        if (electricEff != null)
        {
            electricEff.RefressEff();
        }
        else
        {
            ElecStatusPool.Spawn(other.transform);
        }
    }
}
