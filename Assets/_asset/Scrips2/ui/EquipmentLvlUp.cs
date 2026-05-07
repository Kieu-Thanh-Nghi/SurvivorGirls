using UnityEngine;

public class EquipmentLvlUp : MonoBehaviour, IPayable
{
    [SerializeField] EquipmentSpecs equipmentSpecs;
    [SerializeField] PayButton LvlUpButton;
    [SerializeField] int lvlUpPriceEachLvl = 150;
    [SerializeField] int startPrice = 100;
    bool isChange;

    private void OnEnable()
    {
        isChange = false;
        var equipment = equipmentSpecs.currentEquipFrame.equipment;
        int maxLvl = UIDatas.Instance.equipmentMaxLvEachRank[(int)equipment.rank];
        if (equipment.Level == maxLvl)
        {
            LvlUpButton.gameObject.SetActive(false);
        }
        else
        {
            LvlUpButton.SetBuyInfoAndCheckEnough(startPrice + lvlUpPriceEachLvl*(equipment.Level - 1), this);
            LvlUpButton.gameObject.SetActive(true);
        }
    }
    public void LevelUp()
    {
        var equipment = equipmentSpecs.currentEquipFrame.equipment;
        int maxLvl =  UIDatas.Instance.equipmentMaxLvEachRank[(int)equipment.rank];
        if (equipment.Level < maxLvl)
        {
            var newLvl = ++equipment.Level;
            equipmentSpecs.SetLvText(equipment);
            //equipmentSpecs.currentEquipFrame.SetFrameLvl(newLvl);
            isChange = true;
            LvlUpButton.SetBuyInfo(startPrice + lvlUpPriceEachLvl * (equipment.Level - 1), this);
        }
        if (equipment.Level == maxLvl)
        {
            LvlUpButton.gameObject.SetActive(false);
        }
    }

    void SaveUIChange(EquipFrame equipFrame)
    {
        UIManager.instance.equipsUIManager.DoWhenLvlUp(equipFrame);
    }

    void SaveDataChange(Equipment equipment)
    {
        Database.instance.playerEquipments
                .EquipInfosListses[(int)equipment.equipType]
                .SaveEquipInfos(equipment.equipType.ToString());
    }
    void SaveChange()
    {
        if (isChange)
        {
            isChange = false;
            var equipFrame = equipmentSpecs.currentEquipFrame;
            SaveDataChange(equipFrame.equipment);
            SaveUIChange(equipFrame);
        }
    }
    private void OnDisable()
    {
        SaveChange();
    }

    private void OnDestroy()
    {
        SaveChange();
    }

    public void DonePaying() => LevelUp();
}