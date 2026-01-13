public class BigHandsSkill : PassiveSkill
{
    public override int thisEnumInt => (int)PassiveSkillEnum.BigHands;

    public override void InjectSkill()
    {
        
    }

    public override void ToLV1()
    {
        pasi.playerUpdate.ExpScale *= 1.07f;
    }

    public override void ToLV2()
    {
        pasi.playerUpdate.ExpScale *= 1.14f;
    }

    public override void ToLV3()
    {
        pasi.playerUpdate.ExpScale *= 1.21f;
    }

    public override void ToLV4()
    {
        pasi.playerUpdate.ExpScale *= 1.28f;
    }

    public override void ToLV5()
    {
        pasi.playerUpdate.ExpScale *= 1.35f;
    }
}
