using UnityEngine;

public class ChoosingButton : MonoBehaviour
{
    [SerializeField] internal int theSkinIndex;
    [SerializeField] GameObject SelectedBG, EquipSigh;
    [SerializeField] internal BuyInfo skinBuyInfo;

    public void EquipThisSkin()
    {
        SelectedBG.SetActive(true);
        UIManager.instance.CharacterPageChanger.currentCharPage.choosing.SelectNewCharSkin(this);
    }

    public void UnequipThisSkin()
    {
        DeactiveEquippedMark();
    }

    public void SelectThisSkin(bool isSelect)
    {
        SelectedBG.SetActive(isSelect);
    }

    public void ActiveEquippedMark()
    {
        SelectedBG.SetActive(true);
        EquipSigh.SetActive(true);
    }
    public void DeactiveEquippedMark()
    {
        SelectedBG.SetActive(false);
        EquipSigh.SetActive(false);
    }
}
