using UnityEngine;

public class IceFlyingProjectile : FlyingProjectile
{
    [SerializeField] IceStatusGiver iceStatusGiver;
    internal override void DoFly(RockData rockData, int theDamage = 1)
    {
        if(rockData is IceRockData IceRockData)
        {
            iceStatusGiver.iceData_TotalTime = IceRockData.iceData_TotalTime;
        }
        base.DoFly(rockData, theDamage);
    }
}