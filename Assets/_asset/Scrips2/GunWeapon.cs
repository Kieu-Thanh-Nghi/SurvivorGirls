using UnityEngine;
using UnityEngine.Events;

public class GunWeapon : BasicWeapon, IHasBulletWeapon ,IGunLockable
{
    [SerializeField] WeaponData weaponData;
    [SerializeField] BulletQuantity bulletQuantity;
    [SerializeField] internal bool isLocked;

    private void Start()
    {
        emiter.SetHasDamageData(weaponData);
    }
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

    public void DoOneAttack(Vector3 targetPos)
    {
        Vector3 direct = targetPos - emiter.transform.position;
        direct.y = 0;
        emiter.transform.forward = direct;
        emiter.Emit();
    }
}