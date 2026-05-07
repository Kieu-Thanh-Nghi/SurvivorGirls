using System.Collections;
using UnityEngine;
using TMPro;

public class Claim_Chip : Claim_Reward<int>
{
    [SerializeField] TMP_Text ChipQuantity;

    public override void ShowRewardQuantity(int quantity)
    {
        ChipQuantity.text = quantity.ToString();
    }
}

public abstract class Claim_Reward<T> : MonoBehaviour
{
    public abstract void ShowRewardQuantity(T quantity);
}
