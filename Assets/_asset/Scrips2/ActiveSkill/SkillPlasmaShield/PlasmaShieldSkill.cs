using UnityEngine;

public class PlasmaShieldSkill : ActiveSkill
{
    [SerializeField] ActiveSkill_PlasmaField plasmaFieldPrefab;
    [SerializeField] Vector3 shieldSize = Vector3.one * 4.25f;
    ActiveSkill_PlasmaField plasmaField;
    public override int thisEnumInt => (int)ActiveSkillEnum.PlasmaShield;

    public override void InjectSkill()
    {
        plasmaField = Instantiate(plasmaFieldPrefab, asi.transform);
    }

    public override void ToLV1()
    {
        plasmaField.damage = Mathf.CeilToInt(asi.weaponDamage * 0.15f);
        plasmaField.SetShieldSize(shieldSize);
    }

    public override void ToLV2()
    {
        AddMoreSizeToShield(0.2f);
    }

    public override void ToLV3()
    {
        AddMoreSizeToShield(0.2f);
    }

    public override void ToLV4()
    {
        AddMoreSizeToShield(0.2f);
    }

    public override void ToLV5()
    {
        AddMoreSizeToShield(0.2f);
    }

    void AddMoreSizeToShield(float amount)
    {
        var plasmaShieldSize = plasmaField.GetShieldSize();
        plasmaShieldSize += plasmaShieldSize * amount;
        plasmaField.SetShieldSize(plasmaShieldSize);
    }
}
