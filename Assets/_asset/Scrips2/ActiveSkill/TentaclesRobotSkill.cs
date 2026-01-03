using UnityEngine;

public class TentaclesRobotSkill : ActiveSkill
{
    [SerializeField] ActiveSkill_TentaclesRobot tentaclesRobotPrefab;
    ActiveSkill_TentaclesRobot aggro;
    public override int thisEnumInt => (int)ActiveSkillEnum.TentaclesRobot;

    public override void InjectSkill()
    {
        aggro = Instantiate(tentaclesRobotPrefab, asi.transform);
        aggro.user = asi.transform;
    }

    public override void ToLV1()
    {
        aggro.transform.localScale = Vector3.one * 1.5f;
    }

    public override void ToLV2()
    {
        Bigger(0.15f);
    }

    public override void ToLV3()
    {
        Bigger(0.2f);

    }

    public override void ToLV4()
    {
        Bigger(0.2f);

    }

    public override void ToLV5()
    {
        Bigger(0.2f);
    }

    void Bigger(float percent)
    {
        Vector3 temp = aggro.transform.localScale;
        temp += temp * percent;
        aggro.transform.localScale = temp;
    }
}
