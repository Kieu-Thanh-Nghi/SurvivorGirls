using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] internal CharacterController charCtlr;
    [SerializeField] internal Animator animator;
    [SerializeField] internal CharacterInput inputs;
    [SerializeField] internal AnimID animID;
    [SerializeField] TurnAround turnAround;
    [SerializeField] Move move;

    private void Update()
    {
        turnAround.CheckDoingAct(this);
    }

    private void FixedUpdate()
    {
        move.CheckDoingAct(this);
    }
}
