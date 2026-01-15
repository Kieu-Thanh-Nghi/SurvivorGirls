using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDetecter : MonoBehaviour
{
    ITargetChangable targetChangable;
    bool isHasBoss;

    // Start is called before the first frame update
    void Start()
    {
        transform.parent.TryGetComponent(out targetChangable);
    }

    private void OnTriggerStay(Collider other)
    {
        if (isHasBoss) return;
        if(other != null)
        {
            targetChangable.SetTarget(other.transform);
            isHasBoss = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        targetChangable.ResetTarget();
        isHasBoss = false;
    }
}
