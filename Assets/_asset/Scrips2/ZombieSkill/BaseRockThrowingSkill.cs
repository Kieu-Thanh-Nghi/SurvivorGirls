using UnityEngine;

public class BaseRockThrowingSkill : EnemySkill
{
    [SerializeField] RockData rockData;
    RockType rockType => rockData.rockType;
    protected Vector3 projectileScale => rockData.projectileScale;
    protected float projectileSpeed => rockData.projectileSpeed;
    protected int damage => rockData.damage;

    [SerializeField] protected Animator animator;
    [SerializeField] protected Enemy enemy;
    [SerializeField] protected Transform throwPos;

    public virtual void ActiveThrow()
    {
        enemy.SetStopMoving(true, false);
        animator.SetTrigger("throwTrigger");
    }

    public virtual void ThrowRock()
    {
        Debug.Log("ss1");
        var aRock = GetARock();
        aRock.transform.position = throwPos.position;
        aRock.transform.localScale = projectileScale;
        var throwDirect = enemy.Target.position - throwPos.position;
        throwDirect.y = 0;
        aRock.transform.forward = throwDirect;
        aRock.GetComponent<FlyingProjectile>().DoFly(rockData, damage);
    }

    protected virtual GameObject GetARock()
    {
        return EnemiesUpdate.Instance.rockPools.GetRockPool(rockType).Spawn(null);
    }
    public virtual void DoneThrowing()
    {
        Debug.Log("done throwing");
        enemy.SetStopMoving(false);
        DoWhenDone?.Invoke();
    }
}
