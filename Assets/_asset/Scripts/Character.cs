using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] internal List<UpdateActs> updateActs, fixupdateActs;
    [SerializeField] internal CharacterController charCtlr;
    [SerializeField] internal Animator animator;
    [SerializeField] internal CharacterInput inputs;
    [SerializeField] internal AnimID animID;

}

public class TurnAround : CharacterAct
{

    internal override void DoAct(Character character)
    {
        
    }

    internal override void SetValueForActAndAnim(Character character)
    {
        
    }
}