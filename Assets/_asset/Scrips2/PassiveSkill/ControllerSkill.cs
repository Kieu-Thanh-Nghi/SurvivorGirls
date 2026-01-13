public class ControllerSkill : PassiveSkill
{
    public override int thisEnumInt => (int)PassiveSkillEnum.Controller;

    public override void InjectSkill()
    {
        
    }

    public override void ToLV1()
    {
        PlayerParaScale.Instance._coolDown *= 0.9f;
    }

    public override void ToLV2()
    {
        PlayerParaScale.Instance._coolDown *= 0.8f;
    }

    public override void ToLV3()
    {
        PlayerParaScale.Instance._coolDown *= 0.7f;
    }

    public override void ToLV4()
    {
        PlayerParaScale.Instance._coolDown *= 0.6f;
    }

    public override void ToLV5()
    {
        PlayerParaScale.Instance._coolDown *= 0.45f;
    }
}
