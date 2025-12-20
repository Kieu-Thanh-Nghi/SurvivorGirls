using System.Collections;
using UnityEngine;

public class SkillTraining : GunAbility
{
    WaitForSeconds waitForSeconds = new WaitForSeconds(0.1f);
    [SerializeField] PlayerRangeAttackSystem RAS;
    [SerializeField] int TimesToShoot;

    private void Start()
    {
        RAS = GetComponent<PlayerRangeAttackSystem>();
        SetUpSkill();
    }
    public override void SetUpSkill()
    {
        RAS.DoWhenAttack += DoSkill;
    }
    public override void DoSkill()
    {
        StartCoroutine(ShootMultiple(RAS.gun, RAS.enemyDetecter, RAS.transform));
    }

    IEnumerator ShootMultiple(Gun gun, EnemyDetecter enemyDetecter, Transform body)
    {
        Vector3 EnemyPos = enemyDetecter.target.position;
        for (int i = 0; i < TimesToShoot; i++)
        {
            yield return waitForSeconds;
            if (enemyDetecter.GetEnemyPos(out var EnePos))
            {
                gun.DoAttack(EnePos);
            }
            else
            {
                gun.DoAttack(EnemyPos);
            }
        }
    }
}
