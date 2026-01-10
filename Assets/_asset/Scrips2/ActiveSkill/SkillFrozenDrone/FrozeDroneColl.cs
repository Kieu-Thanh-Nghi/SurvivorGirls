using Lean.Pool;
using UnityEngine;

public class FrozeDroneColl : MonoBehaviour
{
    [SerializeField] LeanGameObjectPool iceEffPool;
    private void OnTriggerEnter(Collider other)
    {
        var iceEff = other.GetComponentInChildren<IceEff>();
        if (iceEff != null)
        {
            iceEff.RefressEff();
        }
        else
        {
            iceEffPool.Spawn(other.transform);
        }
    }
}
