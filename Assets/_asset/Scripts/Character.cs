using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] internal Transform allBody;
    [SerializeField] internal CharacterController charCtlr;
    [SerializeField] internal Animator animator;
    [SerializeField] internal CharacterInput inputs;
    [SerializeField] internal AnimID animID;
    [SerializeField] TurnAround turnAround;
    [SerializeField] Move move;

    private void Update()
    {
        CheckDoAct(turnAround);
    }

    private void FixedUpdate()
    {
        CheckDoActWithAnim(move, move);
    }

    void CheckDoAct(ICharacterAct theAct)
    {
        theAct.SetValueForActAndAnim(this);
        theAct.DoAct(this);
    }

    void CheckDoActWithAnim(ICharacterAct theAct, ICharacterAnim theAnim)
    {
        CheckDoAct(theAct);
        theAnim.SetAnim(this);
    }
}
