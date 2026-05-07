using UnityEngine;
using UnityEngine.Events;

public class EffFilter : MonoBehaviour, IEffFilter
{
    [SerializeField] AEffContainer[] EffContainer;

    public void StopAllEff()
    {
        foreach(var container in EffContainer)
        {
            container.StopEffimmediately();
        }
    }

    public Effect GetCurrentEffect(StatusType statusType)
    {
        return EffContainer[(int)statusType].GetCurrentEff();
    }

    public Transform GetEffContainer(StatusType statusType) => transform;   
    public void SubmitEff(StatusType statusType, UnityAction<Effect> OnAddAnEff = null)
    {
        EffContainer[(int)statusType].SubmitEff(statusType, transform, OnAddAnEff);
    }
}

public interface IEffFilter
{
    public Transform GetEffContainer(StatusType statusType);
    public void SubmitEff(StatusType statusType, UnityAction<Effect> OnAddAnEff = null);
    public Effect GetCurrentEffect(StatusType statusType);
}
