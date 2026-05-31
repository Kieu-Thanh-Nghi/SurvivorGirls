public class PistolSkill_First : PistolSkill
{
    internal AttackStrategy_DetectContinuous pistolSkill_Training;
    int TimesToShoot = 2;

    public override int thisEnumInt => (int)PistolSkillEnum.Training;

    public override void InjectSkill()
    {
        pistolSkill_Training = psi.pistolGunAttack.gunAttackStrategy_DetectContinuous;
    }
    public override void ToLV1() => pistolSkill_Training.TimesToShoot = TimesToShoot;
    public override void ToLV2() => pistolSkill_Training.TimesToShoot = TimesToShoot + 1;
    public override void ToLV3() => pistolSkill_Training.TimesToShoot = TimesToShoot + 2;
    public override void ToLV4() => pistolSkill_Training.TimesToShoot = TimesToShoot + 3;
    public override void ToLV5() => pistolSkill_Training.TimesToShoot = TimesToShoot + 4;
}
