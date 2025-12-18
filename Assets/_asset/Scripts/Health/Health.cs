using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] internal int currentHP = 50;
    [SerializeField] UnityEvent OnHurt, OnDead;
    public void TakeDamage(int dameAmount)
    {
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
