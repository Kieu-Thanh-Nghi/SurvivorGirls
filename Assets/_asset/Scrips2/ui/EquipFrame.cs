using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipFrame : MonoBehaviour
{
    [SerializeField] internal TMP_Text lvlText;
    [SerializeField] internal Image frameBG;
    [SerializeField] internal Image icon;
    [SerializeField] internal GameObject equippedMark;
    bool isEquipping = false;
    internal bool IsEquipping
    {
        get => isEquipping;
        set
        {
            isEquipping = value;
            equippedMark.SetActive(value);
        }
    }
    internal Equipment equipment;

    public void EquipMarkWhenInEquippedFrame()
    {
        isEquipping = true;
        equippedMark.SetActive(false);
    }
    internal void SetupEquipPresent(Equipment theEquipment)
    {
        equipment = theEquipment;
        SetFrameLvl(theEquipment.Level);
        var UIdata = UIDatas.Instance;
        frameBG.sprite = UIdata.rankBg[(int)theEquipment.rank];
        icon.sprite = UIdata.equipIconsList[(int)theEquipment.equipType]
            .icons[(int)theEquipment.equipMat];
        theEquipment.DoWhenLvlChange += SetFrameLvl;
    }
    public void SetFrameLvl(int theLvl)
    {
        lvlText.text = "LV." + theLvl.ToString();
    }
    public void ActiveThisFrame()
    {
        UIManager.instance.equipsUIManager.ActiveEquipFrame(this);
    }

    private void OnDestroy()
    {
        equipment.DoWhenLvlChange -= SetFrameLvl;
    }
}
