using System.Collections.Generic;
using UnityEngine;

public class NearestObjectSphereDetecter : MonoBehaviour, INearestDetecter, ISphereDetecter
{
    [SerializeField] LayerMask layerMask;
    [SerializeField] internal float radius, maxRadius;
    internal float tempRadius, tempMaxRadius;
    Collider[] enemiesTemp = new Collider[15];
    Collider[] result = null;
    List<Vector3> enePosies = new List<Vector3>(15);


    private void Start()
    {
        ResetTemp();
    }
    void ResetTemp()
    {
        tempRadius = radius;
        tempMaxRadius = maxRadius;
    }

    public void LimitMaxRadius() => tempMaxRadius = tempRadius;
    int Detect(Vector3 thisPos)
    {
        return Physics.OverlapSphereNonAlloc(thisPos, tempRadius, enemiesTemp, layerMask);
    }

    int NeareastFilter(Vector3 thisPos, int neededQuantity, int tempN, int step = 3)
    {
        result = null;
        int resultN = 0;
        for (int i = 0; i < step; i++)
        {
            if(i > 0) tempN = Detect(thisPos);
            if (tempN > neededQuantity)
            {
                tempMaxRadius = tempRadius;
                tempRadius /= 2;
                result = enemiesTemp;
                resultN = tempN;
            }
            else if (tempN < neededQuantity)
            {
                if (tempRadius == tempMaxRadius) break;
                tempRadius += (tempMaxRadius - tempRadius) / 2;
            }
            else
            {
                result = enemiesTemp;
                ResetTemp();
                return tempN;
            }
        }
        if (result == null)
        {
            result = enemiesTemp;
            resultN = tempN;
        }
        ResetTemp();
        return resultN;
    }
    Transform CalculateNeareast(int n, Vector3 thisPos)
    {
        Transform targetEnemy = null;
        float distance = 0;
        float tempDistance;
        Vector3 tempEnemyPos;

        tempEnemyPos = enemiesTemp[0].transform.position;
        distance = (thisPos - tempEnemyPos).sqrMagnitude;
        targetEnemy = enemiesTemp[0].transform;

        for (int i = 1; i < n; i++)
        {
            tempEnemyPos = enemiesTemp[i].transform.position;
            tempDistance = (thisPos - tempEnemyPos).sqrMagnitude;
            if (tempDistance < distance)
            {
                distance = tempDistance;
                targetEnemy = enemiesTemp[i].transform;
            }
        }
        return targetEnemy;
    }
    public bool GetNearest(Vector3 thisPos, out Transform result)
    {
        int n = Detect(thisPos);
        if (n < 1)
        {
            result = null;
            return false;
        }
        else if(n > 1)
        {
            if(n > 10)
            {
                n = NeareastFilter(thisPos, 1, n, 2);
            }
            result = CalculateNeareast(n, thisPos);
            return true;
        }
        else
        {
            result = enemiesTemp[0].transform;
            return true;
        }
    }
    public List<Vector3> GetManyNearest(int neededQuantity, Vector3 thisPos)
    {
        enePosies.Clear();
        int n = Detect(thisPos);
        n = NeareastFilter(thisPos, neededQuantity, n);
        for (int i = 0; i < n; i++)
        {
            enePosies.Add(result[i].transform.position);
        }
        if (n > neededQuantity)
        {       
            enePosies.Sort((x, y) => (x - thisPos).sqrMagnitude.CompareTo((y - thisPos).sqrMagnitude));
        }
        return enePosies;
    }
}