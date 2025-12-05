using UnityEngine;
using UnityEditor;

class CharacterInput : MonoBehaviour
{
    [SerializeField] Character character;
    [SerializeField] internal MoveInput moveInput;
    [SerializeField] internal TurnInput turnInput;
}

[CreateAssetMenu(menuName = "ScriptableObject/Move/MoveInput")]
class MoveInput : ScriptableObject
{
    internal virtual Vector3 MoveDirection()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        return new Vector3(x, 0, z);
    }
}

[CreateAssetMenu(menuName = "ScriptableObject/Turn/TurnInput")]
class TurnInput : ScriptableObject
{
    internal Vector3 GetFaceDirect(Transform character)
    {
        Vector2 charPos = Camera.main.WorldToScreenPoint(character.position);
        Vector2 mousePos = Input.mousePosition;
        Vector2 directVector = mousePos - charPos;
        Vector3 finalDirect = character.forward;
        finalDirect.x = directVector.x;
        finalDirect.z = directVector.y;
        return finalDirect.normalized;
    }
}
