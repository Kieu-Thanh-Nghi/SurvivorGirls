using UnityEngine;
using Lean.Pool;

public class EMineColl : MonoBehaviour
{
    [SerializeField] internal LeanGameObjectPool electricPool;
    private void OnTriggerEnter(Collider other)
    {
        var electricEff = other.GetComponentInChildren<MinesElectricEff>();
        if (electricEff == null)
        {
            if (electricPool.Spawn(other.transform).TryGetComponent(out electricEff))
            {
                electricEff.transform.forward = Vector3.up;
                electricEff.SetInfinite(true);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        var electricEff = other.GetComponentInChildren<ElectricEff>();
        if(electricEff != null)
        {
            electricEff.StopEff(true);
        }
    }
}
