using System.Collections;
using UnityEngine;

public class ThrowingRockSkill : MonoBehaviour
{
    [SerializeField] Vector3 projectileScale = Vector3.one;
    [SerializeField] float projectileSpeed = 3;
    [SerializeField] Animator animator;
    [SerializeField] Enemy enemy;
    [SerializeField] Transform throwPos;
    [SerializeField] float coolDown = 1;
    [SerializeField] int damage = 2;
    WaitForSeconds wait;
    bool isDoneThrow;

    private void Awake()
    {
        wait = new WaitForSeconds(coolDown);
    }
    private void OnEnable()
    {
        //enemy.SetStopMoving(false);
        StartCoroutine(RunThrowSkill());
    }
    IEnumerator RunThrowSkill()
    {
        while (true)
        {
            Debug.Log("a");
            yield return wait;

            ActiveThrow();
            yield return new WaitUntil(() => isDoneThrow);
        }
    }
    void ActiveThrow()
    {
        Debug.Log("b");

        isDoneThrow = false;
        animator.SetTrigger("throwTrigger");
    }

    public void ThrowRock()
    {
        //enemy.SetStopMoving(true);
        var aRock = EnemiesUpdate.Instance.rockPools.pool_NormalRock.Spawn(null);
        aRock.transform.position = throwPos.position;
        aRock.transform.localScale = projectileScale;
        var throwDirect = enemy.target.position - throwPos.position;
        throwDirect.y = 0;
        aRock.transform.forward = throwDirect;
        aRock.GetComponent<FlyingProjectile>().DoFly(projectileSpeed, damage);
    }

    public void DoneThrowing()
    {
        //enemy.SetStopMoving(false);
        isDoneThrow = true;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
