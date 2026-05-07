using System.Collections.Generic;
using UnityEngine;

public class PistolSkillInjection : WeaponInjection
{
    [SerializeField] internal ProjectileEmiter bulletParticleSystem;
    [SerializeField] internal ExplodeParticleProjectile exlodeBulletParticleSystem;
    [SerializeField] internal ExplotionEff explodeEff;
    [SerializeField] internal PlayerGunAtkSystem playerGunAtkSystem;
    [SerializeField] internal NearestObjectSphereDetecter nearestObjectSphereDetecter;
    [SerializeField] internal GunWeapon gunWeapon;
    [SerializeField] int neededEnemies, neededShots, TimesToShoot;
    
    internal PistolSkill_Training pistolSkill_Training;
    internal PistolSkill_SixthSense pistolSkill_SixthSense;
    internal PistolSkill_Magnum pistolSkill_Magnum;
    [SerializeField] internal Transform pistolMuzzle;

    //internal PistolFirstSkill firstSkill;
    //internal PistolSecondSkill secondSkill;
    internal PistolThirdSkill thirdSkill;
    List<int> tempList = new();

    protected override void Start()
    {
        WeaponSetUp(transform.parent.GetComponentInChildren<AllWeaponMuzzle>());
        base.Start();
        thirdSkill = skillList[(int)PistolSkillEnum.Magnum] as PistolThirdSkill;
    }

    protected override int CalculateChosenSkill(int n, List<int> theList, out int skillLvl)
    {
        thirdSkill = skillList[(int)PistolSkillEnum.Magnum] as PistolThirdSkill;
        tempList.Clear();
        tempList.AddRange(theList);
        if (!thirdSkill.CheckIfOK(this))
        {
            tempList.Remove((int)PistolSkillEnum.Magnum);
        }
        return base.CalculateChosenSkill(tempList.Count, tempList, out skillLvl);
    }

    [ContextMenu("inject skill1")]
    void test1()
    {
        UpgradeASkill((int)PistolSkillEnum.Training);
    }
    [ContextMenu("inject skill2")]
    void test2()
    {
        UpgradeASkill((int)PistolSkillEnum.SixthSense);
    }
    [ContextMenu("inject skill3")]
    void test3()
    {
        UpgradeASkill((int)PistolSkillEnum.Magnum);
    }
    public override void WeaponSetUp(AllWeaponMuzzle weaponMuzzles)
    {
        pistolMuzzle = weaponMuzzles.PistolMuzzle;
        var emiter = Instantiate(bulletParticleSystem, pistolMuzzle);
        pistolMuzzle.parent.gameObject.SetActive(true);
        gunWeapon.emiter = emiter;
        emiter.SetHasDamageData(weaponData);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        //pistolMuzzle?.parent.gameObject.SetActive(false);
    }
    //[ContextMenu("First")]
    //public void InjectFirstSkill()
    //{
    //    //step1: add
    //    pistolSkill_Training = gameObject.AddComponent<PistolSkill_Training>();

    //    //step2: setup
    //    pistolSkill_Training.SetUp(gunWeapon, nearestObjectSphereDetecter,
    //        playerGunAtkSystem, playerGunAtkSystem);

    //    //step3: data config
    //    pistolSkill_Training.TimesToShoot = TimesToShoot;
    //}

    //[ContextMenu("Second")]
    //public void InjectSecondSkill()
    //{
    //    IEachAtkObserver[] eachAtkObservers = { playerGunAtkSystem, pistolSkill_Training };
    //    //step1: add
    //    pistolSkill_SixthSense = gameObject.AddComponent<PistolSkill_SixthSense>();

    //    //step2: setup
    //    pistolSkill_SixthSense.SetUp(nearestObjectSphereDetecter, gunWeapon);

    //    //step3: data config
    //    pistolSkill_SixthSense.neededEnemies = neededEnemies;
    //    pistolSkill_SixthSense.neededShots = neededShots;
    //}

    //[ContextMenu("3skill")]
    //public void InjectThirdSkill()
    //{
    //    pistolSkill_Magnum = gameObject.AddComponent<PistolSkill_Magnum>();
    //    var explodeEmiter = Instantiate(exlodeBulletParticleSystem, pistolMuzzle);
    //    pistolSkill_Magnum.emiter = explodeEmiter;
    //    explodeEmiter.SetHasDamageData(pistolData);
    //    var exploEff = Instantiate(explodeEff);
    //    explodeEmiter.explodeEff = exploEff;
    //    pistolSkill_Magnum.explotionEff = exploEff;
    //    pistolSkill_SixthSense.weapon = pistolSkill_Magnum;
    //}
}

public enum PassiveSkillEnum
{
    NoneSkill = -1,
    //
    Alacrity = 0,
    BigHands = 1,
    Controller = 2,
    Determination = 3,
    Veteran = 4,
    GunMaster = 5,
    HealingFactor = 6
}

public enum ActiveSkillEnum
{
    NoneSkill = -1,
    BladeDrone = 0,
    ScifiDrone = 1,
    TentaclesRobot = 2,
    ElectricMines = 3,
    FireWorksSkill = 4,
    ThunderBolts = 5,
    FrozeDrone = 6,
    PlasmaShield = 7
}

public enum PistolSkillEnum
{
    NoneSkill = -1,
    //
    Training = 0,
    SixthSense = 1,
    Magnum = 2,
}

public interface ISkillInjection { }
