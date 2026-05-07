using Lean.Pool;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GamePlayCtrler : MonoBehaviour
{
    internal static GamePlayCtrler Instance;
    [SerializeField] GameplaySetup gameplaySetup;
    [SerializeField] internal MapManager mapManager;

    [SerializeField] internal Transform FolowPlayer;
    [SerializeField] EnemiesUpdate enemiesUpdate;
    [SerializeField] internal EnemySpawner enemySpawner;
    [SerializeField] internal PlStageSetup plStageSetup;
    [SerializeField] internal StatusManager statusManager;

    [SerializeField] internal DeathCount killedZomCount;
    [SerializeField] internal Transform Player;
    [SerializeField] internal WarningPanel warningPanel;
    [SerializeField] internal LeanGameObjectPool dameTextPool;
    [SerializeField] internal EXPpools expPools;
    [SerializeField] internal Transform BossArea;
    [SerializeField] internal Joystick joystick;

    //
    [SerializeField] float countingTime = 0;
    [SerializeField] internal UnityEvent DoWhenCountTime;
    [SerializeField] public bool isStopCounting;
    internal float CountingTime
    {
        get => countingTime;
        set
        {
            if (value > countingTime)
            {
                countingTime = value;
                DoWhenCountTime?.Invoke();
                enemySpawner.UpdateSpawnClock(countingTime);
            }
        }
    }

    bool _isPause;
    public bool IsPause { set {
            Time.timeScale = value ? 0 : 1;
            _isPause = value;
            enemiesUpdate.isPause = value;
        } }

    private void Awake()
    {
        Instance = this;
        if(EnemiesUpdate.Instance != null)
        {
            enemiesUpdate = EnemiesUpdate.Instance;
            enemySpawner = enemiesUpdate.enemySpawner;
            Debug.Log(enemySpawner == null);
            enemySpawner.transform.SetParent(FolowPlayer, false);
            Debug.Log(FolowPlayer == null);
            plStageSetup.SetTheStage();
        }
        gameplaySetup.SetupPlayer();
        Player = PlayerSetup.instance.player;
        Player.position = Vector3.zero;
        Player.gameObject.SetActive(true);
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

        if (!isStopCounting)
        {
            CountingTime += Time.deltaTime;
        }
        //playChar.DoUpdate();

        FolowPlayer.position = Player.position;
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
    public void testLvUp1()
    {
        PlayerSetup.instance.levelManager.Up1Level();
    }
}

public static class GameID
{
    public static string enemyTag = "enemy"; 
}
