using System.Collections;
using UnityEngine;

public class RotateInput : MonoBehaviour, ITurnInput
{
    [SerializeField] MoveInput moveInput;
    Vector3 faceDirect;

    [SerializeField] PlayerGunAttack gunAtkSystem;
    [SerializeField] float shootStateDelay = 2f;

    private void OnEnable()
    {
        gunAtkSystem = PlayerSetup.instance.weaponInjection.GetComponent<PlayerGunAttack>();
    }
    public void AtkDirectToFaceDirect(Vector3 targetPos)
    {
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
        if (gunAtkSystem == null)
        {
            Debug.Log("RotateInput - gunAtkSystem == null");
            mDirect = moveInput.GetCurrentMoveDirect();
        }
        else
        {
            Debug.Log("RotateInput - gunAtkSystem != null");
            var target = gunAtkSystem.GetTarget();
            if (gunAtkSystem.CheckIfHasTarget())
            {
                Debug.Log("RotateInput - has target");
                AtkDirectToFaceDirect(target.position);
                return faceDirect;
            }
            else
            {
                Debug.Log("RotateInput - MoveDirect");
                mDirect = moveInput.GetCurrentMoveDirect();
            }
        }
        if (mDirect != Vector3.zero)
        {
            faceDirect = mDirect;
        }
        return faceDirect;
    }

    public Vector3 GetCurrentFaceDirect() => faceDirect;

    public bool IsRotateAble()
    {
        if (gunAtkSystem == null) return true;
        return gunAtkSystem.IsDone;
    }
}
