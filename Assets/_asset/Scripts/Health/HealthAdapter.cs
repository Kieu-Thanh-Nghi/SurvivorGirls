using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAdapter : MonoBehaviour, IDamageable
{
    [SerializeField] Health health;
    public void TakeDamage(int dameAmount, DamageType type) => health.TakeDamage(dameAmount, type);
}
