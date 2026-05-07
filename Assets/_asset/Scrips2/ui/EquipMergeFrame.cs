using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class EquipMergeFrame : MonoBehaviour
{
    [SerializeField] int mergeFrameType;
    [SerializeField] internal Image FrameBG;
    [SerializeField] internal Image Icon;
    [SerializeField] internal GameObject equippedMark;
    [SerializeField] internal TMP_Text lvlText;
    internal EquipFrame thisEquipFrame;
    int frameIndex;

    public void SetInfo(Sprite frameBG, Sprite icon, 
        bool isEquipped, TMP_Text lvl, EquipFrame theEquipFrame)
    {
        FrameBG.sprite = frameBG;
        Icon.sprite = icon;
        equippedMark.SetActive(isEquipped);
        lvlText.text = lvl.text;
        thisEquipFrame = theEquipFrame;
    }
    public void Reverse()
    {
        UIManager.instance.equipsUIManager.mergeEquipment.DoReverse(thisEquipFrame, this, mergeFrameType);
    }
    private void OnDisable()
    {
        gameObject.SetActive(false);
    }
}

public class EquipFrameComparer : Comparer<EquipFrame>
{
    public override int Compare(EquipFrame frameA, EquipFrame frameB)
    {
        var equipmentA = frameA.equipment;
        var equipmentB = frameB.equipment;

        if (equipmentA.Level < equipmentB.Level)
        {
            return 1;
        }
        else if (equipmentA.Level > equipmentB.Level)
        {
            return -1;
        }
        else
        {
            var compareMat = equipmentB.equipMat.CompareTo(equipmentA.equipMat);
            if (compareMat == 0)
            {
                return equipmentB.id.CompareTo(equipmentA.id);
            }
            else
            {
                return compareMat;
            }
        }
    }
}
