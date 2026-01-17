using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] SpawnStarter[] spawnStarters;
    int thefirstIndex = 0, theLastIndex = 0;
    internal bool isStopCounting, isGameStop;
    internal float CountingTime = 0;

    //private void Update()
    //{
    //    if (isStopCounting || isGameStop) return;
    //    CountingTime += Time.deltaTime;
    //    checkSampleActive();
    //    UpdateActivatedSample();
    //}

    internal void UpdateSpawnClock(float value)
    {
        CountingTime = value;
        checkSampleActive();
        UpdateActivatedSample();
    }

    void checkSampleActive()
    {
        if (theLastIndex >= spawnStarters.Length) return;
        if (spawnStarters[theLastIndex].StartTime <= CountingTime)
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
            if (spawnStarters[i].Spawn(CountingTime))
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

}
