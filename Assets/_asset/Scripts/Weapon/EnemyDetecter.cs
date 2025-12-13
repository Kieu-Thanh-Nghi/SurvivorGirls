using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetecter : MonoBehaviour
{
    Collider[] enemiesTemp = new Collider[150];
    [SerializeField] float radius = 1.8f;
    [SerializeField] LayerMask layerMask;
    [SerializeField] int maxN = 10;
    [SerializeField] int no;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    public Vector3 NeareastEnemyPos()
    {
        Vector3 thisPos = transform.position;
        int n = Physics.OverlapSphereNonAlloc(thisPos, radius, enemiesTemp, layerMask);
        no = n;
        return CalculateNeareast(n,thisPos);
    }

    Vector3 CalculateNeareast(int n, Vector3 thisPos)
    {
        int i = 1;
        if (n - maxN > 0)
        {
            int bonus = Random.Range(0, n - maxN);
            i = i + bonus;
            n = maxN + bonus; 
        }

        Vector3 DesirePos = Vector3.zero;
        float distance = 0;
        float tempDistance;
        Vector3 tempEnemyPos;
        if (n > 0)
        {
            tempEnemyPos = enemiesTemp[i - 1].transform.position;
            distance = Vector3.Distance(thisPos, tempEnemyPos);
            DesirePos = tempEnemyPos;
        }
        if (n > 1)
        {
            for (; i < n; i++)
            {
                tempEnemyPos = enemiesTemp[i].transform.position;
                tempDistance = Vector3.Distance(thisPos, tempEnemyPos);
                if (tempDistance < distance)
                {
                    distance = tempDistance;
                    DesirePos = tempEnemyPos;
                }
            }
        }
        return DesirePos;
    }
}
