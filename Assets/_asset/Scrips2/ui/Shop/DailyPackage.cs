using UnityEngine;
using UnityEngine.Events;

public class DailyPackage : MonoBehaviour, IPayable
{
    [SerializeField] UnityEvent PayForReward;
    [SerializeField] UnityEvent BonusRewards;
    [SerializeField] UnityEvent AfterPay;

    public void DonePaying()
    {
        PayForReward?.Invoke();
        BonusRewards?.Invoke();
        AfterPay?.Invoke();
        Debug.Log("DailyPackage");
    }
}
