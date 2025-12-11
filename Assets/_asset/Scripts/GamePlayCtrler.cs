using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayCtrler : MonoBehaviour
{
    internal static GamePlayCtrler Instance;
    [SerializeField] internal Transform Player;
    [SerializeField] Transform CameraHolder;
    [SerializeField] internal int enemyQuantity;
    [SerializeField] int enemyQuantityLimiter = 300;
    internal List<CharacterUpdate> enemies = new();
    int enemyIndex;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        CameraHolder.position = Player.position;
        int n = enemies.Count;
        if (enemyIndex >= n) enemyIndex = 0;


        for (int i = 0; i < n; i++)
        {
            if (enemies[i].isActiveAndEnabled)
            {
                enemies[i].DoUpdate();
            }
        }

        for (int i = 0; i < 30 && enemyIndex < n; i++)
        {
            if (enemies[enemyIndex].isActiveAndEnabled)
            {
                enemies[enemyIndex].DoUpdate();
                enemies[enemyIndex].DoFixedUpdate();
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
