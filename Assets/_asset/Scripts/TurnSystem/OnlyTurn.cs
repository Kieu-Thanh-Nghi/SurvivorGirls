using UnityEngine;

public class OnlyTurn : MonoBehaviour
{
    [SerializeField] internal Vector3 currentFaceDirect;
    internal void LookAtCurrentDirect(Transform character)
    {
        character.forward = currentFaceDirect;
    }
}
