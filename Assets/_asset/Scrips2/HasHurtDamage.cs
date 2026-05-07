using UnityEngine;

public class HasHurtDamage : MonoBehaviour, IHasHurtDamage
{
    [SerializeField] internal int damage = 5;
    public int GetHurtDamage() => damage;
}