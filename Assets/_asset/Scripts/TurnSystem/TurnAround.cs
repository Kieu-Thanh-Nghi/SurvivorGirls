using UnityEngine;

public class TurnAround : MonoBehaviour, ICharacterAct
{
    [SerializeField] internal Vector3 currentFaceDirect;
    [SerializeField] TurnAction turnAction;

    public void DoAct(Character character)
    {
        turnAction.LookAtCurrentDirect(character.transform, currentFaceDirect);
    }

    public void SetValueForActAndAnim(Character character)
    {
        currentFaceDirect = character.inputs.turnInput.GetFaceDirect(character.transform);
    }
}

[CreateAssetMenu(menuName = "ScriptableObject/Turn/TurnAction")]
public class TurnAction : ScriptableObject
{
    internal void LookAtCurrentDirect(Transform character, Vector3 currentFaceDirect)
    {
        character.forward = currentFaceDirect;
    }
}