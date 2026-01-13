using UnityEngine;
using Lean.Pool;

public class BurnEff : Effect
{
    protected int damage;
    internal IDamageable damageable;
    internal IHasDamage hasDamage { set => damage = value.GetDamage(); }
    protected virtual void OnEnable()
    {
        Transform thisParent = transform.parent;
        damageable = thisParent?.GetComponent<IDamageable>();
        effectRunner.totalTime = totalTime;
        StartCoroutine(effectRunner.RunEff(damageTarget, endEff));
    }
    protected void damageTarget()
    {
        damageable.TakeDamage(damage, DamageType.Normal);
    }

    protected virtual void endEff()
    {
        StopAllCoroutines();
        LeanPool.Despawn(gameObject);
    }
}

