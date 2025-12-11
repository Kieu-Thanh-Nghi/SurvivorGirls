using UnityEngine;
using UnityEngine.AI;

public class Enemy : CharacterUpdate
{
    [SerializeField] EnemyData enemyData;
    [SerializeField] Rigidbody rb;
    [SerializeField] OnlyMove move;
    [SerializeField] TurnAround turn;
    [SerializeField] NavMeshAgent moveByNav;
    [SerializeField] float velo;
    [SerializeField] EnemyCollider eneCol;
    Vector3 faceDirect;
    internal Transform PlayerPos;
    internal bool isRayCheck = true;
    NavMeshPath path;
    bool isMove = true;
    [SerializeField] bool isThereObstacle;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, rb.transform.forward);
    }
    private void Awake()
    {
        PlayerPos = GamePlayCtrler.Instance.Player;
    }

    private void OnEnable()
    {
        moveByNav.enabled = true;
        SetAgentVelocity();
    }
    private void Start()
    {
        moveByNav.updatePosition = false;
        moveByNav.updateRotation = false;
        //moveByNav.isStopped = true;
    }

    //private void Update()
    //{
    //    DoUpdate();
    //}
    //private void FixedUpdate()
    //{
    //    DoFixedUpdate();
    //}
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
        if (!isRayCheck) return;
        if (rb.velocity.sqrMagnitude < 1)
        {
            if (Physics.Raycast(transform.position + Vector3.up * 0.85f,
                rb.transform.forward, enemyData.maxObsDetectDistance, enemyData.layerMask))
            {
                eneCol.isCheck = true;
                isRayCheck = false;
                rb.velocity = GetVel(enemyData.speedBehind);
                moveByNav.isStopped = true;
                return;
            }
            else
            {
                moveByNav.isStopped = false;
            }
        }
        SetAgentVelocity();

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

    void SetAgentVelocity()
    {
        moveByNav.nextPosition = rb.transform.position;
        moveByNav.SetDestination(PlayerPos.position);
        path = moveByNav.path;
        
        rb.velocity = GetVel(enemyData.moveSpeed);
    }

    Vector3 GetVel(float speed)
    {
        if (path.corners.Length > 1)
        {
            Vector3 next = path.corners[1];

            Vector3 MoveDirect = (next - transform.position);
            MoveDirect.y = 0;
            return MoveDirect.normalized * speed;
        }
        else
        {
            return Vector3.zero;
        }
    }

    internal virtual void CharacterRotate(Vector3 faceDirect)
    {
        turn.LookAtCurrentDirect(rb.transform, faceDirect);
    }
}
