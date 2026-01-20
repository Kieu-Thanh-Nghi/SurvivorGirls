using UnityEngine;

public class JoystickMoveInput : MoveInput
{
    Joystick moveJoyStick => GamePlayCtrler.Instance.joystick;
    public override Vector3 MoveDirection()
    {
        moveDirect.x = moveJoyStick.Horizontal;
        moveDirect.z = moveJoyStick.Vertical;
        moveDirect = GamePlayCtrler.Instance.FolowPlayer.TransformDirection(moveDirect);
        return moveDirect;
    }
}
