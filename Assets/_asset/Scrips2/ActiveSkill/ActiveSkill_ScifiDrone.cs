using UnityEngine;
using DG.Tweening;
using System.Collections;

public class ActiveSkill_ScifiDrone : UpdateSkill
{
    [SerializeField] Vector3 stablePosition;
    [SerializeField] float timeToFlyToStablePosition = 1;
    [SerializeField] internal float fireRate = 4;
    [SerializeField] internal int damage = 1;
    float timeBetweenShots => 1 / fireRate;
    [SerializeField] INearestDetecter nearestDetecter;    
    Transform target;
    Vector3 direction;

    protected override void Start()
    {
        transform.DOLocalMove(stablePosition, timeToFlyToStablePosition);
        nearestDetecter = GetComponent<INearestDetecter>();
        base.Start();
        //StartCoroutine(StartSkill());
    }
    public override void DoUpdate()
    {
        if (isActive)
        {
            FireNearestEnemy();
        }
    }

    void FireNearestEnemy()
    {
        if (target == null || !target.gameObject.activeSelf)
        {
            if (nearestDetecter.GetNearest(transform.position, out Transform result))
            {
                target = result;
            }
        }
        else
        {
            Attack();
        }
    }

    void Attack()
    {
        direction = (transform.position - target.position).normalized;
        transform.forward = direction;
    }
}
