using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBook_WSkill : MonoBehaviour
{
    [SerializeField] int weaponIndex;
    [SerializeField] GameObject[] lockFrame;

    private void OnEnable()
    {
        var weaponInfo = Database.instance.playerItems.weaponData.GetAnWeaponInfo(weaponIndex);
        int rank = weaponInfo.rank;
        for(int i = 0; i <= rank; i++)
        {
            lockFrame[i]?.SetActive(false);
        }
    }

    public void OpenWSkillScreen(int skillIndex)
    {
        if(Database.instance.playerItems.weaponData.itemList[weaponIndex]
            .TryGetComponent(out WeaponSkillData weaponSkillData))
        {
            var wSkillUIDetails = UIManager.instance.wSkillUIDetails;
            wSkillUIDetails.SetDetails(weaponSkillData.GetASkillDetailsPrefab(skillIndex));
            wSkillUIDetails.gameObject.SetActive(true);
        }
    }
}
