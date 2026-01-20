using UnityEngine;

public class PassiveSkill_HealingFactor : MonoBehaviour, IHasCoolDown
{
    internal float coolDown = 3;
    internal int healAmount = 1;
    internal Health health;
    CoolDownSystem coolDownSystem = new();

    private void Start()
    {
        StartCoroutine(coolDownSystem.RunEffInCoolDown(DoHeal, this));
    }
    private void OnDestroy()
    {
        StopAllCoroutines();
    }
    void DoHeal()
    {
        health.Healing(healAmount);
    }

    public float GetCoolDown()
    {
        return coolDown * PlayerDataManager.Instance._ASCoolDownScale;
    }
}