using UnityEngine;
using UnityEngine.Events;

public class GunWeapon : BasicWeapon, IHasBulletWeapon ,IGunLockable
{
    [SerializeField] WeaponData weaponData;
    [SerializeField] BulletQuantity bulletQuantity;
    [SerializeField] internal bool isLocked;

    public void SetLockGun(bool isLock) => isLocked = isLock;

    void DecreaseBullet() => bulletQuantity.DecreaseBullet(this);

    public void EmitAttack(Vector3 targetPos)
    {
        DoOneAttack(targetPos);
        DecreaseBullet();
    }
}

public class BasicWeapon : MonoBehaviour, IWeapon
{
    [SerializeField] internal ProjectileEmiter emiter;
    internal Vector3 direct;

    public virtual void DoOneAttack(Vector3 targetPos)
    {
        direct = targetPos - emiter.transform.position;
        emiter.transform.forward = direct;
        emiter.Emit();
    }
}