using UnityEngine;
using UnityEngine.Events;

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
            damageable.TakeDamage(hasDamage.GetDamage(), DamageType.Normal);
            DoWhenBulletHit?.Invoke(other.transform);
        }
    }
}

public abstract class ProjectileEmiter : MonoBehaviour
{
    protected IHasDamage hasDamage;
    internal UnityAction<Transform> DoWhenBulletHit;
    public void SetHasDamageData(IHasDamage damageData) => hasDamage = damageData;

    public abstract void Emit();
}
