using System.Collections;
using UnityEngine;
using Lean.Pool;
using UnityEngine.Events;

public class ExplodeSkill : MonoBehaviour
{
    [SerializeField] GameObject BoomCount, Boom;
    [SerializeField] Transform BoomContain;
    [SerializeField] internal UnityEvent OnDoneExplode, OnTouchedTarget;
    [SerializeField] internal float CountTime;
    [SerializeField] int damage = 5;
    [SerializeField] LayerMask layerMask;
    [SerializeField] float causeDamageRadius = 0.5f;
    [SerializeField] float causeDamageDelay = 0.1f;
    [SerializeField] Collider coll;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        // Draw a wire sphere to visualize the general detection range
        Gizmos.DrawWireSphere(BoomContain.position, causeDamageRadius * BoomContain.localScale.x);
    }

    [ContextMenu("testBoom")]
    public void ActiveBoom()
    {
        StartCoroutine(TurnOnBoomCount());
    }

    private void OnEnable()
    {
        coll.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        coll.enabled = false;
        OnTouchedTarget?.Invoke();
    }
    IEnumerator TurnOnBoomCount()
    {
        BoomCount.SetActive(true);
        yield return new WaitForSeconds(CountTime);
        DoExplode();
        yield return new WaitForSeconds(causeDamageDelay);
        BoomCount.SetActive(false);
        CauseDamage();
        OnDoneExplode?.Invoke();
    }

    void DoExplode()
    {
        Boom.SetActive(true);
    }

    void CauseDamage()
    {
        var targets = Physics.OverlapSphere(BoomContain.position, causeDamageRadius * BoomContain.localScale.x, layerMask);
        foreach(var target in targets)
        {
            if(target.TryGetComponent<IDamageable>(out var damageable)){
                damageable.TakeDamage(damage, DamageType.Normal);
            }
        }
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}

public class ThrowingRockSkill : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Enemy enemy;
    [SerializeField] Transform throwPos;
    [SerializeField] float coolDown = 1;
    WaitForSeconds wait;
    bool isDoneThrow;

    private void Start()
    {
        wait = new WaitForSeconds(coolDown);
    }
    private void OnEnable()
    {
        enemy.SetStopMoving(false);
        StartCoroutine(RunThrowSkill());
    }
    IEnumerator RunThrowSkill()
    {
        while (true)
        {
            yield return wait;
            ActiveThrow();
            yield return new WaitUntil(() => isDoneThrow);
        }
    }
    void ActiveThrow()
    {
        isDoneThrow = false;
        animator.SetTrigger("throwTrigger");
    }

    public void ThrowRock()
    {
        enemy.SetStopMoving(true);
    }

    public void DoneThrowing()
    {
        enemy.SetStopMoving(false);
        isDoneThrow = true;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}

public class RockPools : MonoBehaviour
{
    [SerializeField] LeanGameObjectPool 
        pool_NormalRock;
}
