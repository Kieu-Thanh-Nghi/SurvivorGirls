using UnityEngine;

public class PistolSkill_Third : PistolSkill
{
    [SerializeField] internal ExplotionEff explotionEff;
    [SerializeField] internal AWeapon PistolMagnum;
    [SerializeField] Vector3 explodeScale = Vector3.one * 0.44f;
    Vector3 currentScale;

    public override int thisEnumInt => (int)PistolSkillEnum.Magnum;

    public override void InjectSkill()
    {
        psi.pistolGunAttack.SixthSenseWeapon = PistolMagnum;
    }

    void SetExplotionScale(Vector3 theScale)
    {
        explotionEff.Scale = theScale;
    }

    public bool CheckIfOK(PistolSkill_Second skill2)
    {
        Debug.Log("thirt skill: " + (skill2 != null) + " - " + skill2.currentLV + " - " + currentLV);
        if (skill2 != null && skill2.currentLV > currentLV)
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
        SetExplotionScale(currentScale);
    }
    public override void ToLV2()
    {
        currentScale += currentScale * 0.1f;
        SetExplotionScale(currentScale);
    }
    public override void ToLV3()
    {
        currentScale += currentScale * 0.1f;
        SetExplotionScale(currentScale);
    }
    public override void ToLV4()
    {
        currentScale += currentScale * 0.1f;
        SetExplotionScale(currentScale);
    }
    public override void ToLV5()
    {
        currentScale += currentScale * 0.1f;
        SetExplotionScale(currentScale);
    }
}