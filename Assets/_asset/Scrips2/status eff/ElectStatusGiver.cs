using UnityEngine;

public class ElectStatusGiver : StatusGiver<ElectricEff>
{
    protected override StatusType statusType => StatusType.Electric;

    [SerializeField] internal float elecData_TotalTime;
    [SerializeField] internal int damage = 1;
    [SerializeField] internal float speedDecreaseAmount = 0.5f;

    public virtual float ElecData_TotalTime => elecData_TotalTime;
    internal virtual int Damage => damage;
    internal virtual float SpeedDecreaseAmount => speedDecreaseAmount;


    protected override void EffSetting(ElectricEff ElecEff)
    {
        ElecEff.SetEffData(ElecData_TotalTime, Damage, SpeedDecreaseAmount);
    }
}