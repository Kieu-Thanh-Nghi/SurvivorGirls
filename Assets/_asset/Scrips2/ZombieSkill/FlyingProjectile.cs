using Lean.Pool;
using UnityEngine;

public class FlyingProjectile : MonoBehaviour, IProjectile
{
    [SerializeField] float lifeTime = 8;
    [SerializeField] Rigidbody rb;
    [SerializeField] bool isDestroyOnCollide = true;
    internal RockData rockData;
    float speed = 2;
    internal int damage;

    internal virtual void DoFly(RockData rockData, int theDamage = 1)
    {
        this.rockData = rockData;
        damage = theDamage;
        speed = rockData.projectileSpeed;
        DoFly();
    }
    public void DoFly()
    {
        CancelInvoke();
        rb.velocity = transform.forward * speed;
        Invoke(nameof(EndLife), lifeTime);
    }

    internal void EndLife()
    {
        LeanPool.Despawn(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.TakeDamage(damage, DamageType.Range);
            if (isDestroyOnCollide)
            {
                CancelInvoke();
                EndLife();
            }
        }
    }

}

public interface IProjectile
{
    public void DoFly();
}