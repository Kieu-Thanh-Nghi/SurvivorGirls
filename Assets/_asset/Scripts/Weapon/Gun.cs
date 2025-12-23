using Lean.Pool;
using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour, IGunLockable
{
    [SerializeField] internal ProjectileEmiter emiter;
    [SerializeField] WeaponData weaponData;
    [SerializeField] BulletQuantity bulletQuantity;
    [SerializeField] internal bool isLocked;
    [SerializeField] public float AttackCountdown;
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
    public virtual void DoAttack(Vector3 enemyPos)
    {
        Shoot(enemyPos);
        DoWhenShotABullet?.Invoke();
    }
}

public class GunAbility : MonoBehaviour
{
    public virtual void SetUpSkill() { }
    public virtual void DoSkill() { }
}

public class SkillMagnum : GunAbility
{
    [SerializeField] Gun gun;
    [SerializeField] SkillSixthSense sixthSense;
    [SerializeField] LeanGameObjectPool ExplodePool;
    bool isActivated;

    private void Start()
    {
        SetUpSkill();
    }
    public override void SetUpSkill()
    {
        sixthSense.DoWhenFireSixthSense += DoWhenSixthSense;
    }

    void DoWhenSixthSense() => isActivated = true;

    void DoSkill(Transform eneTransform)
    {
        if(!isActivated) return;
        ExplodePool.Spawn(eneTransform.position);
    }
}
