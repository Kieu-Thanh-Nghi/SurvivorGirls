using UnityEngine;
public class PassiveSkillInjection : SkillInjection 
{
    [SerializeField] internal PlayerUpdate playerUpdate;
    [SerializeField] internal BasicWeapon weapon;

    protected override void Start()
    {
        if(!(weapon is GunWeapon))
        {
            skillIndex.Remove((int)PassiveSkillEnum.ChangeReload);
        }
        base.Start();
    }
}