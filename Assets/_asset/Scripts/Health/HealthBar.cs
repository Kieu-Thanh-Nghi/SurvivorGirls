using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] internal Health health;
    [SerializeField] Image progressBar;

    public void SetHealth(Health theHealth)
    {
        health = theHealth;
        theHealth.OnChangeHeal.AddListener(ChangeHPBar);
        ChangeHPBar();
    }
    public void ChangeHPBar()
    {
        float percent = (float)health.CurrentHP / health.MaxHP;
        progressBar.fillAmount = percent;
    }
}
