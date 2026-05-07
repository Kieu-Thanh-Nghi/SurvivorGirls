using Lean.Pool;
using UnityEngine;

public class FlyingProjectile : MonoBehaviour
{
    [SerializeField] float lifeTime = 8;
    [SerializeField] Rigidbody rb;
    internal RockData rockData;
    float speed = 2;
    internal int damage;

    internal virtual void DoFly(RockData rockData, int theDamage = 1)
    {
        this.rockData = rockData;
        damage = theDamage;
        speed = rockData.projectileSpeed;
        rb.velocity = transform.forward * speed;
        Invoke(nameof(EndLife), lifeTime);
    }

    void EndLife()
    {
        LeanPool.Despawn(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.TakeDamage(damage, DamageType.Range);
            CancelInvoke();
            EndLife();
        }
    }
}
