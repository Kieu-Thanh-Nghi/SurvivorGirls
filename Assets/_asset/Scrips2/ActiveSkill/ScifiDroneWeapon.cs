using UnityEngine;

public class ScifiDroneWeapon : MonoBehaviour, IWeapon
{
    [SerializeField] internal ProjectileEmiter emiter;
    [SerializeField] Transform[] gunPos;

    public void DoOneAttack(Vector3 targetPos)
    {
        
    }
}
