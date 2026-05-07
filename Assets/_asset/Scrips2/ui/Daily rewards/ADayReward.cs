using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ADayReward : MonoBehaviour
{
    [SerializeField] Image glow;
    [SerializeField] GameObject rewardCheck;
    [SerializeField] UnityEvent OnClaimReward;
    public void AvalableThis()
    {
        glow.enabled = true;
        rewardCheck.SetActive(false);
    }

    public void ClaimThis()
    {
        OnClaimReward?.Invoke();
        CheckClaimedThis();
    }

    public void CheckClaimedThis()
    {
        glow.enabled = false;
        rewardCheck.SetActive(true);
    }
}