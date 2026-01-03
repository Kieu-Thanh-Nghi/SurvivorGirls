using UnityEngine;

public class PistolThirdSkill : PistolSkill
{
    internal PistolSkill_Magnum pistolSkill_Magnum;
    [SerializeField] Vector3 explodeScale = Vector3.one * 0.44f;
    Vector3 currentScale;

    public override int thisEnumInt => (int)PistolSkillEnum.Magnum;

    public override void InjectSkill()
    {
        pistolSkill_Magnum = psi.gameObject.AddComponent<PistolSkill_Magnum>();
        var explodeEmiter = Object.Instantiate(psi.exlodeBulletParticleSystem, psi.pistolMuzzle);
        pistolSkill_Magnum.emiter = explodeEmiter;
        explodeEmiter.SetHasDamageData(psi.weaponData);
        var exploEff = Object.Instantiate(psi.explodeEff);
        explodeEmiter.explodeEff = exploEff;
        pistolSkill_Magnum.explotionEff = exploEff;

        var skill2 = psi.skillList[(int)PistolSkillEnum.SixthSense] as PistolSecondSkill;
        skill2.pistolSkill_SixthSense.weapon = pistolSkill_Magnum;
    }

    public bool CheckIfOK()
    {
        var skill2 = psi.skillList[(int)PistolSkillEnum.SixthSense] as PistolSecondSkill;
        if(skill2 != null && skill2.currentLV > currentLV)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public override void ToLV1()
    {
        currentScale = explodeScale;
        pistolSkill_Magnum.SetExplotionScale(currentScale);
    }
    public override void ToLV2()
    {
        currentScale += currentScale * 0.1f;
        pistolSkill_Magnum.SetExplotionScale(currentScale);
    }
    public override void ToLV3()
    {
        currentScale += currentScale * 0.1f;
        pistolSkill_Magnum.SetExplotionScale(currentScale);
    }
    public override void ToLV4()
    {
        currentScale += currentScale * 0.1f;
        pistolSkill_Magnum.SetExplotionScale(currentScale);
    }
    public override void ToLV5()
    {
        currentScale += currentScale * 0.1f;
        pistolSkill_Magnum.SetExplotionScale(currentScale);
    }
}
