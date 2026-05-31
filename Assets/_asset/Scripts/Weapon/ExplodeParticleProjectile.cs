using UnityEngine;
using Lean.Pool;

public class ExplodeParticleProjectile : ProjectileEmitter_Particle
{
    [SerializeField] internal ExplotionEff explodeEff;
    [SerializeField] AudioSource exploSound;

    protected override void OnBulletCollide(IDamageable damageable, GameObject other)
    {
        Debug.Log(damageable == null);
        if(damageable is Health health)
        {
            explodeEff.SpawnExplotion(health.gameObject);
            exploSound.Play();
        }
        base.OnBulletCollide(damageable, other);
    }
}
