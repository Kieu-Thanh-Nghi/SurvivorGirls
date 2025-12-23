using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PistolSkill_Training : MonoBehaviour, IEachAtkObserver
{
    WaitForSeconds waitForSeconds = new WaitForSeconds(0.1f);
    [SerializeField] internal int TimesToShoot;
    IWeapon weapon; 
    IEnemyDetecter detecter;
    IHasTarget hasTarget;
    IAttackObserver attackListener;
    internal UnityAction DoWhenDoneAnAtk;

    private void Start()
    {
        weapon = GetComponent<IWeapon>();
        detecter = GetComponent<IEnemyDetecter>();
        hasTarget = GetComponent<IHasTarget>();
        attackListener = GetComponent<IAttackObserver>();
        SetUpSkill();
    }
    public void SetUpSkill()
    {
        attackListener.SubscribeAtkEvent(DoSkill);
    }
    public void DoSkill()
    {
        StartCoroutine(ShootMultiple(weapon, detecter, hasTarget));
    }

    IEnumerator ShootMultiple(IWeapon weapon, IEnemyDetecter detecter, IHasTarget hasTarget)
    {
        Vector3 thisPos = transform.position;
        Transform currentTarget = hasTarget.GetCurrentTarget();
        Vector3 EnemyPos = currentTarget.position;
        for (int i = 0; i < TimesToShoot; i++)
        {
            yield return waitForSeconds;
            if ((currentTarget == null || !currentTarget.gameObject.activeSelf)
                && detecter.GetNearestEnemy(thisPos, out currentTarget))
            {
                EnemyPos = currentTarget.position;  
            }
            weapon.DoOneAttack(EnemyPos);
            DoWhenDoneAnAtk?.Invoke();
        }
    }

    public void SubscribeOnlyOneShotEvent(UnityAction WhenOneAttack)
    {
        DoWhenDoneAnAtk += WhenOneAttack;
    }
}
