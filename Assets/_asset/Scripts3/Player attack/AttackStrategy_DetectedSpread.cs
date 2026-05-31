using UnityEngine;
using System.Collections.Generic;

public class AttackStrategy_DetectedSpread : MonoBehaviour
{
    internal int NeededEnemies;
    internal void ShootNearEnemies(INearestDetecter detecter, AWeapon weapon)
    {
        List<Vector3> targetsPos = detecter.GetManyNearest(NeededEnemies, transform.position);
        int n = targetsPos.Count;
        if (n < 1) return;
        if (n > NeededEnemies) n = NeededEnemies;
        for (int i = 0; i < n; i++)
        {
            weapon?.EmitAnAtk(targetsPos[i]);
        }
    }
}