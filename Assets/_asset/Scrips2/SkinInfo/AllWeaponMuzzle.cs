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

#if UNITY_EDITOR

    [SerializeField] bool isValidate;

    private void OnValidate()
    {
        if (!isValidate) return;
        LowerArmR = FindChildRecursive(transform, "LoweArmR");
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
    [ContextMenu("Destroy Additionals")]
    void DestroyAdditionals()
    {
        var Additionals = transform.Find("Additionals");
        if (Additionals != null) DestroyImmediate(Additionals.gameObject);
    }    
    
    [ContextMenu("Destroy Drop_pin")]
    void DestroyDrop_pin()
    {
        Transform Drop_pin = null;
        foreach (Transform child in transform.GetComponentsInChildren<Transform>(true))
        {
            if (child.name.Contains("Drop_pin"))
            {
                Drop_pin = child;
                break;
            }
        }
        if (Drop_pin != null) DestroyImmediate(Drop_pin.gameObject);
    }
#endif

    Transform FindChildByPartialName(string partial)
    {
        foreach (Transform child in LowerArmR.GetComponentsInChildren<Transform>(true))
        {
            if (child.name.Contains(partial))
                return child.Find("PosMuzzle");
        }
        return null;
    }

    Transform FindChildRecursive(Transform parent, string name)
    {
        foreach (Transform child in parent)
        {
            if (child.name == name)
                return child;

            Transform result = FindChildRecursive(child, name);
            if (result != null)
                return result;
        }

        return null;
    }
}
