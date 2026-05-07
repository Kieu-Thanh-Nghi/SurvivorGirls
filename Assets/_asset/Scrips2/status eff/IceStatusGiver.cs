using UnityEngine;

public class IceStatusGiver : StatusGiver<IceEff>
{
    protected override StatusType statusType => StatusType.Frozen;

    [SerializeField] internal float iceData_TotalTime;

    public virtual float IceData_TotalTime => iceData_TotalTime;

    protected override void EffSetting(IceEff iceEff)
    {
        iceEff.SetEffData(IceData_TotalTime);
    }
}