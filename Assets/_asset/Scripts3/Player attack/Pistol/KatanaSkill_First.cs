public class KatanaSkill_First : KatanaSkill
{
    public override int thisEnumInt => (int)KatanaSkillEnum.Slash;

    public override void InjectSkill()
    {
        
    }

    public override void ToLV1()
    {
        AddSlashSize(10);
    }

    public override void ToLV2()
    {
        AddSlashSize(20);
    }

    public override void ToLV3()
    {
        AddSlashSize(20);
    }

    public override void ToLV4()
    {
        AddSlashSize(30);
    }

    public override void ToLV5()
    {
        AddSlashSize(40);
    }

    void AddSlashSize(float percent)
    {
        float times = percent * 0.01f + 1;
        katanaSI.SwordSlashSample.transform.localScale *= times;
    }
}
