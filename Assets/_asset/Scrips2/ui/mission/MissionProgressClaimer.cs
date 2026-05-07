using UnityEngine;

public class MissionProgressClaimer : MonoBehaviour
{
    [SerializeField] MissionProgress missionProgress;
    [SerializeField] TotalMissionProgress totalMissionProgress;
    [SerializeField] internal int energyPoint;

    //private void OnValidate()
    //{
    //    totalMissionProgress = GetComponentInParent<MissionProgressManager>().totalMissionProgress;
    //}

    public void ClaimThis()
    {
        missionProgress.TurnOnClaimedMark();
        totalMissionProgress.AddEnergy(energyPoint);
    }
}