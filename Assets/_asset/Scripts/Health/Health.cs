using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, IDamageable, ISetOnDead
{
    [SerializeField] internal int maxHP = 50;
    [SerializeField] internal UnityEvent OnDead, OnHurt, OnHeal, OnChangeHeal;
    int currentHP;
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
    internal UnityAction<int> OnHealLostAmount, OnHealGainAmount;

    private void OnEnable()
    {
        CurrentHP = maxHP;
    }
    public void TakeDamage(int dameAmount, DamageType type)
    {
        if (isImmute) return;
        OnHealLostAmount?.Invoke(dameAmount);
        CurrentHP -= dameAmount;
        if(CurrentHP <= 0)
        {
            OnDead?.Invoke();
            return;
        }
        OnHurt?.Invoke();
    }

    public void Healing(int healAmount)
    {
        if (CurrentHP < maxHP)
        {
            CurrentHP += healAmount;
            OnHealGainAmount?.Invoke(healAmount);
            OnHeal?.Invoke();
        }
        if (CurrentHP > maxHP)
        {
            CurrentHP = maxHP;
        }
    }

    public void SetDoWhenDie(UnityAction DieFunc)
    {
        OnDead.AddListener(DieFunc);
    }
}
