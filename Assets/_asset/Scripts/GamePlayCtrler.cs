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

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        CameraHolder.position = Player.position;
    }
    internal bool CheckEnemyLimit() => enemyQuantity > enemyQuantityLimiter;
}

public static class GameID
{
    public static string enemyTag = "enemy"; 
}
