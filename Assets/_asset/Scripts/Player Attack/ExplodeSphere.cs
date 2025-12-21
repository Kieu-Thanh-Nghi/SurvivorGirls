using Lean.Pool;
using UnityEngine;

public class ExplodeSphere : MonoBehaviour
{
    [SerializeField] LayerMask layer;
    int damage = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == layer && other.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.TakeDamage(damage, DamageType.Normal);
        }            
        LeanPool.Despawn(gameObject);
    }

    public void SetDamage(int dame) => damage = dame;

    public void SetSize(Vector3 size) => transform.localScale = size;
}