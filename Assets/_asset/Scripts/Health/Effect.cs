using UnityEngine;

public class Effect : MonoBehaviour
{
    protected TimedEffectRunner effectRunner = new();
    [SerializeField] internal float totalTime = 5;
    internal float MultiplyAmount = 1;
    internal virtual float TotalTime => totalTime * MultiplyAmount;
    public void RefressEff(Effect addedEff = null)
    {
        if(addedEff != null)
        {
            totalTime = addedEff.TotalTime;
            effectRunner.totalTime = totalTime;
        }
        effectRunner.elapsed = 0;
    }
    public void SetEffData(float totalTime)
    {
        this.totalTime = totalTime;
        effectRunner.totalTime = TotalTime;
    }
    public void SetInfinite(bool isInfinte)
    {
        effectRunner.isInfinite = isInfinte;
    }    
    public void StopEff(bool isStop)
    {
        StopAllCoroutines();
        effectRunner.isStop = isStop;
    }

    protected virtual void EndEff()
    {
    }
}

[System.Serializable]
public class StatusData
{
    [SerializeField] protected float totalTime = 5;
    internal virtual float TotalTime => totalTime;
}

[System.Serializable]
public class ElectricStatusData : StatusData
{
    [SerializeField] protected float speedDecreaseAmount = 0.5f;
    [SerializeField] protected int damage = 1;
    internal virtual int Damage => Mathf.CeilToInt(damage);
    internal virtual float SpeedDecreaseAmount => speedDecreaseAmount;
}

[System.Serializable]
public class BurnStatusData : StatusData
{
    [SerializeField] protected int damage;
    internal virtual int Damage => damage;
}