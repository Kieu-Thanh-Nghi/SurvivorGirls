using UnityEngine;
public class OnlyMove : MonoBehaviour
{
    public virtual void DoAct(Transform character, Vector3 movingSpeedDirect)
    {
        character.position += movingSpeedDirect * Time.fixedDeltaTime;
    }
}