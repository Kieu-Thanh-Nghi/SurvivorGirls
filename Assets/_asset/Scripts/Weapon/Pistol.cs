using Lean.Pool;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    [SerializeField] ParticleSystem bulletEmitter;
    
    public void Shoot(Vector3 shootDirection)
    {
        bulletEmitter.transform.forward = shootDirection;
        //Vector3 temp = bulletEmitter.transform.forward;
        //temp.y = 0;
        //bulletEmitter.transform.forward = temp;
        bulletEmitter.Emit(1);
    }
}
