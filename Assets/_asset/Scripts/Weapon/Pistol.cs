using Lean.Pool;
using UnityEngine;

public class Pistol : Weapon, IGunLockable
{
    [SerializeField] ProjectileEmiter emiter;
    [SerializeField] EnemyDetecter enemyDetecter;
    [SerializeField] BulletQuantity bulletQuantity;
    [SerializeField] WeaponData weaponData;
    [SerializeField] bool isLocked;

    private void Start()
    {
        emiter.SetHasDamageData(weaponData);
        InvokeRepeating(nameof(DoAttack), 0, AttackCountdown);
    }
    public void SetLockGun(bool isLock) => isLocked = isLock;
    public void Shoot(Vector3 Direct)
    {
        Direct.y = 0;
        emiter.transform.forward = Direct;
        emiter.Emit();
    }

    protected override void DoAttack()
    {
        if (isLocked) return;
        if(enemyDetecter.GetEnemyPos(out Vector3 EnemyPos))
        {
            Shoot(EnemyPos - emiter.transform.position);
            bulletQuantity.DecreaseBullet(this);
        }
    }
}

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] public float AttackCountdown;
    protected abstract void DoAttack();
}
