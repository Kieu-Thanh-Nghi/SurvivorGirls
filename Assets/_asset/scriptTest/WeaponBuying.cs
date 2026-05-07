using UnityEngine;

public class WeaponBuying : MonoBehaviour, IPayable
{
    [SerializeField] internal PayButton buyButton;
    [SerializeField] WeaponChoosingUI weaponChoosing;
    [SerializeField] internal int BuyPrice;

    public void DonePaying()
    {
        weaponChoosing.BuyThis();
    }
}
