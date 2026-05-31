using UnityEngine;

public class GunAttackStrategy : MonoBehaviour
{
    public virtual void Attack()
    {

    }    
    
    public virtual void Attack(AWeapon weapon)
    {
        weapon.EmitAnAtk();
    }
}
