using Unity.Services.LevelPlay;
using UnityEngine;
using UnityEngine.Events;

public class PurchaseButton_PayByAds : PurchaseButton
{
    [SerializeField] internal UnityEvent DoAfterAds;
    [SerializeField] internal string PlacementName;

#if !UNITY_EDITOR
    private void Start()
    {
        AdsManager.Instance.rewardedAd.OnAdRewarded += SetOnAdsReward;
        Debug.Log("PurchaseButton_PayByAds add SetOnAdsReward");
    }
#endif
    public override void PayThePrice()
    {
#if UNITY_EDITOR
        AdsManager.Instance.rewardedAd.OnAdRewarded += SetOnAdsReward;
#endif
        AdsManager.Instance.ShowRewarded(PlacementName);
        Debug.Log("PurchaseButton_PayByAds ShowRewarded");
    }

    void SetOnAdsReward(LevelPlayAdInfo info, LevelPlayReward reward)
    {
#if UNITY_EDITOR
        DoAfterAds?.Invoke();
        AdsManager.Instance.rewardedAd.OnAdRewarded -= SetOnAdsReward;
#else
        if(info.PlacementName.CompareTo(PlacementName) == 0)
        {
            DoAfterAds?.Invoke();
            Debug.Log("PurchaseButton_PayByAds DoAfterAds");
        }
        else
        {
            Debug.Log("webPlacementName: " + info.PlacementName + " :: " + "devicePlacementName: " + PlacementName);
        }
#endif
    }

#if !UNITY_EDITOR
    private void OnDestroy()
    {
        AdsManager.Instance.rewardedAd.OnAdRewarded -= SetOnAdsReward;
    }
#endif
}