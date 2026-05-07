using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSkillData : AbstractSkillData
{
    [SerializeField] WSkillUIInfos[] skillsDetailsPrefab;

    public WSkillUIInfos GetASkillDetailsPrefab(int skillIndex)
    {
        return skillsDetailsPrefab[skillIndex];
    }

    public override SkillInfos GetASkillInfo(int skillIndex)
    {
        return skillsDetailsPrefab[skillIndex];
    }
}

public abstract class AbstractSkillData : MonoBehaviour
{
    public abstract SkillInfos GetASkillInfo(int skillIndex);
}

[System.Serializable]
public class WSkillUIInfos : SkillInfos
{
    [SerializeField] internal string describe;
    [SerializeField] internal ItemRank theRank;
    internal GameObject skillDetailsPrefab => skillDetails.gameObject;
}

[System.Serializable]
public class SkillInfos
{
    [SerializeField] internal SkillDetail skillDetails;
    [SerializeField] internal string name;
    [SerializeField] internal Sprite skill_icon;
}