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

    public override void Emit(Vector3 direct)
    {
        TurnToDirection(transform, direct);
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
    [SerializeField] protected int projectileFaceDir = 0;
    protected IHasDamage hasDamage;
    public void SetHasDamageData(IHasDamage damageData) => hasDamage = damageData;

    public abstract void Emit();
    public abstract void Emit(Vector3 direction);

    protected void TurnToDirection(Transform turnedObj, Vector3 direction)
    {
        switch (projectileFaceDir)
        {
            case -1:
                turnedObj.transform.up = direction;
                break;
            case 0:
                turnedObj.transform.forward = direction;
                break;
            case 1:
                turnedObj.transform.right = direction;
                break;
        }
    }
}
