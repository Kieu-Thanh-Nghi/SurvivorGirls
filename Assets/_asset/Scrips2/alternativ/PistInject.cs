using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistInject : MonoBehaviour
{
    PistolFirstSkill firstSkill;
    PistolSecondSkill secondSkill;
    PistolThirdSkill thirdSkill;
}

public abstract class PistolSkill : Skill
{
    protected PistolSkillInjection psi;
    public override void SetSkillInjection(ISkillInjection skillInjection)
    {
        if (skillInjection is PistolSkillInjection thePsi)
        {
            psi = thePsi;
        }
    }
}

public abstract class ActiveSkill : Skill
{
    protected ActiveSkillInjection asi;

    public override void SetSkillInjection(ISkillInjection skillInjection)
    {
        if (skillInjection is ActiveSkillInjection theAsi)
        {
            asi = theAsi;
        }
    }
}
public abstract class Skill : MonoBehaviour
{
    [SerializeField] internal int currentLV = 0;
    protected int maxLvl = 5;

    public abstract int thisEnumInt { get; }
    public abstract void SetSkillInjection(ISkillInjection skillInjection);

    public abstract void InjectSkill();

    public virtual bool UpgradeSkill()
    {
        if (currentLV >= maxLvl) return true;
        switch (currentLV)
        {
            case 0:
                InjectSkill();
                ToLV1();
                currentLV++;
                break;
            case 1:
                ToLV2();
                currentLV++;
                break;
            case 2:
                ToLV3();
                currentLV++;
                break;
            case 3:
                ToLV4();
                currentLV++;
                break;
            case 4:
                ToLV5();
                currentLV++;
                break;
        }
        currentLV++;
        return false;
    }

    public abstract void ToLV1();
    public abstract void ToLV2();
    public abstract void ToLV3();
    public abstract void ToLV4();
    public abstract void ToLV5();
}