using UnityEngine;
using DG.Tweening;

public class BaseRushSkill : EnemySkill
{
    [SerializeField] protected Transform self;
    [SerializeField] protected ParticleSystem DashMaker;
    [SerializeField] protected SphereCollider coll;
    [SerializeField] protected float markerScaleTime = 1.5f;
    [SerializeField] protected float rushTime = 1.5f;
    [SerializeField] protected Enemy EnemyBody;

    protected virtual void OnTriggerStay(Collider other)
    {
        EnemyBody.SetStopMoving(true, false);
        coll.enabled = false;
        Vector3 targetPos = other.transform.position;
        DashMaker.gameObject.SetActive(true);
        float distance = CalculateDistanceToTarget(targetPos);
        Sequence doingSkill = DoSkill(MarkerScaleUp(distance), Rush(targetPos));
        AfterSkill(doingSkill);
    }

    protected virtual Sequence DoSkill(Tween markerScaleUp, Tween rush)
    {
        return DOTween.Sequence()
            .Append(markerScaleUp)
            .Append(rush);
    }

    protected virtual Tween MarkerScaleUp(float distance)
    {
        return DashMaker.transform.DOScaleX(distance, markerScaleTime)
                .OnComplete(() =>
                {
                    DashMaker.gameObject.SetActive(false);
                    var scale = DashMaker.transform.localScale;
                    scale.x = 1;
                    DashMaker.transform.localScale = scale;
                });
    }  

    protected virtual Tween Rush(Vector3 targetPos)
    {
        return self.DOMove(targetPos, rushTime).OnComplete(() => EnemyBody.SetStopMoving(false, false));
    }  

    protected virtual float CalculateDistanceToTarget(Vector3 targetPos)
    {
        return (transform.position - targetPos).magnitude;
    }

    protected virtual void AfterSkill(Sequence doingSkill)
    {
        doingSkill.OnComplete(() => { EndSkill(); DoWhenDone?.Invoke();  });
    }
    protected virtual void EndSkill()
    {
        coll.enabled = true;
    }
}
