using AASave;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    [SerializeField] GameObject preButton, nextButton;
    [SerializeField] StageName stageName;
    [SerializeField] List<GeneralAPlayStage> playStages;
    int maxStage;
    string maxStage_SaveName = "MaxStage";
    [SerializeField] StageHardLvl stageHardLvl;
    [SerializeField] StageRewardChanger stageReward;
    [SerializeField] internal int HardLvl;
    [SerializeField] int currentStage;
    internal int CurrentStage
    {
        get => currentStage;
        set
        {
            currentStage = value;
            if (value == 0) preButton.SetActive(false);
            else preButton.SetActive(true);
            if (value == playStages.Count - 1) nextButton.SetActive(false);
            else nextButton.SetActive(true);
        }
    }
    void ConfigMaxStage()
    {
        maxStage = Database.instance.PlayStageSaveSystem.Load(maxStage_SaveName, 0);
    }
    private void Start()
    {
        ConfigMaxStage();
        CurrentStage = maxStage;
        ChangeHardLvl(0);
        stageReward.ChangeStageReward(HardLvl);
        stageName.ChangeStageName(this);
    }
    public void ChangeHardLvl(int lvl)
    {
        HardLvl = lvl;
        stageHardLvl.ChangeHardLvlUI(lvl);
    }
    public void SetCurrentPlayStage(int theStage)
    {
        CurrentStage = theStage;
    }
    public GeneralAPlayStage GetCurrentStage()
    {
        return playStages[CurrentStage];
    }
    public PlayStage GetChosenPlayStage()
    {
        return playStages[CurrentStage].StagesByHardLv[HardLvl];
    }
    public string GetChosenStageName()
    {
        return playStages[CurrentStage].StageName;
    }
    public void GetNextStage()
    {
        if (CurrentStage < playStages.Count - 1) CurrentStage++;
        stageReward.ChangeStageReward(HardLvl);
        stageName.ChangeStageName(this);
    }

    public void GetPreviousStage()
    {
        if (CurrentStage > 0) CurrentStage--;
        stageReward.ChangeStageReward(HardLvl);
        stageName.ChangeStageName(this);
    }
}

[System.Serializable]
public class GeneralAPlayStage
{
    public string StageName;
    public List<PlayStage> StagesByHardLv;

    public GameObject GetStageReward(int hardLvl, Transform StageRewardContaner)
    {
        if (hardLvl < 0 && hardLvl >= StagesByHardLv.Count) return null;
        var aStage = StagesByHardLv[hardLvl];
        if (aStage.Reward == null)
        {
            aStage.Reward = Object.Instantiate(aStage.RewardPrefab, StageRewardContaner);
            aStage.Reward.LoadStageData(StageName + hardLvl);
        }
        return aStage.Reward.gameObject;
    }

    public void GetEnemySpawner(int hardLvl)
    {
        Object.Instantiate(StagesByHardLv[hardLvl].EnemySpawner);
    }

    public void GetPlayStageData(int hardLvl)
    {

    }
}
[System.Serializable]
public class PlayStage
{
    [SerializeField] internal string SceneName;
    [SerializeField] internal GameObject EnemySpawner;
    [SerializeField] internal StageRewards RewardPrefab;
    internal StageRewards Reward;

    public GameObject GetEnemySpawner()
    {
        return EnemySpawner;
    }

    public PlStageData GetPlayStageData()
    {
        return Reward.plStageData;
    }
}
