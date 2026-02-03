using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTabManager : MonoBehaviour
{
    [SerializeField] TabSizeChanger tabSizeChanger;

    public void SetCurrentTab(TabSizeChanger tab)
    {
        tabSizeChanger = tab;
    }
    public void ResetCurrentTab() => tabSizeChanger?.ResetTabSize();
}
