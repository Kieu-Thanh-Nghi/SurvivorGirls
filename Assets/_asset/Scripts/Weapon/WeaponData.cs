using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/weaponData")]
public class WeaponData : ScriptableObject , IHasDamage
{
    [SerializeField] internal int WeaponType;
    DamageType currentType;
    public int GetDamage() => Mathf.CeilToInt(PlayerDataManager.Instance.CalculateDamage(out currentType));

    public DamageType GetDamageType()
    {
        return currentType;
    }
}
