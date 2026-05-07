using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionPage : APage
{
    [SerializeField] GameObject ButtonOn;
    [SerializeField] GameObject pageScreen, totalProgress;
    public override void DisableThisPage()
    {
        ButtonOn.SetActive(false);
        pageScreen.SetActive(false);
        totalProgress.SetActive(false);
    }

    public override void EnableThisPage()
    {
        ButtonOn.SetActive(true);
        pageScreen.SetActive(true);
        totalProgress.SetActive(true);
    }
}
