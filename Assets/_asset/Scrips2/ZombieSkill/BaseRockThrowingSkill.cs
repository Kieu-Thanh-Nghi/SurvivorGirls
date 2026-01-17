using UnityEngine;

public class BaseRockThrowingSkill : EnemySkill
{
    [SerializeField] protected Vector3 projectileScale = Vector3.one;
    [SerializeField] protected float projectileSpeed = 3;
    [SerializeField] protected Animator animator;
    [SerializeField] protected Enemy enemy;
    [SerializeField] protected Transform throwPos;
    [SerializeField] protected int damage = 2;

    public virtual void ActiveThrow()
    {
        enemy.SetStopMoving(true);
        animator.SetTrigger("throwTrigger");
    }

    public virtual void ThrowRock()
    {
        var aRock = GetARock();
        aRock.transform.position = throwPos.position;
        aRock.transform.localScale = projectileScale;
        var throwDirect = enemy.target.position - throwPos.position;
        throwDirect.y = 0;
        aRock.transform.forward = throwDirect;
        aRock.GetComponent<FlyingProjectile>().DoFly(projectileSpeed, damage);
    }

    protected virtual GameObject GetARock()
    {
        return EnemiesUpdate.Instance.rockPools.pool_NormalRock.Spawn(null);
    }
    public virtual void DoneThrowing()
    {
        enemy.SetStopMoving(false);
        DoWhenDone?.Invoke();
    }
}
