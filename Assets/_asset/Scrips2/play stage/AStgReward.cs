using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AStgReward : MonoBehaviour
{
    [SerializeField] internal float requiredPlaytime;
    [SerializeField] Image glow;
    [SerializeField] GameObject ClaimedMark;
    [SerializeField] Button claimButton;
    [SerializeField] UnityEvent OnClaimReward;

    public void ClaimThis()
    {
        OnClaimReward?.Invoke();
        OnOffButton(false);
        TurnOnClaimedMark();
    }

    void TurnOnClaimedMark()
    {
        ClaimedMark.SetActive(true);
        claimButton.enabled = false;
    }

    void OnOffButton(bool isOn)
    {
        claimButton.enabled = isOn;
        glow.enabled = isOn;
    }


    public void ConfigThis(bool hasBounght, float stage_playtime)
    {
        if (hasBounght)
        {
            TurnOnClaimedMark();
            return;
        }

        if (requiredPlaytime * 60 <= stage_playtime && requiredPlaytime * 60 >= 0)
        {
            OnOffButton(true);
        }
    }
}
