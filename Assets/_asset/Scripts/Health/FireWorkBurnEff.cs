using UnityEngine;

public class FireWorkBurnEff : BurnEff
{
    [SerializeField] ActiveSkill_FireWorks skill_FireWorks;

    private void Awake()
    {
        hasDamage = skill_FireWorks;
    }
}

