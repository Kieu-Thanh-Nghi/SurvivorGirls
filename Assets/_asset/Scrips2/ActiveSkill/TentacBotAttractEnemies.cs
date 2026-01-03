using UnityEngine;
using System.Collections.Generic;

public class TentacBotAttractEnemies : MonoBehaviour
{
    List<Collider> effectedEnemies = new List<Collider>(10);
    List<ITargetChangable> targetChangables = new List<ITargetChangable>(10);
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<ITargetChangable>(out var targetChangable))
        {
            targetChangable.SetTarget(transform);
            effectedEnemies.Add(other);
            targetChangables.Add(targetChangable);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("ss");
        if (other.TryGetComponent<ITargetChangable>(out var targetChangable))
        {
            targetChangable.ResetTarget();
            effectedEnemies.Remove(other);
            targetChangables.Remove(targetChangable);
        }
    }

    internal void DamageEnemies(int theDamage)
    {
        for(int i = 0; i < effectedEnemies.Count; i++)
        {
            effectedEnemies[i].GetComponent<IDamageable>().TakeDamage(theDamage, DamageType.Normal);
            targetChangables[i].ResetTarget();
        }
        effectedEnemies.Clear();
        targetChangables.Clear();
    }
}

struct enemyOfTentacleRobot
{
    internal ITargetChangable thisTargetChangable;
    internal IDamageable damageable;
}