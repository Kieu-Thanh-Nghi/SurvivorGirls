using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] internal float powerBuff = 1;
    [SerializeField] internal float speedBuff = 1;
    [SerializeField] internal float healthBuff = 1;
    [SerializeField] Health health;
    [SerializeField] HasHurtDamage hasHurtDamage;
    [SerializeField] internal EnemyData enemyData;
    internal float DefaultSpeed => speedBuff * enemyData.moveSpeed;
    internal int DefaultHealth => Mathf.CeilToInt(powerBuff * healthBuff * enemyData.health);
    internal int DefaultDamage => Mathf.CeilToInt(powerBuff * enemyData.damage);

    [Header("about rotate")]
    [SerializeField] Transform rotateBody;
    IRotate rotateFuntion = new Rotate();
    bool isStopRotate;

    [Header("about move")]
    [SerializeField] internal NpcMove moveManagement;

    [Header("about animation")]
    [SerializeField] internal CharAnimManagement animPlayer;

    internal Transform target;
    internal Transform Target
    {
        get => target;
        set
        {
            target = value;
            moveManagement.SetTarget(value);
        }
    }
    internal Vector3 faceDirect;
    internal int enemyIndex;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, rb.transform.forward);
    }

    private void Start()
    {
        hasHurtDamage.damage = DefaultDamage;
    }
    private void OnEnable()
    {
        health.CurrentHP = DefaultHealth;
        health.MaxHP = DefaultHealth;
        EnemyMove();
        SetStopMoving(false);
        ResetSpeed();
    }
    //private void Start()
    //{
    //    moveByNav.updateRotation = false;
    //}

    //public void SetStopMoving(bool isStop)
    //{
    //    moveByNav.isStopped = isStop;
    //}
    //public void SetSpeed(float theSpeed)
    //{
    //    moveByNav.speed = theSpeed;
    //}
    //public void ResetSpeed()
    //{
    //    moveByNav.speed = enemyData.moveSpeed;
    //}
    public void SetStopMoving(bool isStop, bool isStopAnim = true, bool isChangeRotate = true)
    {
        moveManagement.SetStopMoving(isStop);
        if(isChangeRotate) isStopRotate = isStop;
        if(isStopAnim) animPlayer.SetStopCurrentAnim(isStop);
    }
    public void SpeedMultiply(float amount)
    {
        float newSpeed = DefaultSpeed * amount;
        moveManagement.SetSpeed(newSpeed);
        animPlayer.Speed *= amount;
    }
    public void ResetSpeed()
    {
        moveManagement.ResetSpeed(DefaultSpeed);
        animPlayer.Speed = speedBuff;
    }
    public void EnemyMove(bool isTargetMoveEnough = false)
    {
        if (Target == null) return;
        if (Target == GamePlayCtrler.Instance.Player && isTargetMoveEnough)
        {
            moveManagement.Move(Target, true);
        }
        else
        {
            moveManagement.Move(Target, false);
        }
        animPlayer?.UpdateAnimFrame();
    }

    //private void OnEnable()
    //{
    //    moveByNav.enabled = true;
    //    //SetEnemyDestination();
    //    EnemyRotate();
    //}

    public void EnemyRotate()
    {
        if (isStopRotate) return;
        faceDirect = (Target.position - transform.position).normalized;
        faceDirect.y = 0;
        faceDirect = Vector3.Lerp(rotateBody.forward, faceDirect, 0.5f);
        rotateFuntion.DoRotate(rotateBody, faceDirect);
    }

    private void OnDisable()
    {
        Target = GamePlayCtrler.Instance.Player;
    }
}

public interface IObsTouching
{
    public void SetTouchObs(bool isTouch);
}