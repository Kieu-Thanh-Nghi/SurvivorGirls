using UnityEngine;

public class Interfaces : MonoBehaviour
{
}

public interface IDamageable
{
    public void TakeDamage(int dameAmount);
}

public interface IHasDamage
{
    public int GetDamage();
}

public interface IDoLevelUp
{
    public void LevelUp();
}
