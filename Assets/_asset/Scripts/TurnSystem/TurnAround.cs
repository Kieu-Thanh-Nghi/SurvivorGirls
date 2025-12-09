using UnityEngine;

public class TurnAround : MonoBehaviour
{
    internal void LookAtCurrentDirect(Transform character, Vector3 currentFaceDirect)
    {
        character.forward = currentFaceDirect;
    }
}
