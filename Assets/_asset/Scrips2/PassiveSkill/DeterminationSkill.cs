public class DeterminationSkill : PassiveSkill
{
    public override int thisEnumInt => (int)PassiveSkillEnum.Determination;

    public override void InjectSkill()
    {
        
    }

    public override void ToLV1()
    {
        PlayerDataManager.Instance._damageScale *= 1.05f;
    }

    public override void ToLV2()
    {
        PlayerDataManager.Instance._damageScale *= 1.07f;
    }

    public override void ToLV3()
    {
        PlayerDataManager.Instance._damageScale *= 1.1f;
    }

    public override void ToLV4()
    {
        PlayerDataManager.Instance._damageScale *= 1.15f;
    }

    public override void ToLV5()
    {
        PlayerDataManager.Instance._damageScale *= 1.2f;
    }
}
