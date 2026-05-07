using UnityEngine;
using TMPro;

public class StageName : MonoBehaviour
{
    [SerializeField] TMP_Text nameText;
    public void ChangeStageName(StageSelect stageSelect)
    {
        if (stageSelect.CurrentStage < 0) return;
        string stageIndex = (stageSelect.CurrentStage + 1).ToString();
        nameText.text = stageIndex + "." 
            + stageSelect.GetCurrentStage().StageName;
    }
}
