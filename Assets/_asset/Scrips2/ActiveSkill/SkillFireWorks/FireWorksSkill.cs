using UnityEngine;

public class FireWorksSkill : ActiveSkill
{
    [SerializeField] ActiveSkill_FireWorks fireWorksPrefab;
    [SerializeField] Vector3 explotionScale = Vector3.one * 0.4f;
    ActiveSkill_FireWorks fireWorks;
    public override int thisEnumInt => (int)ActiveSkillEnum.FireWorksSkill;

    public override void InjectSkill()
    {
        fireWorks = Instantiate(fireWorksPrefab, asi.transform);
    }

    public override void ToLV1()
    {
        fireWorks.FireCrackerScale = explotionScale;
    }

    public override void ToLV2()
    {
        fireWorks.FireCrackerScale += fireWorks.FireCrackerScale * 0.1f;
    }

    public override void ToLV3()
    {
        fireWorks.FireCrackerScale += fireWorks.FireCrackerScale * 0.1f;
    }

    public override void ToLV4()
    {
        fireWorks.FireCrackerScale += fireWorks.FireCrackerScale * 0.15f;
    }

    public override void ToLV5()
    {
        fireWorks.FireCrackerScale += fireWorks.FireCrackerScale * 0.2f;
    }
}
