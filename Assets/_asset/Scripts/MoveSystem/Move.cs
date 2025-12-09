using UnityEngine;
using Unity.Mathematics;

public class Move : OnlyMove
{
    //public override void DoAct(Transform character)
    //{
    //    character.position += movingSpeedDirect * Time.fixedDeltaTime;
    //}

    internal virtual void DoAnim(Transform character, Animator animator, AnimID animID, float runSpeed, float moveSpeed, Vector3 movingSpeedDirect)
    {
        SetAnimSpeedDirect(animator, animID.MoveSpeedX, character.right, runSpeed, moveSpeed, movingSpeedDirect);
        SetAnimSpeedDirect(animator, animID.MoveSpeedZ, character.forward, runSpeed, moveSpeed, movingSpeedDirect);
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
