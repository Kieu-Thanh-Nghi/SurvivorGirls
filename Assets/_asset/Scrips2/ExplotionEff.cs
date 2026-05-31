using UnityEngine;
using Lean.Pool;

public class ExplotionEff : MonoBehaviour
{
    [SerializeField] internal LeanGameObjectPool thePool;
    [SerializeField] internal ExplodeSphere explodeSphere;
    [SerializeField] internal int Damage = 5;
    [SerializeField] internal float Radius = 0.4f;
    Vector3 scale = Vector3.one * 0.4f;
    [SerializeField] internal Vector3 Scale {
        get => scale;
        set => scale = value;
    }
    
    public void SpawnExplotion(GameObject target)
    {
        var theExplo = thePool.Spawn(target.transform);
        theExplo.transform.localPosition = Vector3.zero;
        theExplo.transform.localScale = scale;
        theExplo.transform.SetParent(null, true);
    }
}