using UnityEngine;
using UnityEngine.Events;

public class BasicWeapon : MonoBehaviour, IWeapon
{
    [SerializeField] internal ProjectileEmiter emiter;
    [SerializeField] internal Vector3 dir;
    internal UnityAction<Vector3> GetTargetWhenAtk;

    public virtual void DoOneAttack(Vector3 targetPos)
    {
        Vector3 emiterPos = emiter.transform.position;
        emiterPos.y = targetPos.y;
        emiter.transform.position = emiterPos;
        //
        Vector3 direct = targetPos - emiter.transform.position;
        dir = direct;
        emiter.Emit(direct);
        GetTargetWhenAtk?.Invoke(targetPos);
    }

    public void SubscribeAnAtkToGetTarget(UnityAction<Vector3> WhenAttack)
    {
        GetTargetWhenAtk += WhenAttack;
    }
}