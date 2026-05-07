using UnityEngine;

public class AddObsTouch : MonoBehaviour
{
    [ContextMenu("add")]
    void AddIt()
    {
        var obs = GetComponentsInChildren<Collider>();
        foreach (var o in obs)
        {
            o.gameObject.AddComponent<ObstacleTouchChecker>();
        }
    }

    [ContextMenu("destroy ObsTouch")]
    void des()
    {
        var obs = GetComponentsInChildren<Collider>();
        foreach (var o in obs)
        {
            DestroyImmediate(o.GetComponentInChildren<ObstacleTouchChecker>());
        }
    }
}