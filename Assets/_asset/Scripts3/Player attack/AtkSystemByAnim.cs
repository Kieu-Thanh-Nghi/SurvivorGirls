using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkSystemByAnim : AttackSystem
{
    [SerializeField] Animator animator;
    [SerializeField] string triggerName;

    public void SetlayerWeight(int layerIndex, float weight, PlayerAttack playerAttack)
    {
        animator.SetLayerWeight(layerIndex, weight);
        this.playerAttack = playerAttack;
    }   
    
    public void SetlayerWeight(int layerIndex, float weight)
    {
        animator.SetLayerWeight(layerIndex, weight);
    }

    public override void AttackLoop()
    {
        animator.SetTrigger(triggerName);
    }
}
