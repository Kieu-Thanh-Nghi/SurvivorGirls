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
    [SerializeField] internal WeaponData weaponData;
    internal PistolSkill_Training pistolSkill_Training;
    internal PistolSkill_SixthSense pistolSkill_SixthSense;
    internal PistolSkill_Magnum pistolSkill_Magnum;
    [SerializeField] internal Transform pistolMuzzle;

    //internal PistolFirstSkill firstSkill;
    //internal PistolSecondSkill secondSkill;
    internal PistolThirdSkill thirdSkill;

    protected override void Start()
    {
        WeaponSetUp(transform.parent.GetComponentInChildren<AllWeaponMuzzle>());
        base.Start();
        thirdSkill = skillList[(int)PistolSkillEnum.Magnum] as PistolThirdSkill;
    }

    protected override int CalculateChosenSkill(int n, List<int> theList, out int skillLvl)
    {
        thirdSkill = skillList[(int)PistolSkillEnum.Magnum] as PistolThirdSkill;
        if (!thirdSkill.CheckIfOK(this))
        {
            int i = theList.IndexOf((int)PistolSkillEnum.Magnum);
            Debug.Log(i);
            Swap(i, n - 1, theList);
            n--;
        }
        return base.CalculateChosenSkill(n, theList, out skillLvl);
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
    public void WeaponSetUp(AllWeaponMuzzle weaponMuzzles)
    {
        pistolMuzzle = weaponMuzzles.PistolMuzzle;
        var emiter = Instantiate(bulletParticleSystem, pistolMuzzle);
        gunWeapon.emiter = emiter;
        emiter.SetHasDamageData(weaponData);
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

public class WeaponInjection : SkillInjection
{

}

public enum SkillEnum
{
    NoneSkill = -1,
    //
    Training = 0,
    SixthSense = 1,
    Magnum = 2,
    //
    BladeDrone = 0,
    ScifiDrone = 1,
}

public enum ActiveSkillEnum
{
    NoneSkill = -1,
    BladeDrone = 0,
    ScifiDrone = 1,
    TentaclesRobot = 2,
    ElectricMines = 3,
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

public class SkillInjection : MonoBehaviour, ISkillInjection
{
    [SerializeField] int skillQuantity;
    [SerializeField] internal List<Skill> skillList;
    [SerializeField] protected List<int> skillIndex;
    protected List<int> usingSkill = new List<int>(4);
    protected int resultEnum;
    int fullLvlSkillCount;
    int usedSkillCount;
    internal int selectedTimes;

#if UNITY_EDITOR
    [SerializeField] protected bool isValidate;
    protected void OnValidate()
    {
        if (!isValidate) return;
        skillIndex.Clear();
        skillList.Sort((x, y) => (x.thisEnumInt).CompareTo(y.thisEnumInt));
        int last = skillList[skillList.Count - 1].thisEnumInt;

        var tempList = new List<Skill>(last + 1);
        foreach (var aSkill in skillList)
        {
            tempList.Insert(aSkill.thisEnumInt, aSkill);
        }
        skillList = tempList;

        foreach (var aSkill in skillList)
        {
            if(aSkill != null) skillIndex.Add(aSkill.thisEnumInt);
        }
    }

    [ContextMenu("ResetLvls")]
    public virtual void ResetLvl()
    {
        foreach (var skillEnum in usingSkill)
        {
            skillList[skillEnum].currentLV = 0;
        }
    }
#endif

    protected virtual void Start()
    {
        fullLvlSkillCount = 0;
        usedSkillCount = 0;
        //thirdSkill = new PistolThirdSkill();

        //InjectFirstSkill();
        //InjectSecondSkill();
        //InjectThirdSkill();
    }

    public void ResetToNew()
    {
        skillIndex.Clear();
        foreach (var aSkill in skillList)
        {
            if (aSkill != null) skillIndex.Add(aSkill.thisEnumInt);
        }
        foreach(var e in usingSkill)
        {
            skillList[e].currentLV = 0;
        }
        usingSkill.Clear();
        fullLvlSkillCount = 0;
        usedSkillCount = 0;
        selectedTimes = 0;
    }

    public virtual int ChoseSkill(out int skillLvl)
    {
        if(fullLvlSkillCount >= skillQuantity)
        {
            skillLvl = -1;
            return -1;
        }
        var theList = PickList();
        int n = theList.Count;
        return CalculateChosenSkill(n, theList, out skillLvl);
    }

    protected virtual int CalculateChosenSkill(int n, List<int> theList, out int skillLvl)
    {
        if (n <= selectedTimes)
        {
            skillLvl = -1;
            return -1;
        }
        int lastIndex = n - selectedTimes;
        int i = Random.Range(0, lastIndex);
        resultEnum = theList[i];
        Swap(i, lastIndex - 1, theList);
        selectedTimes++;
        skillLvl = skillList[resultEnum].currentLV;
        return resultEnum;
    }

    protected void Swap(int a, int b, List<int> theList)
    {
        if (a >= b) return;
        var temp = theList[a];
        theList[a] = theList[b];
        theList[b] = temp;
    }
    List<int> PickList()
    {
        if (usedSkillCount >= skillQuantity)
        {
            Debug.Log("a");
            return usingSkill;
        }
        else
        {
            Debug.Log("b");
            return skillIndex;
        }
    }

    protected virtual void OnDestroy()
    {
        ResetLvl();
    }
    public virtual void UpgradeASkill(int skillEnum)
    {
        var result = skillList[skillEnum];
        if (result.currentLV == 0)
        {
            result.SetSkillInjection(this);
            usingSkill.Add(resultEnum); 
            usedSkillCount++;
        }
        if (result.UpgradeSkill())
        {
            usingSkill.Remove(resultEnum);
            skillIndex.Remove(resultEnum);
            result.currentLV = 0;
            fullLvlSkillCount++;
        }
    }
}
