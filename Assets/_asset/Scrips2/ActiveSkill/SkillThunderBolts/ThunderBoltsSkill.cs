using UnityEngine;

public class ThunderBoltsSkill : ActiveSkill
{
    [SerializeField] ActiveSkill_ThunderBolts thunderBoltsPrefab;
    [SerializeField] int strikeQuantity = 1;
    [SerializeField] float ElectricShocTime = 3;
    ActiveSkill_ThunderBolts thunderBolts;

    public override int thisEnumInt => (int)ActiveSkillEnum.ThunderBolts;

    public override void InjectSkill()
    {
        thunderBolts = Instantiate(thunderBoltsPrefab, asi.transform);
    }

    public override void ToLV1()
    {
        thunderBolts.neededEnemies = strikeQuantity;
        thunderBolts.EShockTime = ElectricShocTime;
    }

    public override void ToLV2()
    {
        thunderBolts.neededEnemies = strikeQuantity + 1;
        thunderBolts.EShockTime += thunderBolts.EShockTime * 0.1f;
    }

    public override void ToLV3()
    {
        thunderBolts.neededEnemies = strikeQuantity + 2;
        thunderBolts.EShockTime += thunderBolts.EShockTime * 0.1f;
    }

    public override void ToLV4()
    {
        thunderBolts.neededEnemies = strikeQuantity + 3;
        thunderBolts.EShockTime += thunderBolts.EShockTime * 0.1f;
    }

    public override void ToLV5()
    {
        thunderBolts.neededEnemies = strikeQuantity + 4;
        thunderBolts.EShockTime += thunderBolts.EShockTime * 0.1f;
    }
}
