public class PistolSkill_Magnum : BasicWeapon, IHasDamage
{
    public int GetDamage() => 5;

    private void Start()
    {
        emiter.SetHasDamageData(this);
        GetComponent<PistolSkill_SixthSense>().weapon = this;
    }
}
