using UnityEngine;

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

public interface ITargetChangable
{
    public void SetTarget(Transform newTarget);

    public void ResetTarget();
}

public interface IMoveFreezing
{
    public void SetIsMoveFreeze(bool isFreeze);
}

public enum DamageType
{
    Normal = 0,
    Crit = 1
}

public interface IHasHurtDamage
{
    public int GetHurtDamage();
}

