using UnityEngine;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    [SerializeField] internal EquipsUIManager equipsUIManager;
    [SerializeField] internal EquipmentSpecs equipmentSpecs;
    [SerializeField] internal EquipmentRankUpSuccess rankUpSuccess;

    [SerializeField] internal SkinPreview skinPreview, petPreview;
    [SerializeField] internal CharacterPageChanger CharacterPageChanger;
    [SerializeField] internal CharacterSkinChoosing characterSkinChoosing, characterPetChoosing;

    [SerializeField] internal WeaponUI weaponUI;
    [SerializeField] internal WeaponSpecs weaponSpecs;
    [SerializeField] internal WeaponRankUpUI weaponRankUpUI;

    [SerializeField] internal MenuShop menuShop;
    internal static UIManager instance;
    [SerializeField] internal GameObject setting;

    [SerializeField] internal WSkillUIDetails wSkillUIDetails;
    [SerializeField] internal ASkillUIDetails aSkillUIDetails;

    [SerializeField] UnityEvent DoWhenStartGame;

    private void Awake()
    {
        instance = this;
        Time.timeScale = 1;
    }
    private void Start()
    {
        setting.SetActive(false);
        DoWhenStartGame?.Invoke();
        characterSkinChoosing.ConfigUsingSkin();
        characterPetChoosing.ConfigUsingSkin();
        weaponUI.ConfigWeapon();
    }
}
