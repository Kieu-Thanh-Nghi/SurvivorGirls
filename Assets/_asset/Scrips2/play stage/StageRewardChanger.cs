using UnityEngine;

public class StageRewardChanger : MonoBehaviour
{
    [SerializeField] Transform StageProgress;
    [SerializeField] GameObject StageRewardUI;
    [SerializeField] StageSelect stageSelect;

    public void ChangeStageReward(int hardLvl)
    {
        var thisStage = stageSelect.GetCurrentStage();
        if(StageRewardUI != null) StageRewardUI.SetActive(false);
        var newStageReward = thisStage.GetStageReward(hardLvl, StageProgress);
        if (newStageReward == null) return;
        newStageReward.SetActive(true);
        StageRewardUI = newStageReward;
    }
}
