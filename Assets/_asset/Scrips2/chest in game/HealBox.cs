using UnityEngine;

public class HealBox : MonoBehaviour
{
    [SerializeField] int healAmount;
    public void DoHeal(Collider other)
    {
        other.GetComponent<Health>().Healing(healAmount);
    }
}