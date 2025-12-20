using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpSpawner : MonoBehaviour
{
    [SerializeField] ExpTypeAndPercent[] ExpTypes;
    [SerializeField] int sumOfPercentages;
    [SerializeField] int n;

    private void OnValidate()
    {
        sumOfPercentages = 0;
        foreach (var type in ExpTypes)
        {
            sumOfPercentages += type.percent;
        }
        n = ExpTypes.Length;
    }

    public void DoExpSpawn()
    {
        int value = Random.Range(0, sumOfPercentages);
        int sum = 0;
        for(int i = 0; i < n; i++)
        {
            sum += ExpTypes[i].percent;
            if (sum > value)
            {
                GamePlayCtrler.Instance.expPools.SpawnEXP(i, transform.position);
                return;
            }
        }
    }
}

[System.Serializable]
public class ExpTypeAndPercent
{
    [SerializeField] internal int type;
    [SerializeField] internal int percent;
}