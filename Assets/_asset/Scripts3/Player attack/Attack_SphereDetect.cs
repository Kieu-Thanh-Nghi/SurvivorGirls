using UnityEngine;
using UnityEngine.Events;

public class Attack_SphereDetect : MonoBehaviour
{
    public virtual void Attack(
        IHasEneDetecter hasEneDetecter,
        Transform rotateBody,
        AWeapon weapon,
        UnityAction DoWhenDoneAnAtk = null)
    {
        hasEneDetecter.CheckIfHasTarget();
        hasEneDetecter.DetectNewTarget();
        if (hasEneDetecter.IsHasTarget)
        {
            Debug.Log("Gun_AWeapon - EmitAnAtk");
            PointGunToTheTarget(rotateBody, hasEneDetecter);
            weapon.EmitAnAtk(hasEneDetecter.GetTarget().position);
            DoWhenDoneAnAtk?.Invoke();
        }
    }

    public void PointGunToTheTarget(Transform rotateBody, IHasEneDetecter hasEneDetecter)
    {
        Debug.Log("Gun_AWeapon - PointGunToTheTarget");
        var pointedDir = hasEneDetecter.GetTarget().position - rotateBody.position;
        pointedDir.y = 0;
        rotateBody.forward = pointedDir;
    }
}