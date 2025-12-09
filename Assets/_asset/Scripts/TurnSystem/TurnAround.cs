using UnityEngine;

public class TurnAround : MonoBehaviour
{
    [SerializeField] internal Vector3 currentFaceDirect;
    [SerializeField] TurnInput turnInput;

    internal void LookAtCurrentDirect(Transform character)
    {
        character.forward = currentFaceDirect;
    }

    public void SetValue(Transform charTransform)
    {
        currentFaceDirect = turnInput.GetFaceDirect(charTransform);
    }
}
