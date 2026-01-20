using UnityEngine;
using UnityEngine.Events;

public class Interfaces : MonoBehaviour
{
}

public interface IHasDamage
{
    public int GetDamage();
}

public interface IExpType
{
    public int GetType();
}
public interface IDamageable
{
    public void TakeDamage(int dameAmount, DamageType type);
}

public interface ISetOnDead
{
    public void SetDoWhenDie(UnityAction DieFunc);
}

public interface ITargetChangable
{
    public void SetTarget(Transform newTarget);

    public void ResetTarget();
}

public interface IMoveFreezing
{
    public void SetIsMoveFreeze(bool isFreeze);
}
public interface IHasHurtDamage
{
    public int GetHurtDamage();
}

public interface IHasMaxHealth
{
    public int GetMaxHp();
    public void SetMaxHp(int maxHP);
}
public enum DamageType
{
    Normal = 0,
    Range = 1,
    Melee = 2,
    Crit = 3,
    CritRange = 4,
    CritMele = 5
}