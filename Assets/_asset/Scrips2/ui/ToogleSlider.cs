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

    private void Start()
    {
        int startVal = PlayerPrefs.GetInt(SaveName.ToString(), 1);
        if (startVal == 1) OnUI();
        else OffUI();
    }

    public bool IsEnable
    {
        get => isEnable;
        set
        {
            isEnable = value;
            if (isEnable)
            {
                PlayerPrefs.SetInt(SaveName.ToString(), 1);
                TurnOn();
            }
            else
            {
                PlayerPrefs.SetInt(SaveName.ToString(), 0);
                TurnOff();
            }
        }
    }

    void OnUI()
    {
        scrollbar.value = 1;
        toogleBar.color = enableColor;
    }

    void OffUI()
    {
        scrollbar.value = 0;
        toogleBar.color = disableColor;
    }

    void TurnOn()
    {
        OnUI();
        Setting.Instance.OnOffASetting[(int)SaveName]?.Invoke(true);
    }

    void TurnOff()
    {
        OffUI();
        Setting.Instance.OnOffASetting[(int)SaveName]?.Invoke(false);
    }

    public void ClickButton()
    {
        IsEnable = !IsEnable;
    }
}
