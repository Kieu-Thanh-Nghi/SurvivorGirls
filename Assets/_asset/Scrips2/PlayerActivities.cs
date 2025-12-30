using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActivities : MonoBehaviour
{
    [SerializeField] CharacterController characterController;
    [SerializeField] Transform rotateBody;
    
    public void Move(IMove playerMove, Vector3 moveDirection, float speed)
    {
        playerMove.DoMove(characterController, moveDirection, speed, Time.fixedDeltaTime);
    }

    public void Rotate(IRotate playerRotate, Vector3 faceDirect)
    {
        playerRotate.DoRotate(rotateBody, faceDirect);
    }
}

public interface IMoveAnim
{
    public void DoAnim(Animator animator, AnimID animID, float moveSpeed, Vector3 moveDirect);
}
