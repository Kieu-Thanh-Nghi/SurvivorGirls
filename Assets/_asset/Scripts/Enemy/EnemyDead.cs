using Lean.Pool;
using UnityEngine;

public class EnemyDead : MonoBehaviour
{
    [SerializeField] Enemy thisEnemy;
    public void KillEnemy()
    {
        var ctrler = GamePlayCtrler.Instance;
        ctrler.RemoveAnEnemy(thisEnemy);
        ctrler.EnemyDeadEff.Spawn(transform.position);

        LeanPool.Despawn(gameObject);
    }
}
