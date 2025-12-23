using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SkillSixthSense : GunAbility
{
    internal UnityAction DoWhenFireSixthSense;
    [SerializeField] int neededEnemies;
    [SerializeField] int neededShots;
    [SerializeField] NearestEnemiesDetecter NED;
    [SerializeField] Gun gun;
    List<Vector3> NearestEnePosies;
    int shotCounted = 0;

    private void Start()
    {
        gun.DoWhenShotABullet += ShotCount;
        NearestEnePosies = new List<Vector3>(neededEnemies);
    }
    public override void DoSkill()
    {
        NearestEnePosies = NED.GetNearestEnemies(neededEnemies);
        DoWhenFireSixthSense?.Invoke();

        int n = NearestEnePosies.Count;
        for (int i = 0; i < n; i++)
        {
            gun.Shoot(NearestEnePosies[i]);
        }
    }

    void ShotCount()
    {
        if(shotCounted < neededShots)
        {
            shotCounted++;
        }
        else
        {
            shotCounted = 0;
            DoSkill();
        }
    }
}

