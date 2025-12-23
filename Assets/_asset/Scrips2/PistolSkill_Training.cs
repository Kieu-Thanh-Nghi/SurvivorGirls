using System.Collections;
using UnityEngine;

public class PistolSkill_Training : MonoBehaviour
{
    WaitForSeconds waitForSeconds = new WaitForSeconds(0.1f);
    [SerializeField] int TimesToShoot;
    IWeapon weapon; 
    IEnemyDetecter detecter;
    IHasTarget hasTarget;
    IAttackObserver attackListener;

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
        }
    }
}
