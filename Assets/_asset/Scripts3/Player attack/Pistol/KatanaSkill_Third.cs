public class KatanaSkill_Third : KatanaSkill
{
    public override int thisEnumInt => (int)KatanaSkillEnum.Deflect;

    public override void InjectSkill()
    {
        katanaSI.RootSlash.IsDeflect = true;
    }

    public override void ToLV1()
    {
        katanaSI.RootSlash.DeflectTimes = 1;
    }

    public override void ToLV2()
    {
        katanaSI.RootSlash.DeflectTimes = 2;
    }

    public override void ToLV3()
    {
        katanaSI.RootSlash.DeflectTimes = 3;
    }

    public override void ToLV4()
    {
        katanaSI.RootSlash.SizeBuff = 1.5f;
    }

    public override void ToLV5()
    {
        katanaSI.RootSlash.SizeBuff = 2f;
    }
}