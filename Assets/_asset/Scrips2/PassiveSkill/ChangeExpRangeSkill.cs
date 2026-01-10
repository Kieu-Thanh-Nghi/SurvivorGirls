public class ChangeExpRangeSkill : PassiveSkill
{
    public override int thisEnumInt => (int)PassiveSkillEnum.ChangeExpRange;

    public override void InjectSkill()
    {
        
    }

    public override void ToLV1()
    {
        pasi.playerUpdate.ExpScale *= 1.2f;
    }

    public override void ToLV2()
    {
        pasi.playerUpdate.ExpScale *= 1.2f;
    }

    public override void ToLV3()
    {
        pasi.playerUpdate.ExpScale *= 1.2f;
    }

    public override void ToLV4()
    {
        pasi.playerUpdate.ExpScale *= 1.2f;
    }

    public override void ToLV5()
    {
        pasi.playerUpdate.ExpScale *= 1.2f;
    }
}
