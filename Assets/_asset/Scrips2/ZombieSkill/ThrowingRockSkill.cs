using System.Collections;
using UnityEngine;

public class ThrowingRockSkill : BaseRockThrowingSkill
{
    protected WaitForSeconds wait;
    protected bool isDoneThrow;

    private void Awake()
    {
        wait = new WaitForSeconds(coolDown);
    }

    protected virtual void OnEnable()
    {
        enemy.SetStopMoving(false);
        StartCoroutine(RunThrowSkill());
    }
    protected virtual IEnumerator RunThrowSkill()
    {
        while (true)
        {
            yield return wait;
            ActiveThrow();
            yield return new WaitUntil(() => isDoneThrow);
        }
    }

    public override void ActiveThrow()
    {
        isDoneThrow = false;
        base.ActiveThrow();
    }

    public override void DoneThrowing()
    {
        Debug.Log("ss2");
        base.DoneThrowing();
        isDoneThrow = true;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
