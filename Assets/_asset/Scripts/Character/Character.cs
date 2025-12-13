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

    [SerializeField] Vector3 neareastEnemypos;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, (neareastEnemypos - transform.position).normalized*4);
    }


    private void Update()
    {
        DoUpdate();
    }
    private void FixedUpdate()
    {
        DoFixedUpdate();
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
        move.DoAct(CharBody.transform, moveSpeedDirect);
        move.DoAnim(CharBody.transform, animator,animID, characterData.runSpeed, characterData.moveSpeed, moveSpeedDirect);
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


