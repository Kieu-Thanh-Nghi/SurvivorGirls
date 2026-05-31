public class PistolSkill_Second : PistolSkill
{
    internal AttackStrategy_DetectedSpread pistolSkill_SixthSense;
    int neededEnemies = 6;
    int neededShots = 12;

    public override int thisEnumInt => (int)PistolSkillEnum.SixthSense;

    public override void InjectSkill()
    {
        pistolSkill_SixthSense = psi.pistolGunAttack.attackStrategy_DetectedSpread;
        psi.pistolGunAttack.DoWhenDoneAnAtk += psi.pistolGunAttack.ShotCount;
    }

    public override void ToLV1()
    {
        pistolSkill_SixthSense.NeededEnemies = neededEnemies;
        psi.pistolGunAttack.neededShots = neededShots;
    }
    public override void ToLV2()
    {
        pistolSkill_SixthSense.NeededEnemies = neededEnemies + 1;
    }
    public override void ToLV3()
    {
        pistolSkill_SixthSense.NeededEnemies = neededEnemies + 2;
    }
    public override void ToLV4()
    {
        pistolSkill_SixthSense.NeededEnemies = neededEnemies + 3;
    }
    public override void ToLV5()
    {
        pistolSkill_SixthSense.NeededEnemies = neededEnemies + 4;
    }
}