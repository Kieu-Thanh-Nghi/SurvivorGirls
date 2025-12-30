using Lean.Pool;
using UnityEngine;

public class EnemyDead : MonoBehaviour
{
    [SerializeField] Enemy thisEnemy;
    public void KillEnemy()
    {
        var eneUpd = EnemiesUpdate.Instance;
        eneUpd.RemoveAnEnemy(thisEnemy);
        eneUpd.EnemyDeadEff.Spawn(transform.position);

        LeanPool.Despawn(gameObject);
    }
}
