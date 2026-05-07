using UnityEngine;
using UnityEngine.Purchasing;
using System;
public class IAPManager : MonoBehaviour
{
    StoreController m_StoreController;

    private void Awake()
    {
        InitializeIAP();
    }

    async void InitializeIAP()
    {
        m_StoreController = UnityIAPServices.StoreController();

        m_StoreController.OnStoreConnected += OnStoreConnected;

        await m_StoreController.Connect();
    }

    private void OnStoreConnected()
    {
        Debug.Log("connected");
    }
}