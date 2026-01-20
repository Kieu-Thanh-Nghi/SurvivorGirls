using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Move/MoveInput")]
class PCMoveInput : ScriptableObject, IMoveInput
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

public abstract class MoveInput : MonoBehaviour, IMoveInput
{
    internal Vector3 moveDirect = Vector3.zero;

    public virtual Vector3 GetCurrentMoveDirect() => moveDirect;

    public abstract Vector3 MoveDirection();
}