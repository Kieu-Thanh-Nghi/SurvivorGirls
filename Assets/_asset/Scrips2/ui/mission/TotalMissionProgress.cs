using UnityEngine;
using UnityEngine.UI;
using TMPro;
using AASave;

public class TotalMissionProgress : MonoBehaviour
{
    [SerializeField] internal SaveSystem saveSystem;
    [SerializeField] Image fillMask;
    [SerializeField] TMP_Text claimedEnergyPoints;
    [SerializeField] int maxEP;
    [SerializeField] internal string totalEnergy_SaveKey;
    [SerializeField] TotalProgressReward[] totalProgressRewards;

    private void Awake()
    {
        fillMask.fillAmount = (float)GetCurrentEP() / maxEP;
        claimedEnergyPoints.text = GetCurrentEP().ToString();
    }
    private void Start()
    {
        UpdateRewardStage();
    }
    public void AddEnergy(int theEnergy)
    {
        int totalEP = GetCurrentEP() + theEnergy;
        PlayerPrefs.SetInt(totalEnergy_SaveKey, totalEP);
        fillMask.fillAmount = (float)totalEP / maxEP;
        claimedEnergyPoints.text = totalEP.ToString();
        UpdateRewardStage();
    }
    public int GetCurrentEP()
    {
        if (PlayerPrefs.HasKey(totalEnergy_SaveKey))
        {
            return PlayerPrefs.GetInt(totalEnergy_SaveKey);
        }
        else
        {
            return 0;
        }
    }
    public void Refresh()
    {
        RefreshRewards();
        PlayerPrefs.SetInt(totalEnergy_SaveKey, 0);
        fillMask.fillAmount = 0;
        claimedEnergyPoints.text = "0";
    }

    public void UpdateRewardStage()
    {
        foreach (var reward in totalProgressRewards)
        {
            if (reward.neededEnergyPoint > GetCurrentEP())
            {
                return;
            }
            if (reward.IsClaimed()) reward.TurnOnClaimedMark();
            else reward.AvalableButton();
        }
        //ktra xem energy can co lon hon energy hien tai khong => return
        //xem da nhan chua? => tich v
        //xem da du energy chua => glow, bat button
    }

    public void RefreshRewards()
    {
        foreach (var reward in totalProgressRewards)
        {
            if (reward.neededEnergyPoint > GetCurrentEP())
            {
                return;
            }
            reward.RefreshThis();
        }
        //tat v, tat glow. tat button
    }
}