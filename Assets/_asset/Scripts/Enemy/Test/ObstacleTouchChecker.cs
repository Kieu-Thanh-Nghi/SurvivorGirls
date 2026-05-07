using UnityEngine;

public class ObstacleTouchChecker : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        var touchedOne = collision.gameObject.GetComponent<IObsTouching>();
        touchedOne?.SetTouchObs(true);
    }

    private void OnCollisionExit(Collision collision)
    {
        var touchedOne = collision.gameObject.GetComponent<IObsTouching>();
        touchedOne?.SetTouchObs(false);      
    }
}