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
        thirdSkill = skillList[(int)SkillEnum.Magnum] as PistolThirdSkill;
    }

    protected override SkillEnum CalculateChosenSkill(int n, List<SkillEnum> theList, out int skillLvl)
    {
        if (!thirdSkill.CheckIfOK())
        {
            int i = theList.IndexOf(SkillEnum.Magnum);
            Swap(i, n, theList);
            n--;
        }
        return base.CalculateChosenSkill(n, theList, out skillLvl);
    }

    [ContextMenu("inject skill1")]
    void test1()
    {
        UpgradeASkill(SkillEnum.Training);
    }
    [ContextMenu("inject skill2")]
    void test2()
    {
        UpgradeASkill(SkillEnum.SixthSense);
    }
    [ContextMenu("inject skill3")]
    void test3()
    {
        UpgradeASkill(SkillEnum.Magnum);
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

public interface ISkillInjection { }

public abstract class SkillContainer : ScriptableObject
{
    bool isInitialize;
    internal Skill theSkill;
    internal abstract SkillEnum skillEnum { get; }

    public abstract void initializeSkill();
}

public class PistolFirstSkillContainer : SkillContainer
{
    internal override SkillEnum skillEnum => SkillEnum.Training;

    public override void initializeSkill()
    {
        theSkill = new PistolFirstSkill();
    }
}

public class SkillInjection : MonoBehaviour, ISkillInjection
{
    [SerializeField] int skillQuantity;
    [SerializeField] internal List<Skill> skillList;
    [SerializeField] protected List<SkillEnum> skillIndex;
    protected List<SkillEnum> usingSkill = new List<SkillEnum>(4);
    protected SkillEnum resultEnum;
    int fullLvlSkillCount;
    int usedSkillCount;
    internal int selectedTimes;

#if UNITY_EDITOR
    [SerializeField] protected bool isValidate;
    protected void OnValidate()
    {
        if (!isValidate) return;
        skillIndex.Clear();
        skillList.Sort((x, y) => ((int)x.thisEnum).CompareTo((int)y.thisEnum));
        int last = (int)skillList[skillList.Count - 1].thisEnum;

        var tempList = new List<Skill>(last + 1);
        foreach (var aSkill in skillList)
        {
            tempList.Insert((int)aSkill.thisEnum, aSkill);
        }
        skillList = tempList;

        foreach (var aSkill in skillList)
        {
            if(aSkill != null) skillIndex.Add(aSkill.thisEnum);
        }
    }

    [ContextMenu("ResetLvls")]
    public virtual void ResetLvl()
    {
        foreach (var skillEnum in usingSkill)
        {
            skillList[(int)skillEnum].currentLV = 0;
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
            if (aSkill != null) skillIndex.Add(aSkill.thisEnum);
        }
        foreach(var e in usingSkill)
        {
            skillList[(int)e].currentLV = 0;
        }
        usingSkill.Clear();
        fullLvlSkillCount = 0;
        usedSkillCount = 0;
        selectedTimes = 0;
    }

    public virtual SkillEnum ChoseSkill(out int skillLvl)
    {
        if(fullLvlSkillCount >= skillQuantity)
        {
            skillLvl = -1;
            return SkillEnum.NoneSkill;
        }
        var theList = PickList();
        int n = theList.Count;
        return CalculateChosenSkill(n, theList, out skillLvl);
    }

    protected virtual SkillEnum CalculateChosenSkill(int n, List<SkillEnum> theList, out int skillLvl)
    {
        if (n <= selectedTimes)
        {
            skillLvl = -1;
            return SkillEnum.NoneSkill;
        }
        int lastIndex = n - selectedTimes;
        int i = Random.Range(0, lastIndex);
        resultEnum = theList[i];
        Swap(i, lastIndex, theList);
        selectedTimes++;
        skillLvl = skillList[(int)resultEnum].currentLV;
        return resultEnum;
    }

    protected void Swap(int a, int b, List<SkillEnum> theList)
    {
        if (a >= b) return;
        var temp = theList[a];
        theList[a] = theList[b];
        theList[b] = temp;
    }
    List<SkillEnum> PickList()
    {
        if (usedSkillCount >= skillQuantity)
        {
            return usingSkill;
        }
        else
        {
            return skillIndex;
        }
    }

    protected virtual void OnDestroy()
    {
        ResetLvl();
    }
    public virtual void UpgradeASkill(SkillEnum skillEnum)
    {
        var result = skillList[(int)skillEnum];
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
public class PassiveSkillInjection : SkillInjection { }