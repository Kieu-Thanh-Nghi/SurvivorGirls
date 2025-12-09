using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/CharacterInputs")]
public class CharacterData : ScriptableObject
{
    [SerializeField] internal float moveSpeed;
    [SerializeField] MoveInput moveInput;
    [SerializeField] internal Vector3 moveDirect { get => moveInput.MoveDirection(); }
    [SerializeField] internal Vector3 moveSpeedDirect { get => moveInput.MoveDirection() * moveSpeed; }
    [SerializeField] internal float runSpeed;
    [SerializeField] internal TurnInput turnInput;
    [SerializeField] internal Vector3 faceDirect;

    public Vector3 SetFaceDirect(Transform character)
    {
        faceDirect = turnInput.GetFaceDirect(character);
        return faceDirect;
    }
}