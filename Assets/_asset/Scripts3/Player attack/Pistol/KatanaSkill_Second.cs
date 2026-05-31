public class KatanaSkill_Second : KatanaSkill
{
    public override int thisEnumInt => (int)KatanaSkillEnum.BulletCut;

    public override void InjectSkill()
    {
        katanaSI.RootSlash.IsBulletCut = true;
    }

    public override void ToLV1()
    {
        AddSlashMoveDistance(10);
    }

    public override void ToLV2()
    {
        AddFireRate(10);
    }

    public override void ToLV3()
    {
        AddSlashMoveDistance(20);
    }

    public override void ToLV4()
    {
        AddFireRate(10);
    }

    public override void ToLV5()
    {
        AddSlashMoveDistance(30);
    }
    void AddSlashMoveDistance(float percent)
    {
        katanaSI.SwordSlashSample.flyVelocity *= (1 + percent * 0.01f);
    }
    void AddFireRate(float percent)
    {
        katanaSI.atkSystem.AttackCountdown *= (1 - percent * 0.01f);
    }
}