using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] internal NavMeshAgent moveByNav;
    IRotate rotateFuntion = new Rotate();
    internal Transform target;
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

    //private void OnEnable()
    //{
    //    moveByNav.enabled = true;
    //    //SetEnemyDestination();
    //    EnemyRotate();
    //}
    public void SetEnemyDestination()
    {
        moveByNav.SetDestination(target.position);
    }
    public void EnemyRotate()
    {
        faceDirect = (target.position - transform.position).normalized;
        rotateFuntion.DoRotate(rb.transform, faceDirect);
    }

    private void OnDisable()
    {
        target = GamePlayCtrler.Instance.Player;
    }
}
