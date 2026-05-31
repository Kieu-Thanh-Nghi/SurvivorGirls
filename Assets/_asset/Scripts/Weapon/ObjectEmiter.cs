using UnityEngine;
using Lean.Pool;

public class ObjectEmiter : ProjectileEmitter
{
    [SerializeField] LeanGameObjectPool projectilePool;
    [SerializeField] Transform projectileCompas;
    [SerializeField] AudioSource shootSound;
    [SerializeField] Transform RootPos, targetPos;

    public override void EmitProjectile()
    {
        projectileCompas.forward = targetPos.position - RootPos.position;
        projectilePool.Spawn(RootPos.position, projectileCompas.rotation);
        shootSound?.Play();
    }
}