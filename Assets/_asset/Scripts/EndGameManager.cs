using UnityEngine;
using TigerForge;
using UnityEngine.Events;

public class EndGameManager : MonoBehaviour
{
    [SerializeField] internal int BossQuantity;
    [SerializeField] internal EndGameUI endGameUI;
    [SerializeField] UnityEvent<bool> OnGameEnd;

    internal PLStagePreparing pLStagePreparing => Database.instance.pLStagePreparing;
    internal PlStageData plStageData => pLStagePreparing.ChosenPlayStageData;
    internal int killCount => GamePlayCtrler.Instance.killedZomCount.counted;
    internal float survTime => GamePlayCtrler.Instance.CountingTime;
    internal EnemySpawner enemySpawner => GamePlayCtrler.Instance.enemySpawner;
    internal int killedBoss;
    private void Start()
    {
        BossQuantity = enemySpawner.GetBigBossQuantity();
        EventManager.StartListening(GameEvents.BossKilled.ToString(), CheckWinGame);
        EventManager.StartListening(GameEvents.PlayerDead.ToString(), DoWhenLost);
        EventManager.StartListening(GameEvents.EndGameImmediate.ToString(), EndGameImmediately);
    }
    void CheckWinGame()
    {
        killedBoss++;
        if(killedBoss >= BossQuantity)
        {
            DoWhenWin();
        }
    }
    void DoWhenWin()
    {
        DoWhenEnd(true);
    }
    void DoWhenLost()
    {
        DoWhenEnd(false);
    }

    void DoWhenEnd(bool isWin)
    {
        GamePlayCtrler.Instance.IsPause = true;

        float oldSurvTime = plStageData.playtime;
        float newSurvTime = oldSurvTime;
        float maxSurvTime = enemySpawner.GetEndTime();

        if (isWin)
        {
            newSurvTime = maxSurvTime;
        }
        else
        {
            if (survTime >= maxSurvTime)
            {
                newSurvTime = survTime - 1;
            }
            else
            {
                if (oldSurvTime < survTime) newSurvTime = survTime;
            }
        }

        endGameUI.TurnOnRewards(isWin, survTime, EnemiesUpdate.Instance.endGameRewards);
        endGameUI.TurnOnThis(isWin, oldSurvTime, killCount, newSurvTime, pLStagePreparing.StageName);

        plStageData.playtime = newSurvTime;

        plStageData.SaveData();
        OnGameEnd?.Invoke(isWin);
    }

    public void EndGameImmediately()
    {
        PlayerSetup.instance.DeactivePlayer();
        SceneCtrler.instance.ChangeToMenuScene();
    }
}
