using UnityEngine;

public class FrozeDroneSkill : ActiveSkill
{
    [SerializeField] ActiveSkill_FrozeDrone frozeDronePrefab;
    [SerializeField] float moveDistance = 5;
    ActiveSkill_FrozeDrone frozeDrone;
    public override int thisEnumInt => (int)ActiveSkillEnum.FrozeDrone;

    public override void InjectSkill()
    {
        frozeDrone = Instantiate(frozeDronePrefab, asi.transform);
    }

    public override void ToLV1()
    {
        frozeDrone.moveDistance = moveDistance;
    }

    public override void ToLV2()
    {
        frozeDrone.moveDistance += 2.5f;
    }

    public override void ToLV3()
    {
        frozeDrone.moveDistance += 1;
    }

    public override void ToLV4()
    {
        frozeDrone.moveDistance += 1;
    }

    public override void ToLV5()
    {
        frozeDrone.moveDistance += 1;
    }
}
