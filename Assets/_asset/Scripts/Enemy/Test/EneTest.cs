using UnityEngine;

public class EneTest : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] Transform rotateBody;
    [SerializeField] NpcMove moveManagement;
    [SerializeField] internal EnemyData enemyData;
    [SerializeField] Health health;
    IRotate rotateFuntion = new Rotate();
    [SerializeField] internal Transform target;
    internal Vector3 faceDirect;
    internal int enemyIndex;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, rb.transform.forward);
    }

    private void OnEnable()
    {
        health.CurrentHP = enemyData.health;
        ResetSpeed();
    }
    public void SetStopMoving(bool isStop) => moveManagement.SetStopMoving(isStop);
    public void SetSpeed(float theSpeed) => moveManagement.SetSpeed(theSpeed);
    public void ResetSpeed() => moveManagement.ResetSpeed(enemyData.moveSpeed);
    //private void OnEnable()
    //{
    //    moveByNav.enabled = true;
    //    //SetEnemyDestination();
    //    EnemyRotate();
    //}
    public void Move(Transform Target, bool isTargetMoveEnough)
    {
        moveManagement.Move(Target, isTargetMoveEnough);
    }
    public void Rotate(Transform target)
    {
        faceDirect = (target.position - transform.position).normalized;
        faceDirect = Vector3.Lerp(rotateBody.forward, faceDirect, 0.5f);
        rotateFuntion.DoRotate(rotateBody, faceDirect);
    }
}
