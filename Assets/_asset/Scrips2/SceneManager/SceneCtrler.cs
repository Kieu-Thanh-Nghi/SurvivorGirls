using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCtrler : MonoBehaviour
{
    [SerializeField] LoadingScreen loadingScreen;
    public static SceneCtrler instance;
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    [ContextMenu("change to gameplay scene")]
    public void ChangeToGameplayScene(StageSelect stageSelect)
    {
        var thePlayStage = stageSelect.GetChosenPlayStage();
        //lay scene name
        //lay stage data
        //lay enemy spawner
        Database.instance.pLStagePreparing.SetUpPreparingData(stageSelect.HardLvl, thePlayStage.GetPlayStageData(), thePlayStage.GetEnemySpawner(), stageSelect.GetChosenStageName());
        Database.instance.playerItems.SetNecessariesIn();
        PlayerSetup.instance.DoSetup();
        //SceneManager.LoadScene(thePlayStage.SceneName);
        loadingScreen.LoadScene(thePlayStage.SceneName);
    }

    public void ChangeToMenuScene() => loadingScreen.LoadScene("Menu");
}
