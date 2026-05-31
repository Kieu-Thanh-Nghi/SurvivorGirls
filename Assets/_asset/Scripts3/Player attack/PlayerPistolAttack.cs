using UnityEngine;
using System.Collections;

public class PlayerPistolAttack : PlayerGunAttack, IGunLockable
{
    [SerializeField] int shotCounted = 0;
    [SerializeField] internal int neededShots;
    [SerializeField] internal AttackStrategy_DetectContinuous gunAttackStrategy_DetectContinuous;
    [SerializeField] internal AttackStrategy_DetectedSpread attackStrategy_DetectedSpread;
    internal AWeapon SixthSenseWeapon;

    private void Start()
    {
        SixthSenseWeapon = weapon;
    }

    public override void DoAttack()
    {
        StartCoroutine(AttackCoroutine());
    }

    public void ShotCount()
    {
        shotCounted++;
        if (shotCounted >= neededShots)
        {
            attackStrategy_DetectedSpread.ShootNearEnemies(eneDetecter, SixthSenseWeapon);
            shotCounted = 0;
        }
    }

    IEnumerator AttackCoroutine()
    {
        IsDone = false;
        if (!IsLocked)
        {
            yield return gunAttackStrategy_DetectContinuous.AttackCoroutine(this, rotateBody, weapon, DoWhenDoneAnAtk);
            bulletQuantity.DecreaseBullet(this);
        }
        IsDone = true;
    }
}