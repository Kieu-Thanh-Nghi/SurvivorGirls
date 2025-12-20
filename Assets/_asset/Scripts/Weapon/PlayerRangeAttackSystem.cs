using UnityEngine;
using UnityEngine.Events;

public class PlayerRangeAttackSystem : MonoBehaviour
{
    [SerializeField] internal Gun gun;
    [SerializeField] GunAbility[] gunAbilities;
    [SerializeField] internal EnemyDetecter enemyDetecter;
    [SerializeField] internal float AttackCountdown;
    float startTime;
    internal Transform body;
    internal Vector3 EnemyPos;
    internal UnityAction DoWhenAttack;

    private void Start()
    {
        startTime = Time.time;
    }
    private void Update()
    {
        if(Time.time - startTime >= AttackCountdown)
        {
            AttackLoop();
        }
    }
    void AttackLoop()
    {
        if (!gun.isLocked && enemyDetecter.GetEnemyPos(out EnemyPos))
        {
            gun.DoAttack(EnemyPos);
            DoWhenAttack?.Invoke();
            gun.DecreaseBullet();
            startTime = Time.time;
        }
    }
}
