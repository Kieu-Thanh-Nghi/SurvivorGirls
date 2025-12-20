using Lean.Pool;
using UnityEngine;
using UnityEngine.Events;

public class Gun : Weapon, IGunLockable
{
    [SerializeField] ProjectileEmiter emiter;
    [SerializeField] WeaponData weaponData;
    [SerializeField] BulletQuantity bulletQuantity;
    [SerializeField] internal bool isLocked;
    internal UnityAction DoWhenShotABullet;

    private void Start()
    {
        emiter.SetHasDamageData(weaponData);
    }
    public void SetLockGun(bool isLock) => isLocked = isLock;

    public void DecreaseBullet() => bulletQuantity.DecreaseBullet(this);

    public void Shoot(Vector3 enemyPos)
    {
        Vector3 direct = enemyPos - emiter.transform.position;
        direct.y = 0;
        emiter.transform.forward = direct;
        emiter.Emit();
    }
    public override void DoAttack(Vector3 enemyPos)
    {
        Shoot(enemyPos);
        DoWhenShotABullet?.Invoke();
    }
}

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] public float AttackCountdown;
    public abstract void DoAttack(Vector3 Direct);
}

public class GunAbility : MonoBehaviour
{
    public virtual void SetUpSkill() { }
    public virtual void DoSkill() { }
}

public class SkillSixthSense : GunAbility
{
    UnityAction DoWhenFireSixthSense;

    public override void DoSkill()
    {
        //do things
        DoWhenFireSixthSense?.Invoke();
    }
}

public class SkillMagnum : GunAbility
{

}