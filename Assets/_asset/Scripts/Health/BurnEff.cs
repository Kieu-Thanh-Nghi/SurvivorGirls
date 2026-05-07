using UnityEngine;
using Lean.Pool;

public class BurnEff : Effect
{
    internal int damage;
    internal IDamageable damageable;
    internal IHasDamage hasDamage { set => damage = value.GetDamage(); }
    internal virtual int Damage => Mathf.CeilToInt(damage * MultiplyAmount);
    protected virtual void OnEnable()
    {
        Transform thisParent = transform.parent;
        damageable = thisParent?.GetComponent<IDamageable>();
        effectRunner.totalTime = totalTime;
        StartCoroutine(effectRunner.RunEff(DamageTarget, EndEff));
    }
    public void SetEffData(float totalTime, int damage)
    {
        SetEffData(totalTime);
        this.damage = damage;
    }
    protected void DamageTarget()
    {
        damageable.TakeDamage(Damage, DamageType.Normal);
    }

    protected override void EndEff()
    {
        StopAllCoroutines();
        LeanPool.Despawn(gameObject);
    }
}