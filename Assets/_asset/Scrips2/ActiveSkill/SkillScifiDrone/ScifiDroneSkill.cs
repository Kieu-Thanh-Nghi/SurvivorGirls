using UnityEngine;

public class ScifiDroneSkill : ActiveSkill
{
    public override int thisEnumInt => (int)ActiveSkillEnum.ScifiDrone;
    [SerializeField] ActiveSkill_ScifiDrone ScifiDronePrefab;
    [SerializeField] float startFireRate = 4;
    ActiveSkill_ScifiDrone realScifiDrone;


    public override void InjectSkill()
    {
        realScifiDrone = Instantiate(ScifiDronePrefab, asi.transform);
        asi.playerActiveSkillsSystem.updateSkills.Add(realScifiDrone);
    }

    public override void ToLV1()
    {
        realScifiDrone.fireRate = startFireRate;
    }

    public override void ToLV2()
    {
        ChangeFireRate(0.2f);
    }

    public override void ToLV3()
    {
        ChangeFireRate(0.2f);
    }

    public override void ToLV4()
    {
        realScifiDrone.damage *= 2;
    }

    public override void ToLV5()
    {
        ChangeFireRate(0.2f);
    }

    void ChangeFireRate(float amount)
    {
        float frate = realScifiDrone.fireRate;
        frate += frate * amount;
        realScifiDrone.fireRate = frate;
    }
}
