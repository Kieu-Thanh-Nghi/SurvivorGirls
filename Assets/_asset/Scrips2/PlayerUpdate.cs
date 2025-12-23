using UnityEngine;

public class PlayerUpdate : MonoBehaviour
{
    [SerializeField] InputStore inputStore = new();
    [SerializeField] PlayerActivities player;
    [SerializeField] PlayerAnim playerAnim;
    IRotate playerRotate = new Rotate();
    IMove playerMove = new PlayerMove();
    [SerializeField] PlayerMoveAnim moveAnim;
    [SerializeField] AnimID animID;
    [SerializeField] float speed;


    private void Update()
    {
        player.Rotate(playerRotate, inputStore.rotateInput.GetFaceDirect());
    }

    private void FixedUpdate()
    {
        player.Move(playerMove, inputStore.moveInput.MoveDirection(), speed);
        playerAnim.DoMoveAnim(moveAnim, inputStore.moveInput.GetCurrentMoveDirect(), speed, animID);
    }
}

[System.Serializable]
public class InputStore
{
    [SerializeField] internal MoveInput moveInput;
    [SerializeField] internal RotateInput rotateInput;
}
