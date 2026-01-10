public class ChangeGotExpSkill : PassiveSkill
{
    public override int thisEnumInt => (int)PassiveSkillEnum.ChangeGotExp;

    public override void InjectSkill()
    {
        
    }

    public override void ToLV1()
    {
        PlayerParaScale.Instance._gotExp *= 1.2f;
    }

    public override void ToLV2()
    {
        PlayerParaScale.Instance._gotExp *= 1.2f;
    }

    public override void ToLV3()
    {
        PlayerParaScale.Instance._gotExp *= 1.2f;
    }

    public override void ToLV4()
    {
        PlayerParaScale.Instance._gotExp *= 1.2f;
    }

    public override void ToLV5()
    {
        PlayerParaScale.Instance._gotExp *= 1.2f;
    }
}
