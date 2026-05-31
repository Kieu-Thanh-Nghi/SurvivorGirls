using UnityEngine;

public class ProjectileEmitter : MonoBehaviour
{
    protected IHasDamage hasDamage;
    public void SetHasDamageData(IHasDamage damageData) => hasDamage = damageData;
    public virtual void EmitProjectile()
    {

    }
}
