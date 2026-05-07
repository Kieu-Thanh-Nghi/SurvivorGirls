using UnityEngine;

public class PLStagePreparing : MonoBehaviour
{
    internal string StageName;
    internal int HardLvl;
    internal PlStageData ChosenPlayStageData;
    internal GameObject EnemySpawner;

    public void SetUpPreparingData(int theHardLvl, PlStageData chosenPlayStageData, GameObject enemySpawnerPrefab, string StageName)
    {
        this.StageName = StageName;
        HardLvl = theHardLvl;
        ChosenPlayStageData = chosenPlayStageData;
        EnemySpawner = Instantiate(enemySpawnerPrefab, transform);
    }
}
