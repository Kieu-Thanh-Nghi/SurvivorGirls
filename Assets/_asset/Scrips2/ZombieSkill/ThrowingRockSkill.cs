using System.Collections;
using UnityEngine;

public class ThrowingRockSkill : BaseRockThrowingSkill
{
    WaitForSeconds wait;
    bool isDoneThrow;

    private void Awake()
    {
        wait = new WaitForSeconds(coolDown);
    }

    protected void OnEnable()
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

    public override void ActiveThrow()
    {
        isDoneThrow = false;
        base.ActiveThrow();
    }

    public override void DoneThrowing()
    {
        base.DoneThrowing();
        isDoneThrow = true;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
