using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Health health;
    [SerializeField] Image progressBar;

    public void ChangeHPBar()
    {
        float percent = (float)health.CurrentHP / health.MaxHP;
        progressBar.fillAmount = percent;
    }
}
