using UnityEngine.AI;
using UnityEngine;

public class AddPhysicObstacle : MonoBehaviour
{
    [ContextMenu("add")]
    void AddIt()
    {
        var obs = GetComponentsInChildren<NavMeshObstacle>();
        foreach(var o in obs)
        {
            o.gameObject.AddComponent<BoxCollider>();
            var rid = o.gameObject.AddComponent<Rigidbody>();
            rid.isKinematic = true;
        }
    }

    [ContextMenu("Resize")]
    void Resize()
    {
        var obs = GetComponentsInChildren<NavMeshObstacle>();
        foreach (var o in obs)
        {
            if (o.GetComponent<BoxCollider>() == null) return;
            var col = o.gameObject.GetComponent<BoxCollider>();
            col.size = o.size;
            col.center = o.center;
        }
    }
    [ContextMenu("destroy Col")]
    void des()
    {
        var obs = GetComponentsInChildren<NavMeshObstacle>();
        foreach (var o in obs)
        {
            DestroyImmediate(o.GetComponentInChildren<BoxCollider>());
            DestroyImmediate(o.GetComponentInChildren<Rigidbody>());
        }
    }
}
