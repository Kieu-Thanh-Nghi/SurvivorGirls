using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Move/MoveInput")]
class MoveInput : ScriptableObject, IMoveInput
{
    Vector3 moveDirect = Vector3.zero;

    public Vector3 GetCurrentMoveDirect() => moveDirect;

    public virtual Vector3 MoveDirection()
    {
        moveDirect.x = Input.GetAxis("Horizontal");
        moveDirect.z = Input.GetAxis("Vertical");
        return moveDirect;
    }
}
