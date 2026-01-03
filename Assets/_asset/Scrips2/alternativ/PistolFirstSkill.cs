using UnityEngine;

public class PistolFirstSkill : PistolSkill
{
    internal PistolSkill_Training pistolSkill_Training;
    int TimesToShoot = 1;

    public override int thisEnumInt => (int)PistolSkillEnum.Training;

    public override void InjectSkill()
    {
        pistolSkill_Training =
            psi.gameObject.AddComponent<PistolSkill_Training>();

        pistolSkill_Training.SetUp(
            psi.gunWeapon,
            psi.nearestObjectSphereDetecter,
            psi.playerGunAtkSystem,
            psi.playerGunAtkSystem);

        var Skill2 = psi.skillList[(int)PistolSkillEnum.SixthSense] as PistolSecondSkill;
        if (Skill2 != null && Skill2.pistolSkill_SixthSense != null)
        {
            pistolSkill_Training.SubscribeOnlyOneShotEvent(Skill2.pistolSkill_SixthSense.ShotCount);
        }
    }
    public override void ToLV1() => pistolSkill_Training.TimesToShoot = TimesToShoot;
    public override void ToLV2() => pistolSkill_Training.TimesToShoot = TimesToShoot + 1;
    public override void ToLV3() => pistolSkill_Training.TimesToShoot = TimesToShoot + 2;
    public override void ToLV4() => pistolSkill_Training.TimesToShoot = TimesToShoot + 3;
    public override void ToLV5() => pistolSkill_Training.TimesToShoot = TimesToShoot + 4;
}
