using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RushSkill : MonoBehaviour
{
    [SerializeField] Transform self;
    [SerializeField] SphereCollider coll;
    [SerializeField] ParticleSystem DashMaker;
    [SerializeField] internal float coolDown = 3;

    private void OnEnable()
    {
        coll.enabled = true;
    }
    private void OnTriggerStay(Collider other)
    {
        coll.enabled = false;
        Vector3 targetPos = other.transform.position;
        DashMaker.gameObject.SetActive(true);
        float distance = CalculateDistanceToTarget(targetPos);
        DOTween.Sequence()
        .Append(DashMaker.transform.DOScaleX(distance, 1.5f)
            .OnComplete(() => { 
                DashMaker.gameObject.SetActive(false);
                DashMaker.transform.localScale = Vector3.one;
            }))
        .Append(self.DOMove(targetPos, 1.5f))
        .OnComplete(() => {
            Invoke(nameof(endSkill), coolDown);
        });
    }

    float CalculateDistanceToTarget(Vector3 targetPos)
    {
        return (transform.position - targetPos).magnitude;
    }
    
    void endSkill()
    {
        coll.enabled = true;
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
