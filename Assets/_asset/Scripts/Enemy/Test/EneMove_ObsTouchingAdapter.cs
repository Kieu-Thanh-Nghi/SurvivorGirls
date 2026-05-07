using UnityEngine;

public class EneMove_ObsTouchingAdapter : MonoBehaviour, IObsTouching
{
    [SerializeField] Enemy enemy;
    public void SetTouchObs(bool isTouch)
    {
        enemy.moveManagement.OnTouchedObs(enemy.Target, isTouch);
    }
}