using UnityEngine;

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
