using UnityEngine;

public class TurnAround : CharacterAct
{
    [SerializeField] internal Vector3 currentFaceDirect;
    internal override void DoAct(Character character)
    {
        character.transform.forward = currentFaceDirect;
    }

    internal override void SetValueForActAndAnim(Character character)
    {
        currentFaceDirect = character.inputs.GetFaceDirect();
    }
}