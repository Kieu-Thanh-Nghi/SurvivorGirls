public class PlayerIceEff : Effect
{
    float slowAmount = 1;
    protected void OnEnable()
    {
        StartCoroutine(effectRunner.ActiveEff(DoIceEff, endEff));
    }
    public void TurnOnEff(float theSlowAmount, float effTime, float effInterval = 0.5f)
    {
        if (gameObject.activeSelf)
        {
            if (slowAmount >= theSlowAmount)
            {
                RefressEff();
                slowAmount = theSlowAmount;
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
    protected virtual void DoIceEff()
    {
        PlayerDataManager.Instance._moveSpeedScale *= slowAmount;
    }
    protected virtual void endEff()
    {
        StopAllCoroutines();
        PlayerDataManager.Instance._moveSpeedScale = 1;
        gameObject.SetActive(false);
    }
}

