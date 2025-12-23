using Unity.Mathematics;
using UnityEngine;

public class PlayerMoveAnim : MonoBehaviour, IMoveAnim
{
    [SerializeField] float runSpeed = 10;
    public void DoAnim(Animator animator, AnimID animID, float moveSpeed, Vector3 moveDirect)
    {
        var movingSpeedDirect = moveDirect * moveSpeed;
        SetAnimSpeedDirect(animator, animID.MoveSpeedX, transform.right, runSpeed, moveSpeed, movingSpeedDirect);
        SetAnimSpeedDirect(animator, animID.MoveSpeedZ, transform.forward, runSpeed, moveSpeed, movingSpeedDirect);
    }
    void SetAnimSpeedDirect(Animator animator, int speedAnimID, Vector3 charBaseAxis, float runSpeed, float moveSpeed, Vector3 movingSpeedDirect)
    {
        float anAxisSpeed = Vector3.Dot(movingSpeedDirect, charBaseAxis);
        anAxisSpeed = math.remap(-runSpeed, runSpeed, -1, 1, anAxisSpeed);
        float currentSpeed = animator.GetFloat(speedAnimID);

        //smooth speed_anim
        currentSpeed = Mathf.Lerp(currentSpeed, anAxisSpeed, 0.3f);
        if (Mathf.Abs(currentSpeed) > Mathf.Abs(moveSpeed) - 0.1f) currentSpeed = moveSpeed;
        if (Mathf.Abs(currentSpeed) < 0.01f) currentSpeed = 0;

        //set para
        animator.SetFloat(speedAnimID, currentSpeed);
    }

}
