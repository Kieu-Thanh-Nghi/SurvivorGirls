using UnityEngine;

public class BattleUI : MonoBehaviour
{
    [SerializeField] GameObject freeAdsButton;
    [SerializeField] StageSelect stageSelect;

    private void Start()
    {
        if(PlayerPrefs.GetInt(AdsManager.Instance.FreeADs_SaveKey) < 0)
        {
            freeAdsButton.SetActive(true);
        }
    }
    public void ToGamePlay()
    {
        SceneCtrler.instance.ChangeToGameplayScene(stageSelect);
    }
}
