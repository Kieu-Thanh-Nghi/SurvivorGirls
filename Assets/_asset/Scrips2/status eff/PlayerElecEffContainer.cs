using UnityEngine;

public class PlayerElecEffContainer : ElectricEffContainer
{
    protected override void FilterEff()
    {
        currentEffect.damage = Mathf.CeilToInt(currentEffect.damage * (1 - PlayerDataManager.Instance.ElementReg));
        currentEffect.speedDecreaseAmount =
            currentEffect.speedDecreaseAmount * (1 - PlayerDataManager.Instance.ElementReg);
    }
}
