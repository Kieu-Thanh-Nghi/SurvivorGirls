using UnityEngine;

public class BladeColl : MonoBehaviour
{
    internal ActiveSkill_BladeDrone bladeDronesManager;
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<IDamageable>(out var damageable)){
            damageable.TakeDamage(bladeDronesManager.damageEachBlade, DamageType.Normal);
        }
    }
}
