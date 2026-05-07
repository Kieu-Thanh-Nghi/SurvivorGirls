using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager : MonoBehaviour
{
    [SerializeField] List<StatusPool> statusPools;
    
    public T CreateAStatusEff<T>(StatusType statusType, Transform effContainer) where T : Effect
    {
        return statusPools[(int)statusType].SpawnStatusEff(effContainer).GetComponent<T>();
    }
}

public enum StatusType
{
    Burn = 0,
    Frozen = 1,
    Electric = 2
}