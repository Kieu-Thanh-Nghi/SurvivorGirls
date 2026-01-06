using UnityEngine;
using System.Collections.Generic;

public class TentacBotAttractEnemies : MonoBehaviour
{
    internal bool isSeftDistruct;
    internal IHasDamage hasDamage;
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<ITargetChangable>(out var targetChangable))
        {
            targetChangable.SetTarget(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isSeftDistruct)
        {
            other.GetComponent<IDamageable>().TakeDamage(hasDamage.GetDamage(), DamageType.Normal);
        }
        if (other.TryGetComponent<ITargetChangable>(out var targetChangable))
        {
            targetChangable.ResetTarget();
        }
    }
}

struct enemyOfTentacleRobot
{
    internal ITargetChangable thisTargetChangable;
    internal IDamageable damageable;
}