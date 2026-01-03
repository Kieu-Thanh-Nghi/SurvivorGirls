using UnityEngine;
using DG.Tweening;

public class ActiveSkill_ScifiDrone : UpdateSkill, IHasDamage
{
    [SerializeField] Vector3 stablePosition;
    [SerializeField] float timeToFlyToStablePosition = 1;
    [SerializeField] internal float fireRate = 4;
    [SerializeField] internal int damage = 1;
    float timeBetweenShots => 1 / fireRate;
    float startShotTime;
    [SerializeField] INearestDetecter nearestDetecter;
    [SerializeField] IWeapon weapon;
    [SerializeField] Transform target;
    Vector3 direction;

    protected override void Start()
    {
        transform.DOLocalMove(stablePosition, timeToFlyToStablePosition);
        nearestDetecter = GetComponent<INearestDetecter>();
        weapon = GetComponent<IWeapon>();
        base.Start();
        StartCoroutine(StartSkill());
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
        if (target != null
            && target.gameObject.activeInHierarchy)
        {
            if(Time.time - startShotTime >= timeBetweenShots)
            {
                Attack();
                startShotTime = Time.time;
            }
            return;
        }
        if (nearestDetecter.GetNearest(transform.position, out Transform result))
        {
            target = result;
        }
    }

    protected override void BeforeActiveSkill()
    {
        startShotTime = Time.time;
        base.BeforeActiveSkill();
    }
    void Attack()
    {
        direction = transform.position - target.position;
        direction.y = 0;
        transform.forward = direction;
        weapon.DoOneAttack(target.position);
    }

    public int GetDamage() => damage;
}
