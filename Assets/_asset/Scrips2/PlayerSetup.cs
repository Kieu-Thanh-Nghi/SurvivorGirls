using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    [SerializeField] PlayerUpdate playerUpdate;
    [SerializeField] Health playerHealth;
    [SerializeField] PlayerHeal playerHeal;
    [SerializeField] internal Transform playerSkin;
    [SerializeField] internal WeaponInjection weaponInjection;
    [SerializeField] internal ActiveSkillInjection activeSkillInjection;
    [SerializeField] internal PassiveSkillInjection passiveSkillInjection;
    PlayerSkinInfos playerSkinInfos;

    public void DoSetup()
    {
        playerSkinInfos = playerSkin.GetComponent<PlayerSkinInfos>();
        playerHealth.OnHurt.AddListener(playerSkinInfos.playerHit.Play);
        playerHeal.smallHeal = playerSkinInfos.smallHeal;
        playerHeal.bigHeal = playerSkinInfos.bigHeal;

        weaponInjection.WeaponSetUp(playerSkin.GetComponent<AllWeaponMuzzle>());
        weaponInjection.gameObject.SetActive(true);

        activeSkillInjection.Player = playerUpdate.transform;
        activeSkillInjection.weaponInjection = weaponInjection;
        activeSkillInjection.gameObject.SetActive(true);

        passiveSkillInjection.playerUpdate = playerUpdate;
        passiveSkillInjection.health = playerHealth;
        passiveSkillInjection.gameObject.SetActive(true);
    }
}
