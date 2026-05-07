using TMPro;
using Unity.Services.LevelPlay;
using UnityEngine;

public class PurchaseButtonUIUpdater_AdReward : PurchaseButtonUIUpdater
{
    [SerializeField] RealtimeCooldown realtimeCooldown;
    [SerializeField] int cooldownSeconds;
    [SerializeField] TMP_Text CooldownTime;
    [SerializeField] GameObject onStage;

    bool isCooldownActive;

    private void Start()
    {
        if (realtimeCooldown.IsDone())
        {
            TurnOnButton();
            isCooldownActive = false;
        }
        else
        {
            TurnOffButton();
            isCooldownActive = true;
        }
    }

    protected override void TurnOnButton()
    {
        base.TurnOnButton();
        onStage.SetActive(true);
        CooldownTime.gameObject.SetActive(false);
    }

    protected override void TurnOffButton()
    {
        base.TurnOffButton();
        onStage.SetActive(false);
        CooldownTime.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (!realtimeCooldown.IsDone())
        {
            ShowCooldownToNextAd();
        }
        else if(isCooldownActive)
        {
            TurnOnButton();
            isCooldownActive = false;
            Debug.Log("ss");
        }
    }
    internal void StartCoolDownTimer()
    {
        realtimeCooldown.StartCooldown(cooldownSeconds);
        TurnOffButton();
        isCooldownActive = true;
    }

    void ShowCooldownToNextAd()
    {
        CooldownTime.text = realtimeCooldown.GetTimeText();
    }
}