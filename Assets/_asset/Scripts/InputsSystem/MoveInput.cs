using UnityEngine;

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
