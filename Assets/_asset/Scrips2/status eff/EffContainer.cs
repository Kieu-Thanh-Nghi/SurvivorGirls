using UnityEngine.Events;
using UnityEngine;
using Lean.Pool;

public class EffContainer<T> : AEffContainer where T : Effect
{
    internal T currentEffect;

    public override Effect GetCurrentEff()
    {
        return currentEffect;
    }

    public override void StopEffimmediately()
    {
        if (currentEffect == null) return;
        currentEffect.StopEff(true);
        LeanPool.Despawn(currentEffect.gameObject);
    }

    public override void SubmitEff(StatusType statusType, Transform effHolder,
        UnityAction<Effect> OnAddAnEff = null)
    {
        if (currentEffect == null || currentEffect.transform.parent != effHolder)
        {
            currentEffect = GamePlayCtrler.Instance.statusManager
                .CreateAStatusEff<T>(statusType, effHolder);
        }
        else
        {
            currentEffect.RefressEff();
        }
        OnAddAnEff?.Invoke(currentEffect);
        FilterEff();
    }

    protected virtual void FilterEff() { }
}
