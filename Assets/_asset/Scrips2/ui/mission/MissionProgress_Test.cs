using UnityEngine;

public class MissionProgress_Test : MissionProgress
{
    [SerializeField] int neededAmount;
    [SerializeField] int currentAmount;
    public override int GetNeedProgressAmount()
    {
        return neededAmount;
    }

    public override void RefreshProgress()
    {
        Debug.Log(GetHavingProgressAmount());
        base.RefreshProgress();
        Debug.Log(GetHavingProgressAmount());
    }
    protected override void UpdateMission()
    {
        Debug.Log("update test");
        ProgressAmount = currentAmount;
    }
}