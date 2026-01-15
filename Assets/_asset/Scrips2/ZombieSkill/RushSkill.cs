using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Collections;

public class RushSkill : EnemySkill
{
    [SerializeField] Transform self;
    [SerializeField] SphereCollider coll;
    [SerializeField] ParticleSystem DashMaker;
    [SerializeField] float markerScaleTime = 1.5f;
    [SerializeField] float rushTime = 1.5f;

    protected void OnEnable()
    {
        coll.enabled = true;
    }
    protected void OnTriggerStay(Collider other)
    {
        coll.enabled = false;
        Vector3 targetPos = other.transform.position;
        DashMaker.gameObject.SetActive(true);
        float distance = CalculateDistanceToTarget(targetPos);
        Sequence doingSkill = DoSkill(targetPos, distance);
        AfterSkill(doingSkill);
    }

    protected virtual Sequence DoSkill(Vector3 targetPos, float distance)
    {
        return DOTween.Sequence()
            .Append(DashMaker.transform.DOScaleX(distance, markerScaleTime)
                .OnComplete(() =>
                {
                    DashMaker.gameObject.SetActive(false);
                    DashMaker.transform.localScale = Vector3.one;
                }))
            .Append(self.DOMove(targetPos, rushTime));
    }

    protected virtual float CalculateDistanceToTarget(Vector3 targetPos)
    {
        return (transform.position - targetPos).magnitude;
    }

    protected virtual void AfterSkill(Sequence doingSkill)
    {
        doingSkill.AppendInterval(coolDown).OnComplete(() => EndSkill());
    }

    protected virtual void EndSkill()
    {
        coll.enabled = true;
    }
}

public class BossRushSkill : RushSkill
{
    protected override void AfterSkill(Sequence doingSkill)
    {
        doingSkill.OnComplete(() => gameObject.SetActive(false));
    }
}

public class EnemySkill : MonoBehaviour
{
    [SerializeField] internal float coolDown = 3;
    internal virtual void ActiveSkill()
    {
        gameObject.SetActive(true);
    } 
}
public class BossSkillManager : MonoBehaviour
{
    [SerializeField] EnemySkill[] enemySkills;
    [SerializeField] Enemy enemySelf;
    
    IEnumerator DoSkills()
    {
        foreach(var enemySkill in enemySkills)
        {
            enemySkill.ActiveSkill();
            yield return new WaitUntil(() => enemySkill.gameObject.activeSelf == false);
            yield return new WaitForSeconds(enemySkill.coolDown);
        }
    }
}
