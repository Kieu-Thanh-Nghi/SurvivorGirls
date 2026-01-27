using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ToogleSlider : MonoBehaviour
{
    bool isEnable;
    [SerializeField] Color enableColor, disableColor;
    [SerializeField] Image toogleBar;
    [SerializeField] Scrollbar scrollbar;
    [SerializeField] UnityEvent OnEnable, OnDisable;

    public bool IsEnable
    {
        get => isEnable;
        set
        {
            isEnable = value;
            if (isEnable)
            {
                scrollbar.value = 1;
                toogleBar.color = enableColor;
                OnEnable?.Invoke();
            }
            else
            {
                scrollbar.value = 0;
                toogleBar.color = disableColor;
                OnDisable?.Invoke();
            }
        }
    }

    public void ClickButton()
    {
        IsEnable = !IsEnable;
    }
}
