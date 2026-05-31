using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : Singleton<DatabaseManager>
{
    [SerializeField] internal CurrencyDatas currencyDatas;
    [SerializeField] internal PlayStageManager playStageManager;
    [SerializeField] internal DailyRewardsBackEnd dailyRewardsBackEnd;
    [SerializeField] internal UIDatas uiDatas;
}

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    static T instance;
    [SerializeField] bool isDontDestroyOnLoad = true;

    public static T Instance
    {
        get => instance;
        //{
        //    if (instance == null)
        //    {
        //        instance = FindFirstObjectByType<T>();

        //        if (instance == null)
        //        {
        //            GameObject obj = new GameObject(typeof(T).Name);
        //            instance = obj.AddComponent<T>();
        //        }
        //    }

        //    return instance;
        //}
    }

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            if(isDontDestroyOnLoad) DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
}
