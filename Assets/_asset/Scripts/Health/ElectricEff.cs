using UnityEngine;
using Lean.Pool;

public class ElectricEff : Effect
{
    [SerializeField] internal float speedChangeAmount = 0.5f;
    [SerializeField] internal int damage = 1;
    internal ISpeedChangable speedChangable;
    internal IDamageable damageable;

    private void OnEnable()
    {
        Transform thisParent = transform.parent;
        speedChangable = thisParent?.GetComponent<ISpeedChangable>();
        damageable = thisParent?.GetComponent<IDamageable>();
        effectRunner.totalTime = totalTime;
        speedChangable.SpeedMultiplyWith(speedChangeAmount);
        StartCoroutine(effectRunner.RunEff(damageTarget, endEff));
    }

    void damageTarget()
    {
        damageable.TakeDamage(damage, DamageType.Normal);
    }

    void endEff()
    {
        speedChangable.ResetSpeed();
        StopAllCoroutines();
        LeanPool.Despawn(gameObject);
    }
}

