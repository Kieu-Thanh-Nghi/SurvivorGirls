using System.Collections.Generic;
using UnityEngine;

public class LvlPoint : MonoBehaviour, IHasLvlPoint
{
    [SerializeField] int point;
    public int GetLvlPoint()
    {
        return point;
    }
}

public class ExpAttracter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.enabled = false;
    }
}
