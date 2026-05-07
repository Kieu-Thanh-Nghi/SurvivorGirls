using UnityEngine;

public class PlayerBurnEffContainer : BurnEffContainer
{
    protected override void FilterEff()
    {
        currentEffect.damage = Mathf.CeilToInt(currentEffect.damage * (1 - PlayerDataManager.Instance.ElementReg));
    }
}