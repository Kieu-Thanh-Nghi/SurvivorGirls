using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/weaponData")]
public class WeaponData : ScriptableObject , IHasDamage
{
    [SerializeField] int damage = 5;
    public int GetDamage() => Mathf.CeilToInt(damage * PlayerDataManager.Instance._damage);
}
