using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames.BasicApi;

public abstract class MissionProgress : MonoBehaviour
{
    [SerializeField] protected string progressSave_Key;
    [SerializeField] protected ProgressSetter progressSetter;
    [SerializeField] GameObject MissionCompleteMark;

    private void OnValidate()
    {
        progressSetter = GetComponent<ProgressSetter>();
    }
    internal int ProgressAmount
    {
        get
        {
            return GetHavingProgressAmount();
        }
        set
        {
            int havingAmount = GetHavingProgressAmount();
            int neededAmount = GetNeedProgressAmount();
            if (havingAmount != value)
            {
                progressSetter.SetProgress(value, neededAmount);
                PlayerPrefs.SetInt(progressSave_Key, value);
                PlayerPrefs.Save();
            }
        }
    }
    public void ConfigProgress()
    {
        int havingAmount = GetHavingProgressAmount();
        Debug.Log(havingAmount);
        if (havingAmount < 0)
        {
            MissionCompleteMark.SetActive(true);
            return;
        }
        if (havingAmount == 0) return;
        int neededAmount = GetNeedProgressAmount();
        progressSetter.SetProgress(havingAmount, neededAmount);
    }
    public abstract int GetNeedProgressAmount();
    public int GetHavingProgressAmount()
    {
        if (PlayerPrefs.HasKey(progressSave_Key))
        {
            return PlayerPrefs.GetInt(progressSave_Key);
        }
        else
        {
            return 0;
        }
    }
    public virtual void UpdateMissionProgress()
    {
        if (ProgressAmount < 0) return;
        UpdateMission();
    }

    protected virtual void UpdateMission()
    {
        progressSetter.SetProgress(GetHavingProgressAmount(), GetNeedProgressAmount());
    }
    public virtual void TurnOnClaimedMark()
    {
        MissionCompleteMark.SetActive(true);
        PlayerPrefs.SetInt(progressSave_Key, -1);
        PlayerPrefs.Save();
    }

    public virtual void RefreshProgress()
    {
        MissionCompleteMark.SetActive(false);
        ProgressAmount = 0;
    }
}
