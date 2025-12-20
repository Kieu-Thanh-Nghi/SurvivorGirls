using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] internal int currentHP = 50;
    [SerializeField] UnityEvent OnDead, OnHurt;
    internal UnityAction<int> OnTakeDamage;
    public void TakeDamage(int dameAmount, DamageType type)
    {
        OnTakeDamage?.Invoke(dameAmount);
        currentHP -= dameAmount;
        if(currentHP <= 0)
        {
            OnDead?.Invoke();
            return;
        }
        OnHurt?.Invoke();
        Debug.Log("takedame " + dameAmount);
    }
}