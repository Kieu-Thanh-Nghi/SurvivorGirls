using UnityEngine;
using UnityEngine.Events;

public class AWeapon : MonoBehaviour
{
    [SerializeField] internal ProjectileEmitter projectileEmitter;
    [SerializeField] internal WeaponData weaponData;
    private void Start()
    {
        projectileEmitter.SetHasDamageData(weaponData);
    }
    public virtual void EmitAnAtk()
    {
        projectileEmitter.EmitProjectile();
    }    
    
    public virtual void EmitAnAtk(Transform target)
    {
        var emitterNewPos = projectileEmitter.transform.position;
        emitterNewPos.y = target.position.y;
        projectileEmitter.transform.position = emitterNewPos;
        projectileEmitter.EmitProjectile();
    }
    public virtual void EmitAnAtk(Vector3 targetPos)
    {
        Transform emitter = projectileEmitter.transform;
        var emitterDefaultRotation = emitter.rotation;

        var emitterNewPos = emitter.position;
        emitterNewPos.y = targetPos.y;
        emitter.position = emitterNewPos;

        emitter.forward = targetPos - emitterNewPos;
        projectileEmitter.EmitProjectile();

        emitter.rotation = emitterDefaultRotation;
    }
}
