using System.Collections.Generic;
using UnityEngine;

public class PlayerNecessaries : MonoBehaviour
{
    [SerializeField] internal PlayerEquipableItem defaultItem;

    [SerializeField] internal PlayerItemsData skinData;
    [SerializeField] internal PlayerItemsData PetData;
    [SerializeField] internal PlayerWeaponData weaponData;

    [SerializeField] internal Transform PlayerEffPrefab;

    [SerializeField] internal ActiveSkillInjection activeSkillPrefab;
    [SerializeField] internal PassiveSkillInjection passiveSkillPrefab;

    private void Start()
    {
        defaultItem.Equip();
        var equippingSkin = skinData.itemList[skinData.equippingItemIndex].GetComponent<PlayerEquipableItem>();
        if(equippingSkin != null) equippingSkin.Equip();
        skinData.ConfigItemBoughtInfo();
        PetData.ConfigItemBoughtInfo();
        weaponData.ConfigItemBoughtInfo();
    }
    [ContextMenu("test set skin")]
    public void SetNecessariesIn()
    {
        var playerSetup = PlayerSetup.instance;
        Transform playerTransform = playerSetup.player;

        playerSetup.playerSkin = skinData.SetItemIn(playerSetup, playerTransform);

        weaponData.SetItemIn(playerSetup, playerTransform);

        Instantiate(PlayerEffPrefab, skinData.currentItem);

        playerSetup.activeSkillInjection = Instantiate(activeSkillPrefab, playerTransform);
        playerSetup.passiveSkillInjection = Instantiate(passiveSkillPrefab, playerTransform);
    }
}
