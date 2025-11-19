using UnityEngine;

class CharacterInput : MonoBehaviour
{
    [SerializeField] Character character;
    internal virtual Vector3 MoveDirection()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        return new Vector3(x, 0, z);
    }

    internal Vector3 GetFaceDirect()
    {
        Vector2 charPos = Camera.main.WorldToScreenPoint(character.transform.position);
        Vector2 mousePos = Input.mousePosition;
        Vector2 directVector = mousePos - charPos;
        Vector3 finalDirect = character.transform.forward;
        finalDirect.x = directVector.x;
        finalDirect.z = directVector.y;
        return finalDirect.normalized;
    }
}
