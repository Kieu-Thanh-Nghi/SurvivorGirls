public class VeteranSkill : PassiveSkill
{
    public override int thisEnumInt => (int)PassiveSkillEnum.Veteran;

    public override void InjectSkill()
    {
        
    }

    public override void ToLV1()
    {
        PlayerDataManager.Instance._gotExpScale *= 1.05f;
    }

    public override void ToLV2()
    {
        PlayerDataManager.Instance._gotExpScale *= 1.2f;
    }

    public override void ToLV3()
    {
        PlayerDataManager.Instance._gotExpScale *= 1.12f;
    }

    public override void ToLV4()
    {
        PlayerDataManager.Instance._gotExpScale *= 1.27f;
    }

    public override void ToLV5()
    {
        PlayerDataManager.Instance._gotExpScale *= 1.35f;
    }
}
