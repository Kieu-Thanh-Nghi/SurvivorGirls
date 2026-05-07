using UnityEngine;
using Lean.Pool;

public class ElectricEff : Effect
{
    [SerializeField] internal float speedDecreaseAmount = 0.5f;
    [SerializeField] internal int damage = 1;
    internal ISpeedChangable speedChangable;
    internal IDamageable damageable;
    internal virtual int Damage => Mathf.CeilToInt(damage * MultiplyAmount);
    internal virtual float SpeedDecreaseAmount => speedDecreaseAmount * MultiplyAmount;

    private void OnEnable()
    {
        Transform thisParent = transform.parent;
        speedChangable = thisParent?.GetComponent<ISpeedChangable>();
        damageable = thisParent?.GetComponent<IDamageable>();
        effectRunner.totalTime = TotalTime;
        speedChangable.SpeedMultiplyWith(1 - SpeedDecreaseAmount);
        StartCoroutine(effectRunner.RunEff(damageTarget, EndEff));
    }
    void damageTarget()
    {
        damageable.TakeDamage(Damage, DamageType.Normal);
    }
    public void SetEffData(float totalTime, int damage, float speedDecreaseAmount)
    {
        SetEffData(totalTime);
        this.damage = damage;
        this.speedDecreaseAmount = speedDecreaseAmount;
    }
    protected override void EndEff()
    {
        speedChangable.ResetSpeed();
        StopAllCoroutines();
        LeanPool.Despawn(gameObject);
    }
}

public class PlayerElectricEff : ElectricEff
{
    internal override int Damage 
        => Mathf.CeilToInt(base.Damage * (1 + PlayerDataManager.Instance.ElementBoost));

    internal override float TotalTime
        => base.TotalTime * (1 + PlayerDataManager.Instance.ElementBoost);
}