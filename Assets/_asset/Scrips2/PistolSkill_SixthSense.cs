using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PistolSkill_SixthSense : MonoBehaviour
{
    internal UnityAction DoWhenFireSixthSense;
    [SerializeField] internal int neededEnemies;
    [SerializeField] internal int neededShots;
    INearestDetecter detecter;
    internal IWeapon weapon;
    [SerializeField] int shotCounted = 0;

    public void SetUp(IEachAtkObserver[] eachAtkObserver, 
        INearestDetecter nearestDetecter,
        IWeapon theWeapon)
    {
        foreach (var observer in eachAtkObserver)
        {
            observer.SubscribeOnlyOneShotEvent(ShotCount);
        }
        detecter = nearestDetecter;
        weapon = theWeapon;
    }

    void ShootNearEnemies(INearestDetecter detecter, IWeapon weapon)
    {
        List<Vector3> targetsPos = detecter.GetManyNearest(neededEnemies, transform.position);
        int n = targetsPos.Count;
        if (n < 1) return;
        if (n > neededEnemies) n = neededEnemies;
        for (int i = 0; i < n; i++)
        {
            weapon?.DoOneAttack(targetsPos[i]);
        }
    }

    void ShotCount()
    {
        shotCounted++;
        if(shotCounted >= neededShots)
        {
            ShootNearEnemies(detecter, weapon);
            shotCounted = 0;
        }
    }
}
