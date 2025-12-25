using UnityEngine;

public class PistolSkillInjection : MonoBehaviour
{
    [SerializeField] ProjectileEmiter bulletParticleSystem;
    [SerializeField] ExplodeParticleProjectile exlodeBulletParticleSystem;
    [SerializeField] ExplotionEff explodeEff;
    [SerializeField] PlayerGunAtkSystem playerGunAtkSystem;
    [SerializeField] NearestObjectSphereDetecter nearestObjectSphereDetecter;
    [SerializeField] GunWeapon gunWeapon;
    [SerializeField] int neededEnemies, neededShots, TimesToShoot;
    [SerializeField] WeaponData pistolData;
    internal PistolSkill_Training pistolSkill_Training;
    internal PistolSkill_SixthSense pistolSkill_SixthSense;
    internal PistolSkill_Magnum pistolSkill_Magnum;
    [SerializeField] internal Transform pistolMuzzle;

    private void Start()
    {
        WeaponSetUp(transform.parent.GetComponentInChildren<AllWeaponMuzzle>());
        InjectFirstSkill();
        InjectSecondSkill();
        InjectThirdSkill();
    }

    [ContextMenu("PistolSetup")]
    void test()
    {
        WeaponSetUp(transform.parent.GetComponentInChildren<AllWeaponMuzzle>());
        InjectFirstSkill();
        InjectSecondSkill();
        InjectThirdSkill();
    }
    public void WeaponSetUp(AllWeaponMuzzle weaponMuzzles)
    {
        pistolMuzzle = weaponMuzzles.PistolMuzzle;
        var emiter = Instantiate(bulletParticleSystem, pistolMuzzle);
        gunWeapon.emiter = emiter;
        emiter.SetHasDamageData(pistolData);
    }
    [ContextMenu("First")]
    public void InjectFirstSkill()
    {
        pistolSkill_Training = gameObject.AddComponent<PistolSkill_Training>();
        pistolSkill_Training.SetUp(gunWeapon, nearestObjectSphereDetecter,
            playerGunAtkSystem, playerGunAtkSystem);

        pistolSkill_Training.TimesToShoot = TimesToShoot;
    }

    [ContextMenu("Second")]
    public void InjectSecondSkill()
    {
        IEachAtkObserver[] eachAtkObservers = { playerGunAtkSystem, pistolSkill_Training };
        pistolSkill_SixthSense = gameObject.AddComponent<PistolSkill_SixthSense>();
        pistolSkill_SixthSense.SetUp(eachAtkObservers, 
            nearestObjectSphereDetecter, gunWeapon);

        pistolSkill_SixthSense.neededEnemies = neededEnemies;
        pistolSkill_SixthSense.neededShots = neededShots;
    }

    [ContextMenu("3skill")]
    public void InjectThirdSkill()
    {
        pistolSkill_Magnum = gameObject.AddComponent<PistolSkill_Magnum>();
        var explodeEmiter = Instantiate(exlodeBulletParticleSystem, pistolMuzzle);
        pistolSkill_Magnum.emiter = explodeEmiter;
        explodeEmiter.SetHasDamageData(pistolData);
        var exploEff = Instantiate(explodeEff);
        explodeEmiter.explodeEff = exploEff;
        pistolSkill_Magnum.explotionEff = exploEff;
        pistolSkill_SixthSense.weapon = pistolSkill_Magnum;
    }
}
