using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EquipmentSpecs : MonoBehaviour
{
    [SerializeField] internal TMP_Text lvNumber;
    [SerializeField] internal Transform[] bonusSlot;
    [SerializeField] internal Transform contexSlot, qualitySkillSlot;
    [SerializeField] internal Image rankBG, equipmentIcon;
    [SerializeField] internal GameObject EquipButton;
    internal EquipFrame currentEquipFrame;

    private void OnDisable()
    {
        foreach(var slot in bonusSlot)
        {
            var thisOneInfo = slot.GetChild(0);
            Destroy(thisOneInfo.gameObject);
        }

        var context = contexSlot.GetChild(0);
        if(context != null) Destroy(context.gameObject);

        var qualitySkill = qualitySkillSlot.GetChild(0);
        if(qualitySkill != null) Destroy(qualitySkill.gameObject);

        var equipsUIManager = UIManager.instance.equipsUIManager;
        equipsUIManager.DisableCurrentScreen();
        equipsUIManager.EnableCurrentScreen();
    }
    public void EquipTheEquipment()
    {
        //luu vao du lieu
        Database.instance.playerEquipments.EquipmentEquip(currentEquipFrame.equipment);
        //chinh sua equipUI
        UIManager.instance.equipsUIManager.EquipANewEquiment(currentEquipFrame);
        EquipButton.SetActive(false);
    }

    public void UnEquipTheEquipment()
    {
        //luu vao du lieu
        Database.instance.playerEquipments.EquipmentUnequip(currentEquipFrame.equipment);
        //chinh sua equipUI
        UIManager.instance.equipsUIManager.UnequipAnEquipment(currentEquipFrame);
        EquipButton.SetActive(true);
    }
    public void SetEquipSpecs(EquipFrame equipFrame)
    {
        currentEquipFrame = equipFrame;
        SetEquipIcon(equipFrame);
        var equipment = equipFrame.equipment;
        SetLvText(equipment);
        SetBonusInfos(equipment);
        var specsInfo = UIDatas.Instance.equipSpecs;
        SetEquipContex(specsInfo, equipment);
        SetQualitySkill(specsInfo, equipment);
        SetEquipButton(equipFrame);
    }
    void SetEquipButton(EquipFrame equipFrame)
    {
        if (equipFrame.IsEquipping)
        {
            EquipButton.SetActive(false);
        }
        else
        {
            EquipButton.SetActive(true);
        }
    }
    void SetEquipIcon(EquipFrame equipFrame)
    {
        rankBG.sprite = equipFrame.frameBG.sprite;
        equipmentIcon.sprite = equipFrame.icon.sprite;
    }
    void SetEquipContex(EquipSpecsInfo specsInfo, Equipment equipment)
    {
        var contex = specsInfo.CreateEquipContext(equipment.equipType, equipment.equipMat, contexSlot);
        contex.SetEquipmentRank(equipment.rank);
    }

    void SetQualitySkill(EquipSpecsInfo specsInfo, Equipment equipment)
    {
        var qualitySkill = specsInfo.CreateQualitySkillInfo(equipment.equipMat, qualitySkillSlot);
        qualitySkill.SetQSkillInfo(equipment.rank);
    }

    internal void SetLvText(Equipment equipment)
    {
        var uiData = UIDatas.Instance;
        int maxLv = uiData.equipmentMaxLvEachRank[(int)equipment.rank];
        lvNumber.text = equipment.Level.ToString() + " / "
            + maxLv.ToString();
    }

    void SetBonusInfos(Equipment equipment)
    {
        var equipType = Database.instance.equipTypes[(int)equipment.equipType];
        SetABonusInfo(equipment, 0, equipType);
        SetABonusInfo(equipment, 1, equipType);
    }

    void SetABonusInfo(Equipment equipment, int index, EquipType equipType)
    {
        var bonusInfo = equipType.equipmentBonusPoints[index].GetAndSetBonusInfo(equipment.Level);
        bonusInfo.transform.SetParent(bonusSlot[index], false);
        bonusInfo.gameObject.SetActive(true);
    }
}
