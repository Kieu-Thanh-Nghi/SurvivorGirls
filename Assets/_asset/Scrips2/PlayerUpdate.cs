using System.Collections;
using UnityEngine;

public class PlayerUpdate : MonoBehaviour
{
    [SerializeField] LevelManager levelManager;
    [SerializeField] InputStore inputStore = new();
    [SerializeField] PlayerActivities player;
    [SerializeField] PlayerAnim playerAnim;
    IRotate playerRotate = new Rotate();
    IMove playerMove = new PlayerMove();
    [SerializeField] PlayerMoveAnim moveAnim;
    [SerializeField] AnimID animID;
    [SerializeField] Vector3 expScale = Vector3.one;

    internal Vector3 ExpScale { 
        get { return expScale; }
        set
        {
            expScale = value;
            levelManager.transform.localScale = value;
        }
    }
    float speed => PlayerDataManager.Instance.MoveSpeed;

    private void Start()
    {
        levelManager.transform.localScale = ExpScale;
    }
    private void Update()
    {
        player.Rotate(playerRotate, inputStore.rotateInput.GetFaceDirect());
    }

    private void FixedUpdate()
    {
        var moveInput = inputStore.moveInput;
        player.Move(playerMove, moveInput.MoveDirection(), speed);
        playerAnim.DoMoveAnim(moveAnim, moveInput.GetCurrentMoveDirect(), speed, animID);
    }
}

[System.Serializable]
public class InputStore
{
    [SerializeField] internal MoveInput moveInput;
    [SerializeField] internal RotateInput rotateInput;
}
