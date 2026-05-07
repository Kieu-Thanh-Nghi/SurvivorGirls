using UnityEngine;
using UnityEngine.Events;

public abstract class AEffContainer : MonoBehaviour
{
    public abstract void SubmitEff(StatusType statusType, Transform effHolder,
        UnityAction<Effect> OnAddAnEff = null);

    public abstract Effect GetCurrentEff();

    public abstract void StopEffimmediately();
}
