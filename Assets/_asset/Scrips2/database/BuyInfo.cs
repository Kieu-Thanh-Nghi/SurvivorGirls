using UnityEngine;

[CreateAssetMenu(fileName = "BuyInfo", menuName = "ScriptableObjects/BuyInfo")]
public class BuyInfo : ScriptableObject
{
    [SerializeField] internal Currency currencyType;
    [SerializeField] internal int neededAmount;
}
