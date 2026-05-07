using UnityEngine;

public class FrozeDroneColl : IceStatusGiver
{
    public override float IceData_TotalTime
        => iceData_TotalTime * (1 + PlayerDataManager.Instance.ElementBoost);
}
