using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class MissionsTimeLimit : MonoBehaviour
{
    [SerializeField] internal RealtimeCooldown realtimeCooldown;
    [SerializeField] MissionProgressManager totalMissionProgress;
    [SerializeField] TMP_Text coolDown;
    [SerializeField] int cooldownTimeInSec;

    public void UpdateTimeText()
    {
        coolDown.text = "Refreshs in "
                + realtimeCooldown.GetTimeTextShort();
    }

#if UNITY_EDITOR
    [ContextMenu("ResetCoolDown")]
    void ResetCoolDown()
    {
        realtimeCooldown.Reset();
    }    
#endif
}
