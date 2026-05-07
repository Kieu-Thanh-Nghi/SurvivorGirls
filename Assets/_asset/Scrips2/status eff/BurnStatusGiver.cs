using UnityEngine;

public class BurnStatusGiver : StatusGiver<BurnEff>
{
    [SerializeField] protected float burnData_TotalTime;
    [SerializeField] protected int burnData_Damage;

    public virtual float BurnData_TotalTime
    {
        get => burnData_TotalTime;
        set => burnData_TotalTime = value;
    }
    public virtual int BurnData_Damage
    {
        get => burnData_Damage;
        set => burnData_Damage = value;
    }
    protected override StatusType statusType => StatusType.Burn;

    protected override void EffSetting(BurnEff burnEff)
    {
        burnEff.SetEffData(BurnData_TotalTime, BurnData_Damage);
    }
}
