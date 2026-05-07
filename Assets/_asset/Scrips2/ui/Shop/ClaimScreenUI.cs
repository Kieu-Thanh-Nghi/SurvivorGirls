using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClaimScreenUI : MonoBehaviour
{
    [SerializeField] internal ChipRewardShower chipRewardShower;
    [SerializeField] internal EquipmentRewardShower equipmentRewardShower;
    [SerializeField] GameObject tapAnywhere;
    [SerializeField] Button buttonOff;
    [SerializeField] float timeToTurnOff = 2f;
    GameObject usingScreen;

    public void OpenClaimScreen()
    {
        buttonOff.enabled = false;
        tapAnywhere.gameObject.SetActive(false);
        gameObject.SetActive(true);
        Invoke(nameof(AbleToTurnOffScreen), timeToTurnOff);
    }
    public void UsingScreenCtrler(GameObject newUsingScreen)
    {
        if (usingScreen != null) usingScreen.SetActive(false);
        newUsingScreen.SetActive(true);
        usingScreen = newUsingScreen;
    }

    void AbleToTurnOffScreen()
    {
        tapAnywhere.gameObject.SetActive(true);
        buttonOff.enabled = true;
    }
}
