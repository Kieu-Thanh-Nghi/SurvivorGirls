using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimID : MonoBehaviour
{
    [SerializeField] internal int MoveSpeedX;
    [SerializeField] internal int MoveSpeedZ;

    private void OnValidate()
    {
        MoveSpeedX = Animator.StringToHash("MoveSpeedX");
        MoveSpeedZ = Animator.StringToHash("MoveSpeedZ");
    }
}
