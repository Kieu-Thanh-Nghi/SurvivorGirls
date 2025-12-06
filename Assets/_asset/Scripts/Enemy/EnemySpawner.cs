using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] SpawnStarter[] spawnStarters;
    [SerializeField] float countingTime = 0;
    int thefirstIndex = 0, theLastIndex = 0;

    void checkSampleActive()
    {
        if (theLastIndex >= spawnStarters.Length) return;
        if (spawnStarters[theLastIndex].StartTime <= countingTime)
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
            if (spawnStarters[i].Spawn(countingTime))
            {
                Swap(spawnStarters[thefirstIndex], spawnStarters[i]);
                thefirstIndex++;
            }
        }
    }

    void Swap(SpawnStarter a, SpawnStarter b)
    {
        SpawnStarter temp = a;
        a = b;
        b = temp;
    }
    //
    [ContextMenu("setup")]
    void SetUp()
    {
        SpawnStarter[] spawns = GetComponentsInChildren<SpawnStarter>();
        List<SpawnStarter> temp = new();
        foreach (var spawn in spawns)
        {
            temp.Add(spawn);
        }
        temp.Sort((x, y) => x.StartTime.CompareTo(y.StartTime));
        spawnStarters = temp.ToArray();
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
