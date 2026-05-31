using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class AttackStrategy_DetectContinuous : Attack_SphereDetect
{
    WaitForSeconds waitForSeconds;
    [SerializeField] float betweenShotsDuration = 0.22f;
    internal int TimesToShoot = 1;

    private void Start()
    {
        waitForSeconds = new WaitForSeconds(betweenShotsDuration);
    }

    public IEnumerator AttackCoroutine(IHasEneDetecter hasEneDetecter,
        Transform rotateBody,
        AWeapon weapon,
        UnityAction DoWhenDoneAnAtk = null)
    {
        for (int i = 0; i < TimesToShoot; i++)
        {
            Attack(hasEneDetecter, rotateBody, weapon, DoWhenDoneAnAtk);
            yield return waitForSeconds;
        }
    }
}