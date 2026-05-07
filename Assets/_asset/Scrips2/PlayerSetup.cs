using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    [SerializeField] PlayerUpdate playerUpdate;
    [SerializeField] Health playerHealth;
    [SerializeField] PlayerHealEff playerHeal;
    [SerializeField] internal LevelManager levelManager;
    [SerializeField] internal Canvas PlayerHPBarCanvas;
    [SerializeField] internal Transform player;
    [SerializeField] internal Transform playerSkin;
    [SerializeField] internal WeaponInjection weaponInjection;
    [SerializeField] internal ActiveSkillInjection activeSkillInjection;
    [SerializeField] internal PassiveSkillInjection passiveSkillInjection;
    [SerializeField] PlayerSkinInfos playerSkinInfos;
    public Transform RotateBody => playerSkin;

    internal static PlayerSetup instance;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [ContextMenu("DoSetup")]
    public void DoSetup()
    {
        playerSkinInfos = playerSkin.GetComponentInChildren<PlayerSkinInfos>();
        playerHealth.OnHurt.AddListener(playerSkinInfos.playerHit.Play);

        playerHeal.smallHeal = playerSkinInfos.smallHeal;
        playerHeal.bigHeal = playerSkinInfos.bigHeal;

        playerUpdate.animID = playerSkin.GetComponent<AnimID>();

        weaponInjection.WeaponSetUp(playerSkin.GetComponent<AllWeaponMuzzle>());
        weaponInjection.gameObject.SetActive(true);

        activeSkillInjection.Player = playerUpdate.transform;
        activeSkillInjection.weaponInjection = weaponInjection;
        activeSkillInjection.gameObject.SetActive(true);

        passiveSkillInjection.playerUpdate = playerUpdate;
        passiveSkillInjection.health = playerHealth;
        passiveSkillInjection.gameObject.SetActive(true);
    }

    public void DeactivePlayer()
    {
        Destroy(playerSkin.gameObject);
        Destroy(weaponInjection.gameObject);
        Destroy(activeSkillInjection.gameObject);
        Destroy(passiveSkillInjection.gameObject);
        player.gameObject.SetActive(false);
    }
}
