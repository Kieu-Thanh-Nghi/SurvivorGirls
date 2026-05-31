using UnityEngine;

public class ProjectileEmitter_Particle : ProjectileEmitter
{
    [SerializeField] ParticleSystem bulletEmitter;
    [SerializeField] AudioSource shootSound;

    public override void EmitProjectile()
    {
        bulletEmitter.Emit(1);
        shootSound?.Play();
    }

    protected virtual void OnParticleCollision(GameObject other)
    {
        Debug.Log("ProjectileEmitter_Particle - ParticleCollision");
        if (other.TryGetComponent<IDamageable>(out var damageable))
        {
            Debug.Log("ProjectileEmitter_Particle - BulletCollide");
            OnBulletCollide(damageable, other);
        }
    }

    protected virtual void OnBulletCollide(IDamageable damageable, GameObject other)
    {
        damageable.TakeDamage(hasDamage.GetDamage(), hasDamage.GetDamageType());
    }
}