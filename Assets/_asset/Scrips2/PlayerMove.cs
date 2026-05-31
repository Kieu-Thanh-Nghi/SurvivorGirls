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
        faceDirect = Vector3.Lerp(character.forward, faceDirect.normalized, 0.5f);
        character.forward = faceDirect;
    }
}