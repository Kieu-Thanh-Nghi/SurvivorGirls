using UnityEngine;

public class BladeDroneSkill : ActiveSkill
{
    public override int thisEnumInt => (int)ActiveSkillEnum.BladeDrone;
    [SerializeField] ActiveSkill_BladeDrone allBladeDronesPrefab;
    ActiveSkill_BladeDrone realAllBladeDrones;

    public override void InjectSkill()
    {
        var allBladeDrones = Instantiate(allBladeDronesPrefab, asi.transform);
        asi.playerActiveSkillsSystem.updateSkills.Add(allBladeDrones);
        realAllBladeDrones = allBladeDrones;
    }

    public override void ToLV1()
    {
        realAllBladeDrones.SummonAnotherBlade();
    }

    public override void ToLV2()
    {
        realAllBladeDrones.SummonAnotherBlade();
    }

    public override void ToLV3()
    {
        realAllBladeDrones.SummonAnotherBlade();
    }

    public override void ToLV4()
    {
        realAllBladeDrones.SummonAnotherBlade();
    }

    public override void ToLV5()
    {
        realAllBladeDrones.SummonAnotherBlade();
    }
}
