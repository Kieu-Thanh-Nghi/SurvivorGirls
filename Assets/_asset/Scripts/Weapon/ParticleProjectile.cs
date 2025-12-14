using UnityEngine;

public class ParticleProjectile : ProjectileEmiter
{
    [SerializeField] ParticleSystem bulletEmitter;

    public override void Emit()
    {
        bulletEmitter.Emit(1);
    }
    private void OnParticleCollision(GameObject other)
    {
        if(other.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.TakeDamage(hasDamage.GetDamage());
        }
    }
}

public abstract class ProjectileEmiter : MonoBehaviour
{
    protected IHasDamage hasDamage;
    public void SetHasDamageData(IHasDamage damageData) => hasDamage = damageData;

    public abstract void Emit();
}
