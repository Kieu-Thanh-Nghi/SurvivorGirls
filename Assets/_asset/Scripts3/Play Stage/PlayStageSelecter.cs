using System.Collections;
using UnityEngine;

public class PlayStageSelecter : MonoBehaviour
{
    [SerializeField] PlayStageUI playStageUI;
    PlayStageManager playStageManager => DatabaseManager.Instance.playStageManager;

    private void Start()
    {
        UpdateCurrentStageToUI();
    }
    public void ToNextStage()
    {
        playStageManager.CurrentIndex++;
        UpdateCurrentStageToUI();
    }

    public void ToPreviousStage()
    {
        playStageManager.CurrentIndex--;
        UpdateCurrentStageToUI();
    }

    void UpdateCurrentStageToUI()
    {
        var stage_data = playStageManager.GetChosenPlayStage();
        playStageUI.SetStageUI(stage_data.stage_name,
            playStageManager.CurrentIndex + 1,
            playStageManager.HardLvl);
    }

    public void SetHardLv(int hardLv_int)
    {
        var theHardLv = (PlayStageHardLv)hardLv_int;
        playStageManager.HardLvl = theHardLv;
        playStageUI.ChangeHardLvUI(theHardLv);
    }
}

public enum PlayStageHardLv
{
    Normal = 0,
    Hard = 1
}
