using System;
using UnityEngine;

class CharacterInput : MonoBehaviour
{
    internal virtual Vector3 MoveDirection()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        return new Vector3(x, 0, z);
    }
}
