using System.Collections.Generic;
using UnityEngine;

public class StageRewards : MonoBehaviour
{
    [SerializeField] List<AStgReward> stgRewards;
    internal PlStageData plStageData;
    public void LoadStageData(string ThisStageName)
    {
        plStageData = new(ThisStageName, stgRewards.Count);
    }
    private void Start()
    {
        int n = stgRewards.Count;
        Debug.Log(plStageData.rewardBoughtInfo);
        for(int i = 0; i < n; i++)
        {
            Debug.Log(plStageData.rewardBoughtInfo[i]);
            var hasBought = plStageData.rewardBoughtInfo[i];
            stgRewards[i].ConfigThis(hasBought, plStageData.playtime);
        }
    }

    public void ClaimAReward(int rewardIndex)
    {
        stgRewards[rewardIndex].ClaimThis();
        plStageData.rewardBoughtInfo[rewardIndex] = true;
        plStageData.SaveData();
    }
}

[System.Serializable]
public class PlStageData
{
    [SerializeField] internal float playtime;
    [SerializeField] internal List<bool> rewardBoughtInfo = new();
    internal string save_name;

    public PlStageData(string save_name, int reward_quantity)
    {
        this.save_name = save_name;
        LoadData(reward_quantity);
        Debug.Log("playtime: " + playtime + " / " + "BoughtInfo: " + rewardBoughtInfo[0] + " " + rewardBoughtInfo[1] + " " + rewardBoughtInfo[2]);
    }
    public void LoadData(int reward_quantity)
    {
        string pl_stage_json = Database.instance.PlayStageSaveSystem.Load(save_name, GetDefaultData_json(reward_quantity));
        var theData = JsonUtility.FromJson<PlStageData>(pl_stage_json);
        playtime = theData.playtime;
        rewardBoughtInfo = theData.rewardBoughtInfo;
    }

    public void SaveData()
    {
        string theJson = JsonUtility.ToJson(this);
        Database.instance.PlayStageSaveSystem.Save(save_name, theJson);
    }

    string GetDefaultData_json(int reward_quantity)
    {
        playtime = 0;
        rewardBoughtInfo.AddRange(new bool[reward_quantity]);
        Debug.Log(rewardBoughtInfo != null);
        Debug.Log(rewardBoughtInfo[0]);
        return JsonUtility.ToJson(this);
    }
}