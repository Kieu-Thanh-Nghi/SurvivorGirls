using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] EnemyData enemyData;
    [SerializeField] Rigidbody rb;
    [SerializeField] TurnAround turn;
    [SerializeField] internal NavMeshAgent moveByNav;
    internal Vector3 faceDirect;
    internal int enemyIndex;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, rb.transform.forward);
    }
    private void Start()
    {
        moveByNav.updateRotation = false;
    }

    private void OnEnable()
    {
        moveByNav.enabled = true;

        Vector3 PlayerPos = GamePlayCtrler.Instance.Player.position;
        moveByNav.SetDestination(PlayerPos);
        CharacterRotate(PlayerPos);
    }
    internal virtual void CharacterRotate(Vector3 targetPos)
    {
        faceDirect = targetPos - transform.position;
        turn.LookAtCurrentDirect(rb.transform, faceDirect);
    }
}
