using UnityEngine;

public abstract class StatusGiver<T> : MonoBehaviour
{
    protected abstract StatusType statusType
    {
        get;
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        ApplyStatus(other);
    }

    protected void ApplyStatus(Collider other)
    {
        var effFilter = other.GetComponent<IEffFilter>();
        effFilter.SubmitEff(statusType, SetTheAddedEff);
    }

    protected virtual void SetTheAddedEff(Effect addedEff)
    {
        if (addedEff is T theEff)
        {
            EffSetting(theEff);
        }
    }

    protected abstract void EffSetting(T theEff);
}
