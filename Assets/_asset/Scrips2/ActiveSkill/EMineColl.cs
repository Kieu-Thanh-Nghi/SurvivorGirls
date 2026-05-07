using UnityEngine;
using Lean.Pool;

public class EMineColl : ElectStatusGiver
{
    internal override int Damage
         => Mathf.CeilToInt(damage * (1 + PlayerDataManager.Instance.ElementBoost));
    internal override float SpeedDecreaseAmount
        => speedDecreaseAmount * (1 + PlayerDataManager.Instance.ElementBoost);
    protected override void EffSetting(ElectricEff elecEff)
    {
        base.EffSetting(elecEff);
        elecEff.transform.forward = Vector3.up;
        elecEff.SetInfinite(true);
    }
    private void OnTriggerExit(Collider other)
    {
        var effFilter = other.GetComponent<IEffFilter>();
        var ElecEff = effFilter.GetCurrentEffect(StatusType.Electric);
        if (ElecEff != null)
        {
            ElecEff.SetInfinite(false);
        }
    }
}
