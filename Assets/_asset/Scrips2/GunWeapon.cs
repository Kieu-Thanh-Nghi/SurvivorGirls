using UnityEngine;

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
