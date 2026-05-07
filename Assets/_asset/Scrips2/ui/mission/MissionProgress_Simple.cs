using UnityEngine;

public class MissionProgress_Simple : MissionProgress
{
    [SerializeField] int neededAmount;
    public override int GetNeedProgressAmount() => neededAmount;
}