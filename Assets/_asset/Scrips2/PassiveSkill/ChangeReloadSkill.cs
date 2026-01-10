public class ChangeReloadSkill : PassiveSkill
{
    public override int thisEnumInt => (int)PassiveSkillEnum.ChangeReload;

    public override void InjectSkill()
    {
        
    }

    public override void ToLV1()
    {
        PlayerParaScale.Instance._reloadTime *= 0.8f;
    }

    public override void ToLV2()
    {
        PlayerParaScale.Instance._reloadTime *= 0.8f;
    }

    public override void ToLV3()
    {
        PlayerParaScale.Instance._reloadTime *= 0.8f;
    }

    public override void ToLV4()
    {
        PlayerParaScale.Instance._reloadTime *= 0.8f;
    }

    public override void ToLV5()
    {
        PlayerParaScale.Instance._reloadTime *= 0.8f;
    }
}
