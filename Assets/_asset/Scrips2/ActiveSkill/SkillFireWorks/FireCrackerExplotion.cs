using Lean.Pool;
using UnityEngine;

public class FireCrackerExplotion : BurnStatusGiver
{
    public override int BurnData_Damage 
        => Mathf.CeilToInt(burnData_Damage * (1 + PlayerDataManager.Instance.ElementBoost));
    private void OnEnable()
    {
        Invoke(nameof(TurnOffExplode), 0.5f);
    }

    void TurnOffExplode()
    {
        LeanPool.Despawn(gameObject);
    }
}
