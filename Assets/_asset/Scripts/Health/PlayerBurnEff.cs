using UnityEngine;

public class PlayerBurnEff : BurnEff
{
    [SerializeField] Health health;

    private void Start()
    {
        damageable = health;
    }
    protected override void OnEnable()
    {
        StartCoroutine(effectRunner.RunEff(damageTarget, endEff));
    }
    public void TurnOnEff(IHasDamage theHasDamage, float effTime, float effInterval = 0.5f)
    {
        if (gameObject.activeSelf)
        {
            if (damage <= theHasDamage.GetDamage())
            {
                RefressEff();
                hasDamage = theHasDamage;
                effectRunner.totalTime = effTime;
                effectRunner.interval = effInterval;
            }
        }
        else
        {
            effectRunner.totalTime = effTime;
            effectRunner.interval = effInterval;
            gameObject.SetActive(true);
        }
    }

    protected override void endEff()
    {
        StopAllCoroutines();
        gameObject.SetActive(false);
    }
}

