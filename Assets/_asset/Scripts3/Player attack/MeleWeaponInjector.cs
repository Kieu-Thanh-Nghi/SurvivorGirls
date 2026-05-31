using UnityEngine;

public class MeleWeaponInjector : WeaponInjecter
{
    [SerializeField] Transform inRotateBody;
    [SerializeField] int animatorLayerIndex = 1;
    [SerializeField] protected float atkCooldown;
    internal AtkSystemByAnim atkSystem;

    public override void Setup(AllWeaponMuzzle allWeaponPos)
    {
        base.Setup(allWeaponPos);
        inRotateBody.SetParent(allWeaponMuzzle.transform);
        atkSystem = allWeaponMuzzle.GetComponent<AtkSystemByAnim>();
        atkSystem.SetlayerWeight(animatorLayerIndex, 1f, playerAttack);
        atkSystem.AttackCountdown = atkCooldown;
    }
}
