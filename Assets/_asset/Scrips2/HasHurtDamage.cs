using UnityEngine;

public class HasHurtDamage : MonoBehaviour, IHasHurtDamage
{
    [SerializeField] int damage = 5;
    public int GetHurtDamage() => damage;
}