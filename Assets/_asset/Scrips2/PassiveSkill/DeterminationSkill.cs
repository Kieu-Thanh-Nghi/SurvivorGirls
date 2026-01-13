public class DeterminationSkill : PassiveSkill
{
    public override int thisEnumInt => (int)PassiveSkillEnum.Determination;

    public override void InjectSkill()
    {
        
    }

    public override void ToLV1()
    {
        PlayerParaScale.Instance._damage *= 1.05f;
    }

    public override void ToLV2()
    {
        PlayerParaScale.Instance._damage *= 1.07f;
    }

    public override void ToLV3()
    {
        PlayerParaScale.Instance._damage *= 1.1f;
    }

    public override void ToLV4()
    {
        PlayerParaScale.Instance._damage *= 1.15f;
    }

    public override void ToLV5()
    {
        PlayerParaScale.Instance._damage *= 1.2f;
    }
}
