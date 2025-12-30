using Lean.Pool;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesUpdate : MonoBehaviour
{
    internal static EnemiesUpdate Instance;
    [SerializeField] int enemyQuantityLimiter = 300;
    [SerializeField] internal int enemyQuantity;
    [SerializeField] DeathCount killedZomCount;
    [SerializeField] internal LeanGameObjectPool EnemyDeadEff;

    internal List<Enemy> enemies = new List<Enemy>(500);
    int enemyIndex;
    Enemy temp;

    public bool isPause;

    private void Awake()
    {
        Instance = this;
    }
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
        if (isPause) return;
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