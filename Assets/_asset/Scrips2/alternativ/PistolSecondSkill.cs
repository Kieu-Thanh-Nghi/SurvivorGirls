using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/PistolSkill/SecondSkill")]
public class PistolSecondSkill : PistolSkill
{
    internal PistolSkill_SixthSense pistolSkill_SixthSense;
    int neededEnemies = 6;
    int neededShots = 12;

    public override SkillEnum thisEnum => SkillEnum.SixthSense;

    public override void InjectSkill()
    {
        pistolSkill_SixthSense =
            psi.gameObject.AddComponent<PistolSkill_SixthSense>();
        pistolSkill_SixthSense.SetUp(
            psi.nearestObjectSphereDetecter,
            psi.gunWeapon);

        var skill1 = psi.skillList[(int)SkillEnum.Training] as PistolFirstSkill;
        psi.playerGunAtkSystem.SubscribeOnlyOneShotEvent(pistolSkill_SixthSense.ShotCount);
        Debug.Log(psi.playerGunAtkSystem.DoWhenDoneAnAtk == null);
        if (skill1 != null && skill1.pistolSkill_Training != null)
        {
            skill1.pistolSkill_Training.SubscribeOnlyOneShotEvent(pistolSkill_SixthSense.ShotCount);
        }
    }

    public override void ToLV1()
    {
        pistolSkill_SixthSense.neededEnemies = neededEnemies;
        pistolSkill_SixthSense.neededShots = neededShots;
    }
    public override void ToLV2()
    {
        pistolSkill_SixthSense.neededEnemies = neededEnemies + 1;
    }
    public override void ToLV3()
    {
        pistolSkill_SixthSense.neededEnemies = neededEnemies + 2;
    }
    public override void ToLV4()
    {
        pistolSkill_SixthSense.neededEnemies = neededEnemies + 3;
    }
    public override void ToLV5()
    {
        pistolSkill_SixthSense.neededEnemies = neededEnemies + 4;
    }
}
