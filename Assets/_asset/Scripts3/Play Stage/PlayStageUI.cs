using UnityEngine;
using TMPro;

public class PlayStageUI : MonoBehaviour
{
    [SerializeField] TMP_Text playStage_name;
    [SerializeField] GameObject NormalSelectLine, HardSelectLine;

    public void SetStageUI(string stage_name, int stageIndex, PlayStageHardLv hardLv)
    {
        playStage_name.text = stageIndex + "." + stage_name.ToUpper();
        ChangeHardLvUI(hardLv);
    }

    public void ChangeHardLvUI(PlayStageHardLv hardLv)
    {
        switch (hardLv)
        {
            case PlayStageHardLv.Normal:
                NormalSelectLine.SetActive(true);
                HardSelectLine.SetActive(false);
                break;
            case PlayStageHardLv.Hard:
                NormalSelectLine.SetActive(false);
                HardSelectLine.SetActive(true);
                break;
        }
    }
}
