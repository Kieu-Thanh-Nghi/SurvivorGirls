using UnityEngine;
using UnityEngine.UI;

public class MissionClaimButton : MonoBehaviour
{
    [SerializeField] Image buttonBG;
    [SerializeField] Button thisButton;
    [SerializeField] Sprite BgOn, BgOff;

    public void FreshButton()
    {
        buttonBG.sprite = BgOff;
        thisButton.enabled = false;
    }

    public void AvalableButton()
    {
        buttonBG.sprite = BgOn;
        thisButton.enabled = true;
    }
}
