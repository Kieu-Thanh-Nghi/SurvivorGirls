public class GunMasterSkill : PassiveSkill
{
    public override int thisEnumInt => (int)PassiveSkillEnum.GunMaster;

    public override void InjectSkill()
    {
        
    }

    public override void ToLV1()
    {
        PlayerParaScale.Instance._reloadPadding -= 0.2f;
    }

    public override void ToLV2()
    {
        PlayerParaScale.Instance._reloadPadding -= 0.4f;
    }

    public override void ToLV3()
    {
        PlayerParaScale.Instance._reloadPadding -= 0.6f;
    }

    public override void ToLV4()
    {
        PlayerParaScale.Instance._reloadPadding -= 0.9f;
    }

    public override void ToLV5()
    {
        PlayerParaScale.Instance._reloadPadding -= 1.2f;
    }
}
