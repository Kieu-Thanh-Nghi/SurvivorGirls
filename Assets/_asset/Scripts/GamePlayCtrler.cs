using Lean.Pool;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayCtrler : MonoBehaviour
{
    internal static GamePlayCtrler Instance;
    [SerializeField] EnemiesUpdate enemiesUpdate;
    [SerializeField] internal Transform Player;
    [SerializeField] internal WarningPanel warningPanel;
    [SerializeField] DeathCount killedZomCount;
    [SerializeField] Transform CameraHolder;
    [SerializeField] internal LeanGameObjectPool dameTextPool;
    [SerializeField] internal EXPpools expPools;
    bool _isPause;
    public bool IsPause { set {
            Time.timeScale = value ? 0 : 1;
            _isPause = value;
            enemiesUpdate.isPause = value;
        } }

    private void Awake()
    {
        Instance = this;
    }
    //private void FixedUpdate()
    //{
    //    //playChar.DoFixedUpdate();
    //    int n = enemies.Count;
    //    for (int i = 0; i < n; i++)
    //    {
    //        if (enemies[i].isActiveAndEnabled)
    //        {
    //            enemies[i].EnemyRotate();
    //        }
    //    }
    //}

    private void Update()
    {
        if (_isPause) return;
        //playChar.DoUpdate();

        CameraHolder.position = Player.position;
        //    int n = enemies.Count;
        //    if (playChar.characterData.moveDirect == Vector3.zero) return;
        //    if (enemyIndex >= n) enemyIndex = 0;
        //    for (int i = 0; i < 30 && enemyIndex < n; i++)
        //    {
        //        if (enemies[enemyIndex].isActiveAndEnabled)
        //        {
        //            enemies[enemyIndex].moveByNav.SetDestination(Player.position);
        //        }
        //        enemyIndex++;
        //    }
        //}
    }
}

public static class GameID
{
    public static string enemyTag = "enemy"; 
}
