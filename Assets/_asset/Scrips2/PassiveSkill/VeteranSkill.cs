public class VeteranSkill : PassiveSkill
{
    public override int thisEnumInt => (int)PassiveSkillEnum.Veteran;

    public override void InjectSkill()
    {
        
    }

    public override void ToLV1()
    {
        PlayerParaScale.Instance._gotExp *= 1.05f;
    }

    public override void ToLV2()
    {
        PlayerParaScale.Instance._gotExp *= 1.2f;
    }

    public override void ToLV3()
    {
        PlayerParaScale.Instance._gotExp *= 1.12f;
    }

    public override void ToLV4()
    {
        PlayerParaScale.Instance._gotExp *= 1.27f;
    }

    public override void ToLV5()
    {
        PlayerParaScale.Instance._gotExp *= 1.35f;
    }
}
