using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class MissionProgressManager : MonoBehaviour
{
    [SerializeField] RealtimeCooldown realtimeCooldown;
    [SerializeField] int cooldownTimeInSec;
    [SerializeField] internal TotalMissionProgress totalMissionProgress;
    [SerializeField] List<MissionProgress> missionList;
    [SerializeField] TMP_Text coolDown;

    public void ConfigThis()
    {
        if (realtimeCooldown.IsDone())
        {
            realtimeCooldown.StartCooldown(cooldownTimeInSec);
            RefreshMissions();
        }
    }
    private void OnEnable()
    {
        CheckMissions();
    }

    private void Start()
    {
        ConfigMissions();
    }

    private void Update()
    {
        if (realtimeCooldown.IsDone())
        {
            realtimeCooldown.StartCooldown(cooldownTimeInSec);
            RefreshMissions();
        }
        coolDown.text = "Refreshs in "
                + realtimeCooldown.GetTimeTextShort();
    }

    public void ConfigMissions()
    {
        Debug.Log("mission config");
        foreach (var aMission in missionList)
        {
            aMission.ConfigProgress();
        }
    }

    [ContextMenu("RefreshMission")]
    public void RefreshMissions()
    {
        Debug.Log("mission Refresh");
        foreach (var aMission in missionList)
        {
            aMission.RefreshProgress();
        }
        totalMissionProgress.Refresh();
    }

    public void CheckMissions()
    {
        Debug.Log("UpdateMissionProgress");
        foreach (var aMission in missionList)
        {
            aMission.UpdateMissionProgress();
        }
    }

#if UNITY_EDITOR
    [ContextMenu("ResetCoolDown")]
    void ResetCoolDown()
    {
        realtimeCooldown.Reset();
    }
#endif
}