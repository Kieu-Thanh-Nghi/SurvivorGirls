using UnityEngine;
using Lean.Pool;

public class IceEff : Effect
{
    internal IMoveFreezing moveFreezing;

    protected virtual void OnEnable()
    {
        effectRunner.totalTime = totalTime;
        Transform thisParent = transform.parent;
        if(thisParent.TryGetComponent(out moveFreezing))
        {
            StartCoroutine(effectRunner.ActiveEff(DoIceEff, EndIceEff));
        }
    }
    protected virtual void DoIceEff()
    {
        moveFreezing.SetIsMoveFreeze(true);
    }

    protected virtual void EndIceEff()
    {
        moveFreezing.SetIsMoveFreeze(false);
        LeanPool.Despawn(gameObject);
    }

    protected override void EndEff()
    {
        EndIceEff();
    }
}
