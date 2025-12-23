using UnityEngine;
using UnityEngine.Events;

public class GunWeapon : MonoBehaviour, IWeapon, IGunLockable, IAttackObserver, IBulletShooter
{
    [SerializeField] internal ProjectileEmiter emiter;
    [SerializeField] WeaponData weaponData;
    [SerializeField] BulletQuantity bulletQuantity;
    [SerializeField] internal bool isLocked;
    internal UnityAction DoWhenDoneAnAtk, DoWhenAttack;

    private void Start()
    {
        emiter.SetHasDamageData(weaponData);
    }
    public void SetLockGun(bool isLock) => isLocked = isLock;

    public void DoOneAttack(Vector3 targetPos)
    {
        Vector3 direct = targetPos - emiter.transform.position;
        direct.y = 0;
        emiter.transform.forward = direct;
        emiter.Emit();
        DoWhenDoneAnAtk?.Invoke();
    }
    void DecreaseBullet() => bulletQuantity.DecreaseBullet(this);

    public void EmitAttack(Vector3 targetPos)
    {
        DoOneAttack(targetPos);
        DoWhenAttack?.Invoke();
        DecreaseBullet();
    }

    public void SubscribeAtkEvent(UnityAction WhenAttack)
    {
        DoWhenAttack += WhenAttack;
    }

    public void SubscribeOnlyOneShotEvent(UnityAction WhenOneAttack)
    {
        DoWhenDoneAnAtk += WhenOneAttack;
    }
}
