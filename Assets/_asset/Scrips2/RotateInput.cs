using System.Collections;
using UnityEngine;

public class RotateInput : MonoBehaviour, ITurnInput
{
    [SerializeField] MoveInput moveInput;
    Vector3 faceDirect;

    [SerializeField] PlayerGunAtkSystem gunAtkSystem;
    [SerializeField] float shootStateDelay = 2f;
    float shootStateDelayCount = 10;

    private void OnEnable()
    {
        gunAtkSystem = PlayerSetup.instance.weaponInjection.GetComponent<PlayerGunAtkSystem>();
        gunAtkSystem?.gun.SubscribeAnAtkToGetTarget(AtkDirectToFaceDirect);
    }
    public void AtkDirectToFaceDirect(Vector3 targetPos)
    {
        shootStateDelayCount = 0;
        faceDirect = targetPos - transform.position;
        faceDirect.y = 0;
        //if (gunAtkSystem.isHasTarget && target != null && target.gameObject.activeInHierarchy)
        //{
        //    shootStateDelayCount = 0;
        //    faceDirect = targetPos - transform.position;
        //    faceDirect.y = 0;
        //}
    }
    public Vector3 GetFaceDirect()
    {
        //Vector2 charPos = Camera.main.WorldToScreenPoint(transform.position);
        //Vector2 mousePos = Input.mousePosition;
        //Vector2 directVector = mousePos - charPos;
        //Vector3 finalDirect = transform.forward;
        //finalDirect.x = directVector.x;
        //finalDirect.z = directVector.y;

        Vector3 mDirect = Vector3.zero;
        shootStateDelayCount += Time.deltaTime;
        if (gunAtkSystem == null)
        {
            mDirect = moveInput.GetCurrentMoveDirect();
        }
        else
        {
            var target = gunAtkSystem.GetCurrentTarget();
            if (gunAtkSystem.isHasTarget && target != null && target.gameObject.activeInHierarchy)
            {
                return faceDirect;
            }
            else
            {
                if(shootStateDelayCount < shootStateDelay)
                {
                    return faceDirect;
                }
                else
                {
                    mDirect = moveInput.GetCurrentMoveDirect();
                }
            }
        }
        if (mDirect != Vector3.zero)
        {
            faceDirect = mDirect;
        }
        return faceDirect;
    }

    public Vector3 GetCurrentFaceDirect() => faceDirect;
}
