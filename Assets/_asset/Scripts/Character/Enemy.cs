using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] Transform rotateBody;
    [SerializeField] internal NavMeshAgent moveByNav;
    [SerializeField] internal EnemyData enemyData;
    [SerializeField] Health health;
    IRotate rotateFuntion = new Rotate();
    internal Transform target;
    internal Vector3 faceDirect;
    internal int enemyIndex;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, rb.transform.forward);
    }

    private void OnEnable()
    {
        health.currentHP = enemyData.health;
        ResetSpeed();
    }
    private void Start()
    {
        moveByNav.updateRotation = false;
    }

    public void SetSpeed(float theSpeed)
    {
        moveByNav.speed = theSpeed;
    }
    public void ResetSpeed()
    {
        moveByNav.speed = enemyData.moveSpeed;
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
        faceDirect = Vector3.Lerp(rotateBody.forward, faceDirect, 0.5f);
        rotateFuntion.DoRotate(rotateBody, faceDirect);
    }

    private void OnDisable()
    {
        target = GamePlayCtrler.Instance.Player;
    }
}
