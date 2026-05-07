using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponSkillInfos : MonoBehaviour
{
    [SerializeField] List<WeaponSkillDetail> details;
    [SerializeField] internal List<TMP_Text> infos;
    public void ConfigSkillsLockOrOpen(WeaponInfo weaponInfo)
    {
        int n = details.Count;
        int theRank = weaponInfo.rank;
        for (int i = 0; i < n; i++)
        {
            if (i <= theRank)
            {
                details[i].UnlockIcon();
            }
        }
    }
}
