using UnityEngine;
using UnityEngine.Events;

public class PlayerGunAtkSystem : MonoBehaviour, IHasTarget, IAttackObserver, IEachAtkObserver, ITargetChangable
{
    [SerializeField] internal float AttackCountdown;
    [SerializeField] NearestObjectSphereDetecter eneDetecter;
    [SerializeField] internal GunWeapon gun;
    [SerializeField] Transform target;
    internal UnityAction DoWhenAttack, DoWhenDoneAnAtk;
    float startTime;
    bool isLock { get => gun.isLocked; }
    float radius { get => eneDetecter.radius; }

    private void Start()
    {
        startTime = Time.time - AttackCountdown;
    }

    private void Update()
    {
        if (Time.time - startTime >= AttackCountdown)
        {
            AttackLoop(eneDetecter, gun, transform.position);
        }
    }

    void AttackLoop(INearestDetecter detecter, IHasBulletWeapon weapon, Vector3 thisPos)
    {
        float attackRadius = radius;
        if (target != null 
            && target.gameObject.activeInHierarchy 
            && (target.position - thisPos).sqrMagnitude < attackRadius * attackRadius)
        {
            DoAttack(weapon, thisPos);
            return;
        }
        eneDetecter.LimitMaxRadius();
        if (detecter.GetNearest(thisPos, out Transform result))
        {
            target = result;
        }
    }

    void DoAttack(IHasBulletWeapon weapon, Vector3 thisPos)
    {
        if (isLock) return;
        weapon.EmitAttack(target.position);
        DoWhenAttack?.Invoke();
        DoWhenDoneAnAtk?.Invoke();
        startTime = Time.time;
    }

    public Transform GetCurrentTarget() => target;

    public void SubscribeAtkEvent(UnityAction WhenAttack)
    {
        DoWhenAttack += WhenAttack;
    }

    public void SubscribeOnlyOneShotEvent(UnityAction WhenOneAttack)
    {
        DoWhenDoneAnAtk += WhenOneAttack;
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    public void ResetTarget()
    {
        target = null;
    }
}

public interface IHasTarget
{
    public Transform GetCurrentTarget();
}

