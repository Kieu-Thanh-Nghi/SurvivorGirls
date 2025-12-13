using Lean.Pool;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] LeanGameObjectPool BulletPool;
    [SerializeField] float flyVelocity;

    private void Awake()
    {
        GetComponent<Rigidbody>().velocity = flyVelocity * transform.forward;
    }

    private void OnTriggerEnter(Collider other)
    {
        //other.transform.CompareTag(GameID.enemyTag);
        BulletPool.Despawn(gameObject);
    }
}
