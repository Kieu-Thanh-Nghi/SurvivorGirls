using UnityEngine;

public class StageHardLvl : MonoBehaviour
{
    [SerializeField] StageRewardChanger stageReward;
    [SerializeField] GameObject selectNormal, selectHard;
    GameObject currentLvl;

    public void ChangeHardLvlUI(int hardLvl)
    {
        currentLvl?.SetActive(false);
        if (hardLvl == 0)
        {
            SetCurrentLvlUI(selectNormal);
        }
        else
        {
            SetCurrentLvlUI(selectHard);
        }
        stageReward.ChangeStageReward(hardLvl);
    }

    void SetCurrentLvlUI(GameObject hardlvl)
    {
        hardlvl.SetActive(true);
        currentLvl = hardlvl;
    }
}
