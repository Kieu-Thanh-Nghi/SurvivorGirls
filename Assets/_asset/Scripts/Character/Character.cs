using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] internal Transform allBody;
    [SerializeField] internal Animator animator;
    [SerializeField] internal AnimID animID;
    [SerializeField] CharacterData characterData;
    [SerializeField] TurnAround turnAround;
    [SerializeField] Move move;

    private void Update()
    {
        CharacterRotate();
    }

    private void FixedUpdate()
    {
        CharacterMove();
    }

    internal virtual void CharacterMove()
    {
        move.SetValue(characterData.moveSpeed);
        move.DoAct(transform);
        move.DoAnim(transform,animator,animID, characterData.runSpeed, characterData.moveSpeed);
    }

    internal virtual void CharacterRotate()
    {
        turnAround.SetValue(transform);
        turnAround.LookAtCurrentDirect(transform);
    }
}
