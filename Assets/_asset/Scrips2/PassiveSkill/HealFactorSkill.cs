using UnityEngine;

public class HealFactorSkill : PassiveSkill
{
    [SerializeField] PassiveSkill_HealingFactor healingFactorPrefab;
    [SerializeField] float healCoolDown = 10;
    PassiveSkill_HealingFactor healingFactor;
    public override int thisEnumInt => (int)PassiveSkillEnum.HealingFactor;

    public override void InjectSkill()
    {
        healingFactor = Instantiate(healingFactorPrefab, pasi.transform);
        healingFactor.health = pasi.health;
    }

    public override void ToLV1()
    {
        PlayerHeal(0.01f);
        healingFactor.coolDown = healCoolDown;
    }

    public override void ToLV2()
    {
        PlayerHeal(0.02f);
    }

    public override void ToLV3()
    {
        PlayerHeal(0.03f);
    }

    public override void ToLV4()
    {
        PlayerHeal(0.04f);
    }

    public override void ToLV5()
    {
        PlayerHeal(0.05f);
    }

    void PlayerHeal(float percent)
    {
        healingFactor.healAmount = Mathf.CeilToInt(pasi.health.maxHP * percent);
    }
}
