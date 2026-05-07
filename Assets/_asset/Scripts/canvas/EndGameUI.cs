using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndGameUI : MonoBehaviour
{
    [SerializeField] GameObject InGameUI;
    [SerializeField] GameObject winGameTitle, defeatTitle;

    [SerializeField] Transform endgameRewardsContainer;
    [SerializeField] AnEndgameRewardUI rewardUIPrefab;

    [SerializeField] TMP_Text stageName;
    [SerializeField] TMP_Text survTime, bestSurvTime;
    [SerializeField] TMP_Text zomKilled;

    public void TurnOnThis(bool isWin, float preSurvTime, int killCount, float survTime, string nameOfStage)
    {
        InGameUI.SetActive(false);
        gameObject.SetActive(true);
        if (isWin)
        {
            winGameTitle.SetActive(true);
        }
        else
        {
            defeatTitle.SetActive(true);
        }
        stageName.text = nameOfStage;
        this.survTime.text = TimeFormatChanger.SecondsToTotalMinuteSS(survTime);
        zomKilled.text = killCount.ToString();
        bestSurvTime.text = TimeFormatChanger.SecondsToTotalMinuteSS(preSurvTime);
    }

    public void TurnOnRewards(bool isWin, float thisGameSurvTime, List<EndGameReward> endGameRewards)
    {
        int rewardQuantity = endGameRewards.Count;
        for(int i = 0; i < rewardQuantity; i++)
        {
            if (isWin)
            {
                var aRewardUI = Instantiate(rewardUIPrefab, endgameRewardsContainer);
                aRewardUI.SetThisUp(endGameRewards[i].isClearGameRaward, endGameRewards[i].Icon, endGameRewards[i].Quantity);
            }
            else
            {
                if (endGameRewards[i].conditionTime <= thisGameSurvTime && endGameRewards[i].isClearGameRaward == false)
                {
                    var aRewardUI = Instantiate(rewardUIPrefab, endgameRewardsContainer);
                    aRewardUI.SetThisUp(endGameRewards[i].isClearGameRaward, endGameRewards[i].Icon, endGameRewards[i].Quantity);
                }
            }
        }
    }

    public void ToMenuScene()
    {
        PlayerSetup.instance.DeactivePlayer();
        SceneCtrler.instance.ChangeToMenuScene();
        gameObject.SetActive(false);
    }
}
