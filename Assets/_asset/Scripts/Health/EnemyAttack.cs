using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    [SerializeField] int damage = 5;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == layerMask.value)
        {
            Debug.Log("aa");
            if (other.TryGetComponent<IDamageable>(out var damageable)){
                damageable.TakeDamage(damage, DamageType.Normal);
            }
        }
    }
}