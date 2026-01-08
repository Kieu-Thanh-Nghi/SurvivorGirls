using UnityEngine;
using Lean.Pool;

public class ElectricMinesSkill : ActiveSkill
{
    [SerializeField] ActiveSkill_ElectricMine electricMinePrefab;
    [SerializeField] float shockScaleUpAmount;
    ActiveSkill_ElectricMine electricMines;
    public override int thisEnumInt => (int)ActiveSkillEnum.ElectricMines;

    public override void InjectSkill()
    {
        electricMines = Instantiate(electricMinePrefab, asi.transform);
    }

    public override void ToLV1()
    {
        electricMines.AddAnotherMine();
        electricMines.AddAnotherMine();
    }

    public override void ToLV2()
    {
        electricMines.ChangeShockScale(shockScaleUpAmount);
    }

    public override void ToLV3()
    {
        electricMines.AddAnotherMine();
    }

    public override void ToLV4()
    {
        electricMines.AddAnotherMine();
    }

    public override void ToLV5()
    {
        electricMines.AddAnotherMine();
    }
}
