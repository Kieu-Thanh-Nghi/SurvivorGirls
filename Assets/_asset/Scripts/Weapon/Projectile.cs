using Lean.Pool;
using UnityEngine;

public class Projectile : MonoBehaviour, IProjectile
{
    [SerializeField] internal LeanGameObjectPool BulletPool;
    [SerializeField] internal Rigidbody rb;
    [SerializeField] internal float lifeTime = 8;
    [SerializeField] internal float flyVelocity;
    internal int damage;

    private void OnEnable()
    {
        DoFly();
    }
    public void DoFly()
    {
        rb.velocity = flyVelocity * transform.forward;
        CancelInvoke();
        Invoke(nameof(EndLife), lifeTime);
    }

    void EndLife()
    {
        LeanPool.Despawn(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.TakeDamage(damage, DamageType.Range);
        }
    }

}
