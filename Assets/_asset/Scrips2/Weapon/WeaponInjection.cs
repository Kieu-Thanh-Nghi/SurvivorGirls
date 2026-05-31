using UnityEngine;

public class WeaponInjection : MonoBehaviour
{
    [SerializeField] Transform theWaepon;
    [SerializeField] internal ProjectileEmiter bulletParticleSystem;
    [SerializeField] internal WeaponData weaponData;
    [SerializeField] internal BasicWeapon gunWeapon;

    internal AllWeaponMuzzle allWeaponMuzzle => transform.parent.GetComponentInChildren<AllWeaponMuzzle>();

    public void Start()
    {
        Setup(allWeaponMuzzle);
    }

    public virtual void Setup(AllWeaponMuzzle allWeaponPos)
    {
        //set weapon pos
        theWaepon.SetParent(allWeaponPos.HandR, false);
        gunWeapon.emiter = bulletParticleSystem;
        bulletParticleSystem.SetHasDamageData(weaponData);
    }
}
