using UnityEngine;
using UnityEngine.UI;

public class ChoosingButton : MonoBehaviour
{
    [SerializeField] internal int theSkinIndex;
    [SerializeField] GameObject SelectedBG, EquipSigh;
    [SerializeField] internal BuyInfo skinBuyInfo;
    [SerializeField] Button SelectButton;

    public void EquipThisSkin()
    {
        SelectThisSkin(true);
        UIManager.instance.CharacterPageChanger.currentCharPage.choosing.SelectNewCharSkin(this);
    }

    public void UnequipThisSkin()
    {
        DeactiveEquippedMark();
    }

    public void SelectThisSkin(bool isSelect)
    {
        SelectedBG.SetActive(isSelect);
        SelectButton.enabled = !isSelect;
    }

    public void ActiveEquippedMark()
    {
        SelectThisSkin(true);
        EquipSigh.SetActive(true);
    }
    public void DeactiveEquippedMark()
    {
        SelectThisSkin(false);
        EquipSigh.SetActive(false);
    }
}
