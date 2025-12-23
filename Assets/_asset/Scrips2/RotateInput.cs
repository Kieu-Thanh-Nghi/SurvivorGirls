using UnityEngine;

public class RotateInput : MonoBehaviour, ITurnInput
{
    Vector3 faceDirect;
    public Vector3 GetFaceDirect()
    {
        Vector2 charPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector2 mousePos = Input.mousePosition;
        Vector2 directVector = mousePos - charPos;
        Vector3 finalDirect = transform.forward;
        finalDirect.x = directVector.x;
        finalDirect.z = directVector.y;
        faceDirect = finalDirect.normalized;
        return finalDirect.normalized;
    }

    public Vector3 GetCurrentFaceDirect() => faceDirect;
}