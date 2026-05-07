using UnityEngine;

public class FireWorkBurnEff : PlayerBurnEff
{
    [SerializeField] ActiveSkill_FireWorks skill_FireWorks;
}

public class PlayerBurnEff : BurnEff
{
    internal override float TotalTime 
        => base.TotalTime * (1 + PlayerDataManager.Instance.ElementBoost);
    internal override int Damage 
        => Mathf.CeilToInt(base.Damage * PlayerDataManager.Instance.ElementBoost);
}