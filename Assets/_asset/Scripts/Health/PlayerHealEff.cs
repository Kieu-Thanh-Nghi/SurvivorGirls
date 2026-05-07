using UnityEngine;

public class PlayerHealEff : MonoBehaviour
{
    [SerializeField] internal ParticleSystem smallHeal, bigHeal;
    [SerializeField] Health health;
    [SerializeField] int smallHealLimit = 10;

    private void Start()
    {
        health.OnHealthGainAmount += TurnOnHealEff;
    }
    void TurnOnHealEff(int healAmount)
    {
        if(healAmount > 0)
        {
            if(healAmount < smallHealLimit)
            {
                smallHeal.Play();
            }
            else
            {
                bigHeal.Play();
            }
        }
    }
}