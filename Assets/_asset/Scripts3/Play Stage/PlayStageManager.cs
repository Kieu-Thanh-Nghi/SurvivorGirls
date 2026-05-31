using System.Collections.Generic;
using UnityEngine;
using AASave;

public class PlayStageManager : MonoBehaviour
{
    [SerializeField] string currentStage_SaveName = "GameplayStage_CurrentChosen";
    [SerializeField] internal SaveSystem PlayStageSaveSystem;
    [SerializeField] internal List<GamePlayStageData> stages;
    internal PlayStageHardLv HardLvl;

    int currentIndex;
    internal int CurrentIndex
    {
        get 
        {
            Debug.Log("PlayStageManager - get currentIndex:" + currentIndex);
            return currentIndex;
        }
        set
        {
            if(value >= stages.Count)
            {
                currentIndex = stages.Count - 1;
            }
            else if(value < 0)
            {
                currentIndex = 0;
            }
            else
            {
                currentIndex = value;
            }
            PlayStageSaveSystem.Save(currentStage_SaveName, value);
            Debug.Log("PlayStageManager - Save currentIndex: " + value);
        }
    }
    protected void Awake()
    {
        currentIndex = PlayStageSaveSystem.Load(currentStage_SaveName, 0);
        Debug.Log("PlayStageManager - config load currentIndex: " + currentIndex);
    }
    public GamePlayStageData GetChosenPlayStage()
    {
        if(currentIndex >= 0 && currentIndex < stages.Count)
        {
            Debug.Log("PlayStageManager - GetChosenPlayStage: "
                + stages[currentIndex].gameObject.name);
            return stages[currentIndex];
        }
        else
        {
            Debug.Log("PlayStageManager - currentIndex khong nam trong list: " + currentIndex);
            return null;
        }
    }
}