using UnityEngine;

public class Move : ActWithAnimation
{
    [SerializeField] float moveSpeed;
    [SerializeField] Vector3 movingSpeed;

    internal override void DoAct(Character character)
    {
        character.charCtlr.SimpleMove(movingSpeed);
    }

    internal override void SetValueForActAndAnim(Character character)
    {
        movingSpeed = character.inputs.MoveDirection() * moveSpeed * Time.fixedDeltaTime;
    }

    internal override void SetAnimVal(Character character)
    {
        character.animator.SetFloat(character.animID.movingPara, movingSpeed.magnitude);
    }
}
