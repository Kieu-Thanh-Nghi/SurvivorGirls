using Lean.Pool;
using UnityEngine;

public class BombEnemyDead : MonoBehaviour
{
    [SerializeField] Enemy thisEnemy;
    [SerializeField] GameObject enemyCollider;
    [SerializeField] GameObject enemyAvatar;
    [SerializeField] ExplodeSkill explodeSkill;
    [SerializeField] float DespawnDelayTime = 1;

    private void Start()
    {
        explodeSkill.OnDoneExplode.AddListener(AfterEplode);
    }
    private void OnEnable()
    {
        enemyAvatar.SetActive(true);
        enemyCollider.SetActive(true);
    }
    public void KillEnemy()
    {
        //var eneUpd = EnemiesUpdate.Instance;
        //eneUpd.RemoveAnEnemy(thisEnemy);
        thisEnemy.SetStopMoving(true);
        enemyCollider.SetActive(false);
        explodeSkill.ActiveBoom();
    }

    void AfterEplode()
    {
        //EnemiesUpdate.Instance.EnemyDeadEff.Spawn(transform.position);
        enemyAvatar.SetActive(false);
        thisEnemy.SetStopMoving(false);
        Invoke(nameof(DespawnEnemy), DespawnDelayTime);
    }

    void DespawnEnemy()
    {
        thisEnemy.SetStopMoving(false);
        LeanPool.Despawn(gameObject);
    }
}
