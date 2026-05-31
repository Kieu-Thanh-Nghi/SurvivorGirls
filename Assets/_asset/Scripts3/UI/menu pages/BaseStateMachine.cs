using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseStateMachine : MonoBehaviour
{
    internal AbstractState currentState;
    [SerializeField] internal AbstractState startStage;

    protected virtual void Start()
    {
        currentState = startStage;
        startStage?.Enter();
    }

    public virtual void ChangeState(AbstractState newState)
    {
        if(currentState != null)
        {
            if (newState == currentState) return;
            Debug.Log("PageChange: before change");
            currentState.Exit();
        }
        currentState = newState;
        newState?.Enter();
        Debug.Log("PageChange: do change");
    }
}

public abstract class AbstractState : MonoBehaviour
{
    [SerializeField] BaseStateMachine pageStateMachine;
    protected virtual void OnValidate()
    {
        if (pageStateMachine != null) return;
        pageStateMachine = GetComponentInParent<BaseStateMachine>();
    }
    public void DoChangePage()
    {
        pageStateMachine.ChangeState(this);
    }
    public abstract void Enter();
    public abstract void Exit();
}