using UnityEngine;
using DG.Tweening;

public class BossRushSkill : BaseRushSkill
{
    [SerializeField] Transform RushTo;
    [SerializeField] Animator animator;
    protected override void OnTriggerStay(Collider other)
    {
        EnemyBody.SetStopMoving(true, false);
        animator.SetBool("IsRush", true);
        coll.enabled = false;
        DashMaker.gameObject.SetActive(true);
        Sequence doingSkill = DoSkill(MarkerScaleUp(0), Rush(RushTo.position));
        AfterSkill(doingSkill);
    }
    protected override Tween MarkerScaleUp(float distance)
    {
        return DOVirtual.DelayedCall(markerScaleTime, () =>
        {
            DashMaker.gameObject.SetActive(false);
        });
    }
    protected override void EndSkill()
    {
        animator.SetBool("IsRush", false);
        base.EndSkill();
    }
}
