using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllWeaponMuzzle : MonoBehaviour
{
    [SerializeField] Transform LowerArmR;
    [SerializeField] internal Transform RailgunMuzzle;
    [SerializeField] internal Transform SpearMuzzle;
    [SerializeField] internal Transform RifleMuzzle;
    [SerializeField] internal Transform LifleluckyMuzzle;
    [SerializeField] internal Transform ShotgunMuzzle;
    [SerializeField] internal Transform CrossbowMuzzle;
    [SerializeField] internal Transform PistolMuzzle;
    [SerializeField] internal Transform GatlingMuzzle;
    [SerializeField] internal Transform DragonFireMuzzle;
    [SerializeField] internal Transform KatanaMuzzle;
    [SerializeField] bool isValidate;

    private void OnValidate()
    {
        if (!isValidate && LowerArmR != null) return;
        RailgunMuzzle = FindChildByPartialName("railgun");
        SpearMuzzle = FindChildByPartialName("spear");
        RifleMuzzle = FindChildByPartialName("rifle");
        LifleluckyMuzzle = FindChildByPartialName("liflelucky");
        ShotgunMuzzle = FindChildByPartialName("shotgun");
        CrossbowMuzzle = FindChildByPartialName("crossbow");
        PistolMuzzle = FindChildByPartialName("pistol");
        GatlingMuzzle = FindChildByPartialName("gatling");
        DragonFireMuzzle = FindChildByPartialName("dragon+fire");
        KatanaMuzzle = FindChildByPartialName("katana");
    }

    Transform FindChildByPartialName(string partial)
    {
        foreach (Transform child in LowerArmR.GetComponentsInChildren<Transform>(true))
        {
            if (child.name.Contains(partial))
                return child.Find("PosMuzzle");
        }
        return null;
    }
}
