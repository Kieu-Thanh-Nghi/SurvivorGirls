using System.Collections.Generic;
using UnityEngine;

public class LvlPoint : MonoBehaviour, IExpType
{
    [SerializeField] int type;

    public new int GetType() => type;
}
