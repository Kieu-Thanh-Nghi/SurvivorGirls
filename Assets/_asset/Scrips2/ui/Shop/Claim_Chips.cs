using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Claim_Chips : MonoBehaviour
{
    [SerializeField] TMP_Text[] ChipQuantities;

    public void ShowRewardQuantities(List<int> Quantities)
    {
        int n = Quantities.Count;
        for(int i = 0; i < n; i++)
        {
            ChipQuantities[i].text = Quantities[i].ToString();
        }
    }
}
