using UnityEngine;
using Lean.Pool;

public class ElectricMinesSkill : ActiveSkill
{
    [SerializeField] ActiveSkill_ElectricMine electricMinePrefab;
    [SerializeField] float shockScaleUpAmount;
    [SerializeField] LeanGameObjectPool electricPool;
    ActiveSkill_ElectricMine electricMines;
    public override int thisEnumInt => (int)ActiveSkillEnum.ElectricMines;

    public override void InjectSkill()
    {
        electricMines = Instantiate(electricMinePrefab, asi.transform);
    }

    public override void ToLV1()
    {
        electricMines.AddAnotherMine(electricPool);
        electricMines.AddAnotherMine(electricPool);
    }

    public override void ToLV2()
    {
        electricMines.ChangeShockScale(shockScaleUpAmount);
    }

    public override void ToLV3()
    {
        electricMines.AddAnotherMine(electricPool);
    }

    public override void ToLV4()
    {
        electricMines.AddAnotherMine(electricPool);
    }

    public override void ToLV5()
    {
        electricMines.AddAnotherMine(electricPool);
    }
}

public class FireWorksSkill : ActiveSkill
{
    public override int thisEnumInt => (int)ActiveSkillEnum.FireWorksSkill;

    public override void InjectSkill()
    {
        throw new System.NotImplementedException();
    }

    public override void ToLV1()
    {
        throw new System.NotImplementedException();
    }

    public override void ToLV2()
    {
        throw new System.NotImplementedException();
    }

    public override void ToLV3()
    {
        throw new System.NotImplementedException();
    }

    public override void ToLV4()
    {
        throw new System.NotImplementedException();
    }

    public override void ToLV5()
    {
        throw new System.NotImplementedException();
    }
}
