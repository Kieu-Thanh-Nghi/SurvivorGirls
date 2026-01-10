using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMoveSpeedSkill : PassiveSkill
{
    public override int thisEnumInt => (int)PassiveSkillEnum.ChangeMoveSpeed;

    public override void InjectSkill()
    {
        
    }

    public override void ToLV1()
    {
        PlayerParaScale.Instance._moveSpeed *= 1.2f;
    }

    public override void ToLV2()
    {
        PlayerParaScale.Instance._moveSpeed *= 1.2f;
    }

    public override void ToLV3()
    {
        PlayerParaScale.Instance._moveSpeed *= 1.2f;
    }

    public override void ToLV4()
    {
        PlayerParaScale.Instance._moveSpeed *= 1.2f;
    }

    public override void ToLV5()
    {
        PlayerParaScale.Instance._moveSpeed *= 1.2f;
    }
}
