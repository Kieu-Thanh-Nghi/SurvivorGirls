using Lean.Pool;
using UnityEngine;

public class ExplodeSphere : MonoBehaviour
{
    [SerializeField] LayerMask layer;
    [SerializeField] ExplotionEff explotionEff;

    private void OnEnable()
    {
        explotionEff.thePool.Despawn(gameObject, 2); 
        var colls = Physics.OverlapSphere(transform.position + Vector3.up, explotionEff.Radius, layer);
        foreach(var col in colls)
        {
            if (col.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.TakeDamage(explotionEff.Damage, DamageType.Normal);
            }
        }
    }
}