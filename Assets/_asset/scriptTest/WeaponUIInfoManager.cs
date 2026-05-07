using UnityEngine;
using TMPro;

public class WeaponUIInfoManager : MonoBehaviour
{
    [SerializeField] TMP_Text lvNumber, atk;
    [SerializeField] WeaponSkillDetail[] weaponSkillUI;

    public void UpdateLvl(WeaponInfo weaponInfo, int maxLvl)
    {
        lvNumber.text = weaponInfo.level.ToString() + "/" + maxLvl.ToString();
    }

    public void UpdateTotalAtk(int totalAtk)
    {
        atk.text = totalAtk.ToString();
    }

    public void UpdateWeaponSkillUI(WeaponInfo weaponInfo)
    {
        int n = weaponSkillUI.Length;
        int theRank = weaponInfo.rank;
        for (int i = 0; i < n; i++)
        {
            if(i <= theRank)
            {
                weaponSkillUI[i].UnlockIcon();
            }
        }
    }
}
