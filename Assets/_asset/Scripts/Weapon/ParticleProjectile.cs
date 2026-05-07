using UnityEngine;

public class ParticleProjectile : ProjectileEmiter
{
    [SerializeField] ParticleSystem bulletEmitter;
    [SerializeField] AudioSource shootSound;

    public override void Emit()
    {
        bulletEmitter.Emit(1);
        shootSound?.Play();
    }

    public override void Emit(Vector3 targetPos)
    {
        Vector3 emiterPos = transform.position;
        emiterPos.y = targetPos.y;
        transform.position = emiterPos;
        //
        Vector3 direct = targetPos - transform.position;
        transform.forward = direct;
        //
        Emit();
    }

    protected virtual void OnParticleCollision(GameObject other)
    {
        if(other.TryGetComponent<IDamageable>(out var damageable))
        {
            OnBulletCollide(damageable, other);
        }
    }

    protected virtual void OnBulletCollide(IDamageable damageable, GameObject other)
    {
        damageable.TakeDamage(hasDamage.GetDamage(), hasDamage.GetDamageType());
    }
}

public abstract class ProjectileEmiter : MonoBehaviour
{
    protected IHasDamage hasDamage;
    public void SetHasDamageData(IHasDamage damageData) => hasDamage = damageData;

    public abstract void Emit();
    public abstract void Emit(Vector3 targetPos);
}
