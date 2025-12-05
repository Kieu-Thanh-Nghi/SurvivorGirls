using UnityEngine;
using Unity.Mathematics;

public class Move : MonoBehaviour, ICharacterAct, ICharacterAnim
{
    [SerializeField] internal float moveSpeed;
    [SerializeField] internal Vector3 movingSpeedDirect;
    [SerializeField] MoveAnim moveAnim;
    [SerializeField] MoveAction moveAction;

    public virtual void DoAct(Character character)
    {
        moveAction.GetMoving(character.transform, movingSpeedDirect);
    }

    public virtual void SetAnim(Character character)
    {
        moveAnim.SetAnimVal(character.transform, character.animator, character.animID,
            movingSpeedDirect, moveSpeed);
    }

    public virtual void SetValueForActAndAnim(Character character)
    {
        movingSpeedDirect = moveAction.SetMovingSpeedDirect(character.inputs.moveInput.MoveDirection(), moveSpeed);
    }
}

[CreateAssetMenu(menuName = "ScriptableObject/Move/MoveAction")]
public class MoveAction : ScriptableObject
{
    internal virtual Vector3 SetMovingSpeedDirect(Vector3 InputMoveDirection, float moveSpeed)
    {
        return InputMoveDirection * moveSpeed;
    }
    internal void GetMoving(Transform character, Vector3 movingSpeedDirect)
    {
        character.position += movingSpeedDirect * Time.fixedDeltaTime;
    }
}

[CreateAssetMenu(menuName = "ScriptableObject/Move/MoveAnim")]
public class MoveAnim : ScriptableObject
{
    [SerializeField] float runSpeed;

    internal virtual void SetAnimVal(Transform character, Animator animator, AnimID animID,
        Vector3 movingSpeedDirect, float moveSpeed)
    {
        SetAnimSpeedDirect(animator, animID.MoveSpeedX, character.right, movingSpeedDirect, moveSpeed);
        SetAnimSpeedDirect(animator, animID.MoveSpeedZ, character.forward, movingSpeedDirect, moveSpeed);
    }

    void SetAnimSpeedDirect(Animator animator, int speedAnimID, Vector3 charBaseAxis,
        Vector3 movingSpeedDirect, float moveSpeed)
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