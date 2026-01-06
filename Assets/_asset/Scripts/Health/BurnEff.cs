using UnityEngine;
using Lean.Pool;

public class BurnEff : Effect
{
    [SerializeField] internal int damage = 1;
    internal IHasDamage hasDamage;
    internal IDamageable damageable;
    protected virtual void OnEnable()
    {
        Transform thisParent = transform.parent;
        damageable = thisParent?.GetComponent<IDamageable>();
        effectRunner.totalTime = totalTime;
        StartCoroutine(effectRunner.RunEff(damageTarget, endEff));
    }
    protected void damageTarget()
    {
        damageable.TakeDamage(hasDamage.GetDamage(), DamageType.Normal);
    }

    protected void endEff()
    {
        LeanPool.Despawn(gameObject);
    }
}

