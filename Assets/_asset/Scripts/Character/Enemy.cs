using UnityEngine;
using UnityEngine.AI;

public class Enemy : CharacterUpdate, ISetMovable
{
    [SerializeField] EnemyData enemyData;
    [SerializeField] Rigidbody rb;
    [SerializeField] OnlyMove move;
    [SerializeField] TurnAround turn;
    [SerializeField] NavMeshAgent moveByNav;
    [SerializeField] float velo;
    Vector3 faceDirect;
    internal Transform PlayerPos;
    NavMeshPath path;
    bool isMove = true;
    [SerializeField] bool isThereObstacle;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward);
    }
    private void Start()
    {
        PlayerPos = GamePlayCtrler.Instance.Player;
        moveByNav.updatePosition = false;
        moveByNav.updateRotation = false;
        //moveByNav.isStopped = true;
    }

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
        CharacterMove();
    }

    public override void DoUpdate()
    {
        faceDirect = enemyData.SetFaceDirect(transform.position, PlayerPos.position);
        CharacterRotate(faceDirect);
    }
    internal virtual void CharacterMove()
    {
        velo = rb.velocity.sqrMagnitude;
        if (rb.velocity.sqrMagnitude < 1)
        {
            if (Physics.Raycast(transform.position + Vector3.up * 0.85f,
                rb.transform.forward, enemyData.maxObsDetectDistance, enemyData.layerMask))
            {
                rb.velocity = Vector3.zero;
                moveByNav.isStopped = true;
                return;
            }
            else
            {
                moveByNav.isStopped = false;
            }
        }
        moveByNav.nextPosition = rb.transform.position;
        moveByNav.SetDestination(PlayerPos.position);
        path = moveByNav.path;

        if (path.corners.Length > 1)
        {
            Vector3 next = path.corners[1];

            Vector3 MoveDirect = (next - transform.position);
            MoveDirect.y = 0;
            rb.velocity = MoveDirect.normalized * enemyData.moveSpeed;
        }

        //if (!Physics.Raycast(transform.position + Vector3.up * 0.85f,
        //    transform.forward, enemyData.maxObsDetectDistance, enemyData.layerMask))
        //{
        //    if (path.corners.Length > 1)
        //    {
        //        Vector3 next = path.corners[1];
        //        transform.position = Vector3.MoveTowards(transform.position, next, enemyData.moveSpeed * Time.fixedDeltaTime);
        //    }        
        //}
    }

    internal virtual void CharacterRotate(Vector3 faceDirect)
    {
        turn.LookAtCurrentDirect(rb.transform, faceDirect);
    }

    public void SetIsMove(bool isMove)
    {
        //this.isMove = isMove;
        //if (isMove)
        //{
        //    moveByNav.isStopped = true;
        //    isThereObstacle = false;
        //}
    }
}