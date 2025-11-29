using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] AbstractSpawnerStrategy[] spawnStrategies;
    [SerializeField] float countingTime = 0;
    int thefirstIndex = 0, theLastIndex = 0;

    void checkSampleActive()
    {
        if (theLastIndex >= spawnStrategies.Length) return;
        if (spawnStrategies[theLastIndex].StartTime <= countingTime)
        {
            theLastIndex += 1;
            checkSampleActive();
        }
    }

    void UpdateActivatedSample()
    {
        if(thefirstIndex < theLastIndex)
        for(int i = thefirstIndex; i < theLastIndex; i++)
        {
            if (spawnStrategies[i].Spawn(countingTime))
            {
                Swap(spawnStrategies[thefirstIndex], spawnStrategies[i]);
                thefirstIndex++;
            }
        }
    }

    void Swap(AbstractSpawnerStrategy a, AbstractSpawnerStrategy b)
    {
        AbstractSpawnerStrategy temp = a;
        a = b;
        b = temp;
    }
    //
    [ContextMenu("setup")]
    void SetUp()
    {
        AbstractSpawnerStrategy[] spawns = GetComponentsInChildren<AbstractSpawnerStrategy>();
        List<AbstractSpawnerStrategy> temp = new();
        foreach (var spawn in spawns)
        {
            temp.Add(spawn);
        }
        temp.Sort((x, y) => x.StartTime.CompareTo(y.StartTime));
        spawnStrategies = temp.ToArray();
    }
    //

    private void Update()
    {
        countingTime += Time.deltaTime;
        Debug.Log(GamePlayCtrler.Instance.enemyQuantity);
        checkSampleActive();
        UpdateActivatedSample();
    }
}
