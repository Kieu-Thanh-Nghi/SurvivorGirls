using UnityEngine;

public class PlayerInternalHeal : MonoBehaviour
{
    [SerializeField] float coolDown = 3;
    [SerializeField] Health health;
    [SerializeField] PassiveSkill_HealingFactor healingFactor;

    private void OnEnable()
    {
        var healAmount = PlayerDataManager.Instance.PlayerHealAmount();
        if(healAmount <= 0)
        {
            return;
        }
        healingFactor.coolDown = coolDown;
        healingFactor.healAmount = healAmount;
        healingFactor.health = health;
        healingFactor.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        healingFactor.gameObject.SetActive(false);
    }
}