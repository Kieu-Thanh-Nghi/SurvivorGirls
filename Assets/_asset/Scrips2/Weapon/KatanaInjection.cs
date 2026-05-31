using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatanaInjection : WeaponSkillInjection
{
    [SerializeField] internal ProjectileEmiter bulletParticleSystem;

}

public class MeleAtkSystem : MonoBehaviour
{
    [SerializeField] PlayerManager playerManager;

    private void Start()
    {
        
    }
}
