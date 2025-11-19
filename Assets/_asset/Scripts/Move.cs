using UnityEngine;
using Unity.Mathematics;

public class Move : ActWithAnimation
{
    [SerializeField] internal float moveSpeed;
    [SerializeField] float runSpeed;
    [SerializeField] internal Vector3 movingSpeedDirect;

    internal override void DoAct(Character character)
    {
        character.charCtlr.SimpleMove(movingSpeedDirect);
    }

    internal override void SetValueForActAndAnim(Character character)
    {
        movingSpeedDirect = character.inputs.MoveDirection() * moveSpeed;
    }

    internal override void SetAnimVal(Character character)
    {
        Animator animator = character.animator;
        AnimID animID = character.animID;
        SetAnimSpeedDirect(animator, animID.MoveSpeedX, character.transform.right);
        SetAnimSpeedDirect(animator, animID.MoveSpeedZ, character.transform.forward);
    }

    void SetAnimSpeedDirect(Animator animator, int speedAnimID, Vector3 charBaseAxis)
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
