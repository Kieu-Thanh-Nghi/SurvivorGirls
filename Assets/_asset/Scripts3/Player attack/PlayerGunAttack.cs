using UnityEngine;
using UnityEngine.Events;

public class PlayerGunAttack : PlayerAttack, IHasEneDetecter, IGunLockable
{
    [SerializeField] internal NearestObjectSphereDetecter eneDetecter;
    [SerializeField] Transform target;
    [SerializeField] protected BulletQuantity bulletQuantity;
    internal bool IsLocked;
    internal bool isHasTarget;

    public bool IsHasTarget
    {
        get => isHasTarget;
        set => isHasTarget = value;
    }

    public bool CheckIfHasTarget()
    {
        Vector3 thisPos = transform.position;
        float attackRadius = eneDetecter.radius;
        isHasTarget = target != null
                        && target.gameObject.activeInHierarchy
                        && (target.position - thisPos).sqrMagnitude < attackRadius * attackRadius;
        return isHasTarget;
    }

    public void DetectNewTarget()
    {
        Vector3 thisPos = transform.position;
        if (!isHasTarget)
        {
            // ko co target
            eneDetecter.LimitMaxRadius();
            //-> tim target gan nhat
            if (eneDetecter.GetNearest(thisPos, out Transform result))
            {
                Debug.Log("Gun_AWeapon - detect target");
                target = result;
                isHasTarget = true;
            }
            else
            {
                target = null;
            }
        }
    }

    public Transform GetTarget()
    {
        return target;
    }
    public void SetLockGun(bool isLock)
    {
        IsLocked = isLock;
    }
}

public interface IHasEneDetecter
{
    public bool IsHasTarget
    {
        get;
        set;
    }
    public void DetectNewTarget();
    public bool CheckIfHasTarget();
    public Transform GetTarget();
}
