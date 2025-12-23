using UnityEngine;

[System.Serializable]
public class PlayerMove : IMove
{
    public void DoMove(CharacterController characterController, Vector3 moveDirection, float Speed, float deltaTime)
    {
        Vector3 motion = moveDirection * Speed * deltaTime;
        characterController.Move(motion);
    }
}

public class Rotate : IRotate
{
    public void DoRotate(Transform character, Vector3 faceDirect)
    {
        character.forward = faceDirect;
    }
}