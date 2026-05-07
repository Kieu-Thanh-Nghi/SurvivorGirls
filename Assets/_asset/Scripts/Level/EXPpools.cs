using Lean.Pool;
using UnityEngine;

public class EXPpools : MonoBehaviour
{
    [SerializeField] LeanGameObjectPool[] pools;

    public void SpawnEXP(int type, Vector3 position)
    {
        var theEXP = pools[type].Spawn(GamePlayCtrler.Instance.mapManager.GetSquareOfAPosion(position)).transform;
        var theExpPrefab = pools[type].Prefab.transform;
        theEXP.localScale = theExpPrefab.localScale;
        theEXP.rotation = theExpPrefab.rotation;
        theEXP.position = position;
    }
}
