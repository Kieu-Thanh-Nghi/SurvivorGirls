using UnityEngine;
using Unity.Services.LevelPlay;

public class AdsManager : MonoBehaviour
{
    public static AdsManager Instance;

    [Header("App Key")]
    [SerializeField] string appKey;

    [Header("Ad Unit Ids")]
    [SerializeField] string rewardedId;
    [SerializeField] string interstitialId;
    [SerializeField] string bannerId;

    internal LevelPlayRewardedAd rewardedAd;
    internal LevelPlayInterstitialAd interstitialAd;
    internal LevelPlayBannerAd bannerAd;

    [Header("Free ads")]
    [SerializeField] internal string FreeADs_SaveKey;

    void Awake()
    {
        if (!PlayerPrefs.HasKey(FreeADs_SaveKey))
        {
            PlayerPrefs.SetInt(FreeADs_SaveKey, -1);
            PlayerPrefs.Save();
        }
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        // Init SDK
        LevelPlay.Init(appKey);

        InitRewarded();

        if (PlayerPrefs.HasKey(FreeADs_SaveKey) && PlayerPrefs.GetInt(FreeADs_SaveKey) > -1) return;
        InitInterstitial();
        InitBanner();
    }

    #region REWARDED
    void InitRewarded()
    {
        rewardedAd = new LevelPlayRewardedAd(rewardedId);

        rewardedAd.OnAdLoaded += (adInfo) =>
        {
            Debug.Log("Rewarded Loaded");
        };

        rewardedAd.OnAdLoadFailed += (error) =>
        {
            Debug.Log("Rewarded Load Failed: " + error);
        };

        rewardedAd.OnAdRewarded += (info, reward) =>
        {
            Debug.Log($"Reward: {reward.Name} - {reward.Amount}");
            // TODO: Give reward
        };

        rewardedAd.OnAdClosed += (info) =>
        {
            LoadRewarded(); // auto reload
        };

        LoadRewarded();
    }

    public void LoadRewarded()
    {
        rewardedAd.LoadAd();
    }

    public void ShowRewarded(string placement)
    {
        if (rewardedAd.IsAdReady())
            rewardedAd.ShowAd(placement);
        else
            Debug.Log("Rewarded not ready");
    }
    #endregion

    #region INTERSTITIAL
    void InitInterstitial()
    {
        interstitialAd = new LevelPlayInterstitialAd(interstitialId);

        interstitialAd.OnAdLoaded += (adInfo) =>
        {
            Debug.Log("Interstitial Loaded");
        };

        interstitialAd.OnAdClosed += (info) =>
        {
            LoadInterstitial(); // auto reload
        };

        LoadInterstitial();
    }

    public void LoadInterstitial()
    {
        interstitialAd.LoadAd();
    }

    public void ShowInterstitial()
    {
        if (interstitialAd.IsAdReady())
            interstitialAd.ShowAd();
        else
            Debug.Log("Interstitial not ready");
    }
    #endregion

    #region BANNER
    void InitBanner()
    {
        bannerAd = new LevelPlayBannerAd(bannerId);

        bannerAd.OnAdLoaded += (adInfo) =>
        {
            Debug.Log("Banner Loaded");
        };

        bannerAd.OnAdLoadFailed += (error) =>
        {
            Debug.Log("Banner Load Failed: " + error);
        };

        bannerAd.LoadAd();
    }

    public void ShowBanner()
    {
        bannerAd.ShowAd();
    }

    public void HideBanner()
    {
        bannerAd.HideAd();
    }
    #endregion
}
