using UnityEngine;

public class PlayerAtkSystem : MonoBehaviour, IHasTarget
{
    [SerializeField] internal float AttackCountdown;
    [SerializeField] NearestZombieDetecter eneDetecter;
    [SerializeField] GunWeapon gun;
    [SerializeField] Transform target;
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

    void AttackLoop(IEnemyDetecter detecter, IWeapon weapon, Vector3 thisPos)
    {
        float attackRadius = radius;
        if (target != null 
            && target.gameObject.activeSelf 
            && (target.position - thisPos).sqrMagnitude < attackRadius * attackRadius)
        {
            DoAttack(weapon, thisPos);
            return;
        }
        if (detecter.GetNearestEnemy(thisPos, out Transform result))
        {
            target = result;
        }
    }

    void DoAttack(IWeapon weapon, Vector3 thisPos)
    {
        if (isLock) return;
        weapon.EmitAttack(target.position);
        startTime = Time.time;
    }

    public Transform GetCurrentTarget() => target;
}

public interface IHasTarget
{
    public Transform GetCurrentTarget();
}

