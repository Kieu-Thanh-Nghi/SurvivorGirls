using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] TurnAround turn;
    [SerializeField] internal NavMeshAgent moveByNav;
    IRotate rotateFuntion = new Rotate();
    internal Transform target;
    internal Vector3 faceDirect;
    internal int enemyIndex;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, rb.transform.forward);
    }
    private void Start()
    {
        moveByNav.updateRotation = false;
        target = GamePlayCtrler.Instance.Player;
    }

    private void OnEnable()
    {
        moveByNav.enabled = true;
        SetEnemyDestination();
        EnemyRotate();
    }
    public void SetEnemyDestination()
    {
        moveByNav.SetDestination(target.position);
    }
    public void EnemyRotate()
    {
        faceDirect = (target.position - transform.position).normalized;
        rotateFuntion.DoRotate(transform, faceDirect);
    }

    private void OnDisable()
    {
        target = GamePlayCtrler.Instance.Player;
    }
}

public class EnemiesUpdate : MonoBehaviour
{
    [SerializeField] int enemyQuantityLimiter = 300;
    [SerializeField] internal int enemyQuantity;
    [SerializeField] DeathCount killedZomCount;

    internal List<Enemy> enemies = new List<Enemy>(500);
    int enemyIndex;
    Enemy temp;

    public bool isPause;

    public void AddAnEnemy(Enemy theEnemy)
    {
        enemies.Add(theEnemy);
        theEnemy.enemyIndex = enemyQuantity;
        enemyQuantity++;
    }
    public void RemoveAnEnemy(Enemy theEnemy)
    {
        if (enemyQuantity < 2)
        {
            enemies.RemoveAt(0);
        }
        else
        {
            temp = enemies[enemyQuantity - 1];
            enemies[enemyQuantity - 1] = theEnemy;
            enemies[theEnemy.enemyIndex] = temp;
            temp.enemyIndex = theEnemy.enemyIndex;
            enemies.RemoveAt(enemyQuantity - 1);
        }
        enemyQuantity--;
        killedZomCount.DoCount();
    }
    private void FixedUpdate()
    {
        //playChar.DoFixedUpdate();
        int n = enemies.Count;
        for (int i = 0; i < n; i++)
        {
            if (enemies[i].isActiveAndEnabled)
            {
                enemies[i].EnemyRotate();
            }
        }
    }

    private void Update()
    {
        if (isPause) return;
        //playChar.DoUpdate();
        int n = enemies.Count;
        //if (playChar.characterData.moveDirect == Vector3.zero) return;
        if (enemyIndex >= n) enemyIndex = 0;
        for (int i = 0; i < 30 && enemyIndex < n; i++)
        {
            if (enemies[enemyIndex].isActiveAndEnabled)
            {
                enemies[enemyIndex].SetEnemyDestination();
            }
            enemyIndex++;
        }
    }
    internal bool CheckEnemyLimit() => enemyQuantity > enemyQuantityLimiter;

}