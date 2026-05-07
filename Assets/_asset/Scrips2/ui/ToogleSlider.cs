using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ToogleSlider : MonoBehaviour
{
    bool isEnable;
    [SerializeField] SettingEnum SaveName;
    [SerializeField] Color enableColor, disableColor;
    [SerializeField] Image toogleBar;
    [SerializeField] Scrollbar scrollbar;
    [SerializeField] UnityEvent OnEnable, OnDisable;

    private void Awake()
    {
        int startVal = PlayerPrefs.GetInt(SaveName.ToString(), 1);
        if (startVal == 0) TurnOn();
        else TurnOff();
    }

    public bool IsEnable
    {
        get => isEnable;
        set
        {
            isEnable = value;
            if (isEnable)
            {
                PlayerPrefs.GetInt(SaveName.ToString(), 1);
                TurnOn();
            }
            else
            {
                PlayerPrefs.GetInt(SaveName.ToString(), 1);
                TurnOff();
            }
        }
    }

    void TurnOn()
    {
        scrollbar.value = 1;
        toogleBar.color = enableColor;
        OnEnable?.Invoke();
    }

    void TurnOff()
    {
        scrollbar.value = 0;
        toogleBar.color = disableColor;
        OnDisable?.Invoke();
    }

    public void ClickButton()
    {
        IsEnable = !IsEnable;
    }
}
