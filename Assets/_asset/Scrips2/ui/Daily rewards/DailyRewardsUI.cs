using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailyRewardsUI : MonoBehaviour
{
    [SerializeField] string ClamedDays_SaveKey, ClaimedToday_SaveKey;
    [SerializeField] int maxDay;
    [SerializeField] Button ClaimButton;
    [SerializeField] ADayReward[] rewards;
    DailyProduct dailyProduct;
    int achiveDay;

    private void Start()
    {
        dailyProduct = new(ClaimedToday_SaveKey);
        ConfigAchiveDay();
        SetClaimedPreviousDays();
        CheckIfClaimedToday(dailyProduct);
    }

    void ConfigAchiveDay()
    {
        if (PlayerPrefs.HasKey(ClamedDays_SaveKey))
        {
            achiveDay = PlayerPrefs.GetInt(ClamedDays_SaveKey);
        }
        else
        {
            PlayerPrefs.SetInt(ClamedDays_SaveKey, 0);
            PlayerPrefs.Save();
            achiveDay = 0;
        }
    }

    void SetClaimedPreviousDays()
    {
        for (int i = 0; i < achiveDay; i++)
        {
            rewards[i].CheckClaimedThis();
        }
    }

    void CheckIfClaimedToday(DailyProduct dailyProduct)
    {
        if (dailyProduct.IsNewDay())
        {
            rewards[achiveDay].AvalableThis();
            ClaimButton.gameObject.SetActive(true);
        }
    }

    public void ClaimTodayReward()
    {
        rewards[achiveDay].ClaimThis();
        ClaimButton.gameObject.SetActive(false);
        achiveDay++;
        if (achiveDay >= maxDay)
        {
            achiveDay = 0;
        }
        SaveTodayAchive(achiveDay);
    }

    void SaveTodayAchive(int achive_day)
    {
        PlayerPrefs.SetInt(ClamedDays_SaveKey, achive_day);
        PlayerPrefs.Save();
        dailyProduct.SaveAchive();
    }

#if UNITY_EDITOR
    [ContextMenu("reset daily")]
    void ResetDaily()
    {
        PlayerPrefs.SetInt(ClamedDays_SaveKey, 0);
        PlayerPrefs.Save();
        dailyProduct.Reset();
    }    
    
    [ContextMenu("ToNewDay")]
    void ToNewDay()
    {
        dailyProduct.Reset();
    }
#endif
}