using UnityEngine;
using Lean.Pool;

public class ExplotionEff : MonoBehaviour
{
    [SerializeField] internal LeanGameObjectPool thePool;
    [SerializeField] internal ExplodeSphere explodeSphere;
    [SerializeField] internal int Damage = 5;
    [SerializeField] internal float Radius = 0.4f;
    [SerializeField] internal Vector3 Scale {
        get => explodeSphere.transform.localScale;
        set => explodeSphere.transform.localScale = value; 
    }

    public void SpawnExplotion(Vector3 targetPosition)
    {
        var theExplo = thePool.Spawn(null);
        theExplo.transform.position = targetPosition;
    }    
    
    public void SpawnExplotion(GameObject target)
    {
        var theExplo = thePool.Spawn(target.transform);
        theExplo.transform.localPosition = Vector3.zero;
        theExplo.transform.SetParent(null, true);
    }
}