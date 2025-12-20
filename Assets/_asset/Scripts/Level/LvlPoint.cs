using Lean.Pool;
using UnityEngine;

public class LvlPoint : MonoBehaviour, IExpType
{
    [SerializeField] int type;

    public new int GetType()
    {
        LeanPool.Despawn(gameObject);
        return type;
    }
}
