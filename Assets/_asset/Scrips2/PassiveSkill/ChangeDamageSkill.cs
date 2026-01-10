public class ChangeDamageSkill : PassiveSkill
{
    public override int thisEnumInt => (int)PassiveSkillEnum.ChangeDamage;

    public override void InjectSkill()
    {
        
    }

    public override void ToLV1()
    {
        PlayerParaScale.Instance._damage *= 1.2f;
    }

    public override void ToLV2()
    {
        PlayerParaScale.Instance._damage *= 1.2f;
    }

    public override void ToLV3()
    {
        PlayerParaScale.Instance._damage *= 1.2f;
    }

    public override void ToLV4()
    {
        PlayerParaScale.Instance._damage *= 1.2f;
    }

    public override void ToLV5()
    {
        PlayerParaScale.Instance._damage *= 1.2f;
    }
}
