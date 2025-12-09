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
            if(o.shape == NavMeshObstacleShape.Box)
            {
                o.gameObject.AddComponent<BoxCollider>();
            }
            else if(o.shape == NavMeshObstacleShape.Capsule)
            {
                o.gameObject.AddComponent<SphereCollider>();
            }
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
            if (o.GetComponent<Collider>() == null) return;
            if(o.shape == NavMeshObstacleShape.Box)
            {
                var col = o.gameObject.GetComponent<BoxCollider>();
                col.size = o.size;
                col.center = o.center;
            }
            if (o.shape == NavMeshObstacleShape.Capsule)
            {
                var col = o.gameObject.GetComponent<SphereCollider>();
                col.radius = o.radius;
                col.center = o.center;
            }

        }
    }
    [ContextMenu("destroy Col")]
    void des()
    {
        var obs = GetComponentsInChildren<NavMeshObstacle>();
        foreach (var o in obs)
        {
            DestroyImmediate(o.GetComponentInChildren<BoxCollider>()); 
            DestroyImmediate(o.GetComponentInChildren<SphereCollider>());
            DestroyImmediate(o.GetComponentInChildren<Rigidbody>());
        }
    }
}
