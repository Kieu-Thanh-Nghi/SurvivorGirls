using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PistolSkill_SixthSense : MonoBehaviour
{
    internal UnityAction DoWhenFireSixthSense;
    [SerializeField] int neededEnemies;
    [SerializeField] int neededShots;
    IEnemyDetecter detecter;
    internal IWeapon weapon;
    [SerializeField] int shotCounted = 0;

    private void Start()
    {
        var eachAtkObserver = GetComponents<IEachAtkObserver>();
        foreach(var observer in eachAtkObserver)
        {
            observer.SubscribeOnlyOneShotEvent(ShotCount);
        }
        detecter = GetComponent<IEnemyDetecter>();
        weapon = GetComponent<IWeapon>();
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

public class PistolSkillInjection : MonoBehaviour
{
    public void InjectFirstSkill()
    {
        gameObject.AddComponent<PistolSkill_Training>();
    }
    public void InjectSecondSkill()
    {
        gameObject.AddComponent<PistolSkill_SixthSense>();
    }
    public void InjectThirdSkill()
    {
        gameObject.AddComponent<PistolSkill_Magnum>();
    }
}