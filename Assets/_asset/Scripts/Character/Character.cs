using System.Collections.Generic;
using UnityEngine;

public class Character : CharacterUpdate
{
    [SerializeField] internal Animator animator;
    [SerializeField] internal AnimID animID;
    [SerializeField] CharacterData characterData;
    [SerializeField] TurnAround turnAround;
    [SerializeField] Move move;

    public override void DoUpdate()
    {
        CharacterRotate();
    }

    public override void DoFixedUpdate()
    {
        CharacterMove();
    }

    internal virtual void CharacterMove()
    {
        Vector3 moveSpeedDirect = characterData.moveSpeedDirect;
        move.DoAct(transform, moveSpeedDirect);
        move.DoAnim(transform,animator,animID, characterData.runSpeed, characterData.moveSpeed, moveSpeedDirect);
    }

    internal virtual void CharacterRotate()
    {
        turnAround.LookAtCurrentDirect(transform, characterData.SetFaceDirect(transform));
    }
}

public abstract class CharacterUpdate : MonoBehaviour
{
    public abstract void DoUpdate();
    public abstract void DoFixedUpdate();
}
