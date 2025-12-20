using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearestEnemyDetecter : EnemyDetecter
{
    Collider[] enemiesTemp = new Collider[150];
    [SerializeField] float radius = 1.8f;
    [SerializeField] LayerMask layerMask;
    [SerializeField] int maxN = 10;
    [SerializeField] int no;
    [SerializeField] bool isDetected;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    public void CheckNeareastEnemy()
    {
        if (target != null && isDetected)
        {
            if (target.gameObject.activeSelf && (target.position - transform.position).sqrMagnitude <= radius * radius)
            {
                return;
            }
        }
        Vector3 thisPos = transform.position;
        int n = Physics.OverlapSphereNonAlloc(thisPos, radius, enemiesTemp, layerMask);
        if (n <= 0) isDetected = false;
        else
        {
            isDetected = true;
            target = CalculateNeareast(n,thisPos);
        }
        no = n;
    }

    Transform CalculateNeareast(int n, Vector3 thisPos)
    {
        int i = 1;
        if (n - maxN > 0)
        {
            int bonus = Random.Range(0, n - maxN);
            i = i + bonus;
            n = maxN + bonus; 
        }

        Vector3 DesirePos = Vector3.zero;
        Transform targetEnemy = null;
        float distance = 0;
        float tempDistance;
        Vector3 tempEnemyPos;
        if (n > 0)
        {
            tempEnemyPos = enemiesTemp[i - 1].transform.position;
            distance = Vector3.Distance(thisPos, tempEnemyPos);
            targetEnemy = enemiesTemp[i - 1].transform;
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
                    targetEnemy = enemiesTemp[i].transform;
                }
            }
        }
        return targetEnemy;
    }

    public override bool GetEnemyPos(out Vector3 Direction)
    {
        CheckNeareastEnemy();
        if (isDetected)
        {
            Direction = target.position;
        }
        else
        {
            Direction = Vector3.zero;
        }
        return isDetected;
    }
}

public abstract class EnemyDetecter : MonoBehaviour
{
    [SerializeField] internal Transform target;
    public abstract bool GetEnemyPos(out Vector3 Direction);
}
