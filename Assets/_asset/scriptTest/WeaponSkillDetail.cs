using UnityEngine;
using TMPro;

public class WeaponSkillDetail : MonoBehaviour
{
    [SerializeField] GameObject skillIcon, lockIcon;

    public void UnlockIcon()
    {
        skillIcon.SetActive(true);
        lockIcon.SetActive(false);
    }
}
