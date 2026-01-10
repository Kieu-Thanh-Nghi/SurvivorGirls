using UnityEngine;

public class ActiveSkillInjection : SkillInjection
{
    [SerializeField] internal Transform Player;
    [SerializeField] internal PlayerActiveSkillsSystem playerActiveSkillsSystem;
    [SerializeField] internal WeaponInjection weaponInjection;
    internal int weaponDamage => weaponInjection.weaponData.GetDamage();

    [ContextMenu("testBD")]
    void testBD()
    {
        UpgradeASkill((int)ActiveSkillEnum.BladeDrone);
    }
    [ContextMenu("testSD")]
    void testSD()
    {
        UpgradeASkill((int)ActiveSkillEnum.ScifiDrone);
    }
    [ContextMenu("aggro")]
    void testAggro()
    {
        UpgradeASkill((int)ActiveSkillEnum.TentaclesRobot);
    }    
    
    [ContextMenu("mines")]
    void testMines()
    {
        UpgradeASkill((int)ActiveSkillEnum.ElectricMines);
    }    
    
    [ContextMenu("fireWorks")]
    void testFireWorks()
    {
        UpgradeASkill((int)ActiveSkillEnum.FireWorksSkill);
    }
    [ContextMenu("ThunderBolts")]
    void testThunderBolts()
    {
        UpgradeASkill((int)ActiveSkillEnum.ThunderBolts);
    }
    [ContextMenu("frozenDrone")]
    public void testfrozenDrone()
    {
        UpgradeASkill((int)ActiveSkillEnum.FrozeDrone);
    }
    public void testPlasmaShield()
    {
        UpgradeASkill((int)ActiveSkillEnum.PlasmaShield);
    }
}
