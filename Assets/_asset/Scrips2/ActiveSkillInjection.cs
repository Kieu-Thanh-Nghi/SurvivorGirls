using UnityEngine;

public class ActiveSkillInjection : SkillInjection
{
    [SerializeField] internal Transform Player;
    [SerializeField] internal PlayerActiveSkillsSystem playerActiveSkillsSystem;
    [SerializeField] internal PlayerParaScale playerParaScale;

    [ContextMenu("testBD")]
    void testBD()
    {
        UpgradeASkill(SkillEnum.BladeDrone);
    }
    [ContextMenu("testSD")]
    void testSD()
    {
        UpgradeASkill(SkillEnum.ScifiDrone);
    }
}
