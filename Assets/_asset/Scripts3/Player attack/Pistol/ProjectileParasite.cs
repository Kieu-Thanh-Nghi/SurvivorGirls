using UnityEngine;
using Lean.Pool;

public class ProjectileParasite : MonoBehaviour
{
    Collider theCollider;
    int oldLayerMask;
    Vector3 oldSize;

    internal void SetupThis(Collider theCollider, int layerInt, float sizeBuff = 1)
    {
        //set coll layer
        this.theCollider = theCollider;
        oldLayerMask = theCollider.gameObject.layer;
        Debug.Log("ProjectileParasite: " + oldLayerMask);
        Debug.Log("ProjectileParasite: " + layerInt);

        theCollider.gameObject.layer = layerInt;
        Debug.Log("ProjectileParasite: " + theCollider.gameObject.layer);


        //set size
        oldSize = theCollider.transform.localScale;
        theCollider.transform.localScale *= sizeBuff;
    }

    private void OnDisable()
    {
        //reset layer
        theCollider.gameObject.layer = oldLayerMask;
        //reset size
        theCollider.transform.localScale = oldSize;
        LeanPool.Despawn(gameObject);
    }
}