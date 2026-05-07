using UnityEngine;

public class DailyChecker : MonoBehaviour
{
    [SerializeField] string saveKey;
    [SerializeField] GameObject[] AvalableMarks;
    DailyProduct dailyProduct;
    bool hasCheck;

    private void Start()
    {
        dailyProduct = new(saveKey);
        hasCheck = !dailyProduct.IsAchivedToday();
        if (!hasCheck)
        {
            SetOnOffAvalableMarks(false);
        }
        else
        {
            SetOnOffAvalableMarks(true);
        }
    }
    private void Update()
    {
        if (!hasCheck && dailyProduct.IsNewDay())
        {
            SetOnOffAvalableMarks(true);
            hasCheck = true;
        }
    }

    public void DoWhenBuyDaily()
    {
        SetOnOffAvalableMarks(false);
        dailyProduct.SaveAchive();
        hasCheck = false;
    }

    void SetOnOffAvalableMarks(bool isAvalable)
    {
        foreach (var mark in AvalableMarks)
        {
            mark.SetActive(isAvalable);
        }
    }

#if UNITY_EDITOR
    [ContextMenu("reset daily")]
    void ResetDaily()
    {
        dailyProduct.Reset();
    }
#endif
}