public class ControllerSkill : PassiveSkill
{
    public override int thisEnumInt => (int)PassiveSkillEnum.Controller;

    public override void InjectSkill()
    {
        
    }

    public override void ToLV1()
    {
        PlayerDataManager.Instance._ASCoolDownScale *= 0.9f;
    }

    public override void ToLV2()
    {
        PlayerDataManager.Instance._ASCoolDownScale *= 0.8f;
    }

    public override void ToLV3()
    {
        PlayerDataManager.Instance._ASCoolDownScale *= 0.7f;
    }

    public override void ToLV4()
    {
        PlayerDataManager.Instance._ASCoolDownScale *= 0.6f;
    }

    public override void ToLV5()
    {
        PlayerDataManager.Instance._ASCoolDownScale *= 0.45f;
    }
}
