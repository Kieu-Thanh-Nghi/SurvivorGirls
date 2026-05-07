using UnityEngine;

public class FireFlyingProjectile : FlyingProjectile
{
    [SerializeField] BurnStatusGiver burnStatusGiver;
    internal override void DoFly(RockData rockData, int theDamage = 1)
    {
        if(rockData is FireRockData fireRockData)
        {
            burnStatusGiver.BurnData_TotalTime = fireRockData.burnData_TotalTime;
            burnStatusGiver.BurnData_Damage = fireRockData.burnData_Damage;
        }
        base.DoFly(rockData, theDamage);
    }
}
