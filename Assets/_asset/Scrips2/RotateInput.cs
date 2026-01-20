using System.Collections;
using UnityEngine;

public class RotateInput : MonoBehaviour, ITurnInput, IHasCoolDown
{
    [SerializeField] MoveInput moveInput;
    Vector3 faceDirect;

    [SerializeField] PlayerGunAtkSystem gunAtkSystem;
    [SerializeField] float shootStateDelay = 0.1f;
    CoolDownSystem coolDownSystem = new();
    bool isShooting;

    public float GetCoolDown()
    {
        return shootStateDelay;
    }
    void WhenGunShoot()
    {
        if (isShooting)
        {
            coolDownSystem.counting = 0;
        }
        else
        {
            StartCoroutine(ChangeShootState());
        }
    }

    IEnumerator ChangeShootState()
    {
        isShooting = true;
        yield return coolDownSystem.RunCoolDown(this);
        isShooting = false;
    }
    private void Start()
    {
        gunAtkSystem?.SubscribeAtkEvent(WhenGunShoot);
    }
    public Vector3 GetFaceDirect()
    {
        //Vector2 charPos = Camera.main.WorldToScreenPoint(transform.position);
        //Vector2 mousePos = Input.mousePosition;
        //Vector2 directVector = mousePos - charPos;
        //Vector3 finalDirect = transform.forward;
        //finalDirect.x = directVector.x;
        //finalDirect.z = directVector.y;

        Vector3 mDirect;

        if (isShooting)
        {
            mDirect = gunAtkSystem.gun.direct;
        }
        else
        {
            mDirect = moveInput.GetCurrentMoveDirect();
        }
        if (mDirect != Vector3.zero)
        {
            faceDirect = mDirect;
        }
        return faceDirect;
    }

    public Vector3 GetCurrentFaceDirect() => faceDirect;
}