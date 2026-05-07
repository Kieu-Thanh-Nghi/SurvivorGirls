using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class AMission : MonoBehaviour
{
    [SerializeField] UnityEvent OnRefreshed, OnMissionCompleted;
    [SerializeField] MissionProgress missionProgress;

    public void RefreshThis()
    {
        OnRefreshed?.Invoke();
        missionProgress.RefreshProgress();
    }

    public void CheckMission()
    {

    }
}
