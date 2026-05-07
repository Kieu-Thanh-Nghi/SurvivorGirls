using UnityEngine;
using TMPro;

public class MergeUpgradeInfo : MonoBehaviour
{
    [SerializeField] TMP_Text equipmentName;
    [SerializeField] TMP_Text currentMaxLvl, upgradeMaxLvl;
    [SerializeField] internal TMP_Text aboutQualitySkill;

    public void ShowUpgradeInfo(Equipment equipment)
    {
        var type = equipment.equipType;
        var mat = equipment.equipMat;
        var rank = equipment.rank; int rankInt = (int)rank;
        var equipSpecs = UIDatas.Instance.equipSpecs;

        var equipContex = equipSpecs.EquipContexLists[(int)mat]
            .equipContexes[(int)type];

        equipmentName.text = equipContex.EquipName.text;

        var lvlsMax = UIDatas.Instance.equipmentMaxLvEachRank;
        currentMaxLvl.text = lvlsMax[rankInt].ToString();
        upgradeMaxLvl.text = lvlsMax[rankInt + 1].ToString();

        var qualitySkillInfos = equipSpecs.qualitySkillInfos[(int)mat];
        aboutQualitySkill.text = qualitySkillInfos.GetSkillDetail(rankInt + 1);
    }
}