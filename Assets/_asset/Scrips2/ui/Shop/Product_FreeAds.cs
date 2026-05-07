using UnityEngine;

public class Product_FreeAds : ShopProduct
{
    string save_key => AdsManager.Instance.FreeADs_SaveKey;
    public override void AchiveProduct()
    {
        PlayerPrefs.SetInt(save_key, 0);
        PlayerPrefs.Save();
    }

    [ContextMenu("reset free_ads")]
    void FreeReset()
    {
        PlayerPrefs.SetInt(save_key, -1);
        PlayerPrefs.Save();
    }
}