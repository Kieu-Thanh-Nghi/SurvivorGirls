using UnityEngine;

public class Enemy : CharacterUpdate
{
    [SerializeField] CharacterData characterData;
    [SerializeField] PlayerDetecter playerDetecter;
    [SerializeField] OnlyMove move;
    [SerializeField] TurnAround turn;
    Vector3 faceDirect;

    private void Update()
    {
        DoUpdate();
    }
    private void FixedUpdate()
    {
        DoFixedUpdate();
    }
    public override void DoFixedUpdate()
    {
        CharacterMove(faceDirect);
    }

    public override void DoUpdate()
    {
        faceDirect = playerDetecter.DirectToPlayer().normalized;
        CharacterRotate(faceDirect);
    }

    internal virtual void CharacterMove(Vector3 faceDirect)
    {
        move.DoAct(transform, faceDirect * characterData.moveSpeed);
    }

    internal virtual void CharacterRotate(Vector3 faceDirect)
    {
        turn.LookAtCurrentDirect(transform, faceDirect);
    }
}
