using UnityEngine;
using Lean.Pool;

public class ExplodeParticleProjectile : ParticleProjectile
{
    [SerializeField] internal ExplotionEff explodeEff;

    protected override void OnParticleCollision(GameObject other)
    {
        if (other.TryGetComponent<IDamageable>(out var damageable))
        {
            Debug.Log(damageable == null);
            damageable.TakeDamage(hasDamage.GetDamage(), DamageType.Normal);
            explodeEff.SpawnExplotion(other.transform.position);
        }
    }
}
