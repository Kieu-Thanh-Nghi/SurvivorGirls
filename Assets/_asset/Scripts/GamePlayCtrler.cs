using Lean.Pool;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayCtrler : MonoBehaviour
{
    internal static GamePlayCtrler Instance;
    [SerializeField] internal Transform Player;
    [SerializeField] DeathCount killedZomCount;
    [SerializeField] Character playChar;
    [SerializeField] Transform CameraHolder;
    [SerializeField] internal int enemyQuantity;
    [SerializeField] internal LeanGameObjectPool dameTextPool;
    [SerializeField] internal LeanGameObjectPool EnemyDeadEff;
    [SerializeField] internal EXPpools expPools;
    [SerializeField] int enemyQuantityLimiter = 300;

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
        if(enemyQuantity < 2)
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
        playChar.DoFixedUpdate();
        int n = enemies.Count;
        for (int i = 0; i < n; i++)
        {
            if (enemies[i].isActiveAndEnabled)
            {
                enemies[i].CharacterRotate(Player.position);
            }
        }
    }

    private void Update()
    {
        if (isPause) return;
        playChar.DoUpdate();

        CameraHolder.position = Player.position;
        int n = enemies.Count;
        if (playChar.characterData.moveDirect == Vector3.zero) return;
        if (enemyIndex >= n) enemyIndex = 0;
        for (int i = 0; i < 30 && enemyIndex < n; i++)
        {
            if (enemies[enemyIndex].isActiveAndEnabled)
            {
                enemies[enemyIndex].moveByNav.SetDestination(Player.position);
            }
            enemyIndex++;
        }
    }
    internal bool CheckEnemyLimit() => enemyQuantity > enemyQuantityLimiter;
}

public static class GameID
{
    public static string enemyTag = "enemy"; 
}
