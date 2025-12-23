using UnityEngine;
using Lean.Pool;

public class ExplodeParticleProjectile : ParticleProjectile
{
    [SerializeField] LeanGameObjectPool explodePool;

    protected override void OnParticleCollision(GameObject other)
    {
        if (other.TryGetComponent<IDamageable>(out var damageable))
        {
            Debug.Log(damageable == null);
            damageable.TakeDamage(hasDamage.GetDamage(), DamageType.Normal);
            explodePool.Spawn(other.transform.position);
        }
    }
}
