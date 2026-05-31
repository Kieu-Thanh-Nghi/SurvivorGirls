using UnityEngine;

public class MeleWeaponInjection : WeaponInjection
{
    [SerializeField] Transform inRotateBody;
    [SerializeField] AtkSystem atkSystem;
    [SerializeField] int animatorLayerIndex = 1;

    public override void Setup(AllWeaponMuzzle allWeaponPos)
    {
        base.Setup(allWeaponPos);
        inRotateBody.SetParent(allWeaponMuzzle.transform);
        atkSystem.animator = allWeaponMuzzle.GetComponent<Animator>();
    }
}