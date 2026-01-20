using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlacritySkill : PassiveSkill
{
    public override int thisEnumInt => (int)PassiveSkillEnum.Alacrity;

    public override void InjectSkill()
    {
        
    }

    public override void ToLV1()
    {
        PlayerDataManager.Instance._moveSpeedScale *= 1.1f;
    }

    public override void ToLV2()
    {
        PlayerDataManager.Instance._moveSpeedScale *= 1.2f;
    }

    public override void ToLV3()
    {
        PlayerDataManager.Instance._moveSpeedScale *= 1.3f;
    }

    public override void ToLV4()
    {
        PlayerDataManager.Instance._moveSpeedScale *= 1.4f;
    }

    public override void ToLV5()
    {
        PlayerDataManager.Instance._moveSpeedScale *= 1.5f;
    }
}
