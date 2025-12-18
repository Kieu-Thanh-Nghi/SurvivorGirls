using System.Collections.Generic;
using UnityEngine;

public class Character : CharacterUpdate
{
    [SerializeField] Transform CharBody;
    [SerializeField] internal Animator animator;
    [SerializeField] internal AnimID animID;
    [SerializeField] internal CharacterData characterData;
    [SerializeField] TurnAround turnAround;
    [SerializeField] Move move;
    [SerializeField] CharacterController cctrl;

    [SerializeField] Vector3 neareastEnemypos;

    //private void Start()
    //{
    //    cctrl
    //}
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, (neareastEnemypos - transform.position).normalized*4);
    }

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
        cctrl.Move(moveSpeedDirect * Time.fixedDeltaTime);
        //move.DoAct(transform, moveSpeedDirect);
        move.DoAnim(transform, animator,animID, characterData.runSpeed, characterData.moveSpeed, moveSpeedDirect);
    }

    internal virtual void CharacterRotate()
    {
        turnAround.LookAtCurrentDirect(CharBody.transform, characterData.SetFaceDirect(CharBody.transform));
    }
}

public abstract class CharacterUpdate : MonoBehaviour
{
    public abstract void DoUpdate();
    public abstract void DoFixedUpdate();
}


