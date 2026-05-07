using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, IDamageable, ISetOnDead, IHasMaxHealth
{
    [SerializeField] internal UnityEvent OnDead, OnHurt, OnHeal, OnChangeHeal;
    internal int MaxHP;
    [SerializeField] int currentHP;
    internal bool isImmute;
    internal int CurrentHP
    {
        get => currentHP;
        set
        {
            currentHP = value;
            OnChangeHeal?.Invoke();
        }
    }
    internal UnityAction<int> OnHealthLostAmount, OnHealthGainAmount;

    public void TakeDamage(int dameAmount, DamageType type)
    {
        if (isImmute) return;
        GetHurt(dameAmount, type);
    }

    protected virtual void GetHurt(int dameAmount, DamageType type)
    {
        OnHealthLostAmount?.Invoke(dameAmount);
        CurrentHP -= dameAmount;
        if (CurrentHP <= 0)
        {
            OnDead?.Invoke();
            return;
        }
        OnHurt?.Invoke();
    }

    public void Healing(int healAmount)
    {
        if (CurrentHP < MaxHP)
        {
            CurrentHP += healAmount;
            OnHealthGainAmount?.Invoke(healAmount);
            OnHeal?.Invoke();
        }
        if (CurrentHP > MaxHP)
        {
            CurrentHP = MaxHP;
        }
    }

    public void SetDoWhenDie(UnityAction DieFunc)
    {
        OnDead.AddListener(DieFunc);
    }

    public int GetMaxHp() => MaxHP;

    public void SetMaxHp(int maxHP)
    {
        MaxHP = maxHP;
    }
}