using UnityEngine;
using UnityEngine.AI;

public class NpcMove : MonoBehaviour
{
    [SerializeField] bool isObsTouching;
    bool isStop;
    [SerializeField] NavMeshAgent moveByNav;
    [SerializeField] float ChangeMoveStrategyDelayTime = 1;
    float ChangeMoveDelayCounting = 1;

    float _speed;
    internal float Speed
    {
        get => _speed;
        set
        {
            _speed = value;
            moveByNav.speed = value;
        }
    }

    private void Start()
    {
        moveByNav.updateRotation = false;
    }
    public void SetTarget(Transform Target)
    {
        if(moveByNav.enabled) moveByNav.SetDestination(Target.position);
    }

    public void OnOffNav(bool isOn)
    {
        moveByNav.enabled = isOn;
    }

    public void MoveStraight(Vector3 targetPos)
    {
        moveByNav.transform.position = Vector3.MoveTowards(transform.position, targetPos, Speed * Time.deltaTime);
    }

    public void SetStopMoving(bool isStop)
    {
        if(moveByNav.enabled) moveByNav.isStopped = isStop;
        this.isStop = isStop;
    }
    public void SetSpeed(float theSpeed)
    {
        Speed = theSpeed;
    }
    public void ResetSpeed(float defaultSpeed)
    {
        Speed = defaultSpeed;
    }
    public void Move(Transform Target, bool isTargetMoveEnough)
    {
        if (isStop) return;
        if (ChangeMoveDelayCounting < ChangeMoveStrategyDelayTime)
        {
            if (isTargetMoveEnough && moveByNav.isOnNavMesh) moveByNav.SetDestination(Target.position);
            ChangeMoveDelayCounting += Time.deltaTime;
            if(ChangeMoveDelayCounting > ChangeMoveStrategyDelayTime)
            {
                if (!isObsTouching)
                {
                    OnOffNav(false);
                }
                else
                {
                    ChangeMoveDelayCounting = 0;
                }
            }
        }
        else
        {
            MoveStraight(Target.position);
        }
    }
    public void ResetMoveMechanic()
    {
        isObsTouching = false;
        OnOffNav(false);
    }
    public void OnTouchedObs(Transform target, bool isTouch)
    {
        isObsTouching = isTouch;
        if (isTouch)
        {
            Debug.Log("obs touched");
            OnOffNav(true);
            if(moveByNav.isOnNavMesh) moveByNav.SetDestination(target.position);
            ChangeMoveDelayCounting = 0;
        }
    }
    private void OnDisable()
    {
        ResetMoveMechanic();
    }
}
