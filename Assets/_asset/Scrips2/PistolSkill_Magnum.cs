using UnityEngine;
public class PistolSkill_Magnum : BasicWeapon
{
    [SerializeField] internal ExplotionEff explotionEff;

    [ContextMenu("ChangeSize")]
    void bigger()
    {
        explotionEff.Scale = Vector3.one;
    }
    [ContextMenu("SmallChangeSize")]
    void smaller()
    {
        explotionEff.Scale = Vector3.one * 0.5f;
    }
}
