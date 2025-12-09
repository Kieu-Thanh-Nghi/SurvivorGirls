using UnityEngine;
using Unity.Mathematics;

public class Move : MonoBehaviour
{
    [SerializeField] internal Vector3 movingSpeedDirect;
    [SerializeField] MoveInput moveInput;

    public virtual void DoAct(Transform character)
    {
        character.position += movingSpeedDirect * Time.fixedDeltaTime;
    }

    internal virtual void DoAnim(Transform character, Animator animator, AnimID animID, float runSpeed, float moveSpeed)
    {
        SetAnimSpeedDirect(animator, animID.MoveSpeedX, character.right, runSpeed, moveSpeed);
        SetAnimSpeedDirect(animator, animID.MoveSpeedZ, character.forward, runSpeed, moveSpeed);
    }

    void SetAnimSpeedDirect(Animator animator, int speedAnimID, Vector3 charBaseAxis, float runSpeed, float moveSpeed)
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


    public virtual void SetValue(float moveSpeed)
    {
        movingSpeedDirect = moveInput.MoveDirection() * moveSpeed;
    }
}
