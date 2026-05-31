using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DailyRewardsBackEnd : MonoBehaviour
{
    [SerializeField] string ClamedDays_SaveKey, ClaimedToday_SaveKey;
    [SerializeField] List<UnityEvent> rewardProducts;
    DailyProduct dailyProduct;

    int _claimedDays = -1;

    public bool ClaimedToday
    {
        get => dailyProduct.IsAchivedToday();
        set
        {
            if (value)
            {
                dailyProduct.SaveAchive();
            }
        }
    }
    public int ClaimedDays
    {
        get
        {
            if (_claimedDays == -1)
            {
                _claimedDays = PlayerPrefs.GetInt(ClamedDays_SaveKey, 0);
            }
            return _claimedDays;
        }
        set
        {
            if(value >= rewardProducts.Count)
            {
                _claimedDays = 0;
            }
            else
            {
                _claimedDays = value;
            }
            PlayerPrefs.SetInt(ClamedDays_SaveKey, _claimedDays);
        }
    }


    private void Start()
    {
        dailyProduct = new(ClaimedToday_SaveKey);
    }
    //lay du lieu da nhan bao nhieu ngay
    public void ClaimAReward(int rewardIndex)
    {
        rewardProducts[rewardIndex]?.Invoke();
    }
}

public abstract class Claimable : MonoBehaviour
{
    public abstract void Claim();
    public abstract Sprite GetIcon();
}

public class Claimable_Crate<T> : Claimable where T : Claimable
{
    [SerializeField] int quantity;
    public override void Claim()
    {
        throw new System.NotImplementedException();
    }

    public override Sprite GetIcon()
    {
        throw new System.NotImplementedException();
    }
}

public class Claimable_Equipment : Claimable
{
    public override void Claim()
    {
        throw new System.NotImplementedException();
    }

    public override Sprite GetIcon()
    {
        throw new System.NotImplementedException();
    }
}

public class Claimable_InGameCurrency : Claimable
{
    [SerializeField] internal CurrencyType currencyType;
    [SerializeField] internal int amount;
    [SerializeField] UnityEvent<Claimable> OnClaim;
    public override void Claim()
    {
        DatabaseManager.Instance.currencyDatas.ChangeCurrencyData(currencyType, amount);
        OnClaim?.Invoke(this);
    }

    public override Sprite GetIcon()
    {
        return DatabaseManager.Instance.uiDatas.CurrencyIcon[(int)currencyType];
    }
}