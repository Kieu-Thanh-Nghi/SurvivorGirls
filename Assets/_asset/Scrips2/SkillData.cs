using UnityEngine;

public class SkillData : AbstractSkillData
{
    [SerializeField] protected SkillInfos[] skillsDetail;

    public override SkillInfos GetASkillInfo(int skillIndex)
    {
        return skillsDetail[skillIndex];
    }
}
