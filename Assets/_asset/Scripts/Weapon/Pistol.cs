using Lean.Pool;
using UnityEngine;

public class Pistol : Weapon, IGunLockable
{
    [SerializeField] ParticleSystem bulletEmitter;
    [SerializeField] EnemyDetecter enemyDetecter;
    [SerializeField] BulletQuantity bulletQuantity;
    [SerializeField] bool isLocked;

    public void SetLockGun(bool isLock) => isLocked = isLock;
    public void Shoot(Vector3 Direct)
    {
        Direct.y = 0;
        bulletEmitter.transform.forward = Direct;
        //Vector3 temp = bulletEmitter.transform.forward;
        //temp.y = 0;
        //bulletEmitter.transform.forward = temp;
        bulletEmitter.Emit(1);
    }

    protected override void DoAttack()
    {
        Debug.Log("ss");
        if (isLocked) return;
        if(enemyDetecter.GetEnemyPos(out Vector3 EnemyPos))
        {
            Shoot(EnemyPos - bulletEmitter.transform.position);
            bulletQuantity.DecreaseBullet(this);
        }
    }
}

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] public float AttackCountdown;

    private void Start()
    {
        InvokeRepeating(nameof(DoAttack), 0, AttackCountdown);
    }

    protected abstract void DoAttack();
}
