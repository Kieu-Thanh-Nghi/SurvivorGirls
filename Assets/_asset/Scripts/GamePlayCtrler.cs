using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayCtrler : MonoBehaviour
{
    internal static GamePlayCtrler Instance;
    [SerializeField] internal Transform Player;
    [SerializeField] Character playChar;
    [SerializeField] Transform CameraHolder;
    [SerializeField] internal int enemyQuantity;
    [SerializeField] int enemyQuantityLimiter = 300;
    internal List<Enemy> enemies = new();
    int enemyIndex;

    public bool isPause;

    private void Awake()
    {
        Instance = this;
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
