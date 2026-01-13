using UnityEngine;
public class PassiveSkillInjection : SkillInjection 
{
    [SerializeField] internal PlayerUpdate playerUpdate;
    [SerializeField] internal BasicWeapon weapon;
    [SerializeField] internal Health health;

    protected override void Start()
    {
        if(!(weapon is GunWeapon))
        {
            skillIndex.Remove((int)PassiveSkillEnum.GunMaster);
        }
        base.Start();
    }

    public void HealTest()
    {
        UpgradeASkill((int)PassiveSkillEnum.HealingFactor);
    }
}
