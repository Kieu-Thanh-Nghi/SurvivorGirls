using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PistolSkill_SixthSense : MonoBehaviour
{
    internal UnityAction DoWhenFireSixthSense;
    [SerializeField] int neededEnemies;
    [SerializeField] int neededShots;
    IBulletShooter bulletShooter;
    IEnemyDetecter detecter;
    IWeapon weapon;
    [SerializeField] int shotCounted = 0;
    bool isShooting = false;

    private void Start()
    {
        bulletShooter = GetComponent<IBulletShooter>();
        detecter = GetComponent<IEnemyDetecter>();
        weapon = GetComponent<IWeapon>();

        bulletShooter.SubscribeOnlyOneShotEvent(ShotCount);
    }

    void ShootNearEnemies(IEnemyDetecter detecter, IWeapon weapon)
    {
        List<Vector3> targetsPos = detecter.GetManyNearestEnemies(neededEnemies, transform.position);
        int n = targetsPos.Count;
        if (n < 1) return;
        if (n > neededEnemies) n = neededEnemies;
        for (int i = 0; i < n; i++)
        {
            weapon.DoOneAttack(targetsPos[i]);
        }
        shotCounted = 0;
    }

    void ShotCount()
    {
        if (shotCounted < neededShots)
        {
            shotCounted++;
        }
        else
        {
            ShootNearEnemies(detecter, weapon);
        }
    }
}

