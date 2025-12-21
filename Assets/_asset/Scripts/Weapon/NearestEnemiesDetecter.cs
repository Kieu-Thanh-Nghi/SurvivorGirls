using System.Collections.Generic;
using UnityEngine;

public class NearestEnemiesDetecter : MonoBehaviour
{
    [SerializeField] float radius = 5.4f, maxRadius = 12;
    [SerializeField] LayerMask layerMask;
    Collider[] enemiesTemp = new Collider[15];
    Collider[] result = new Collider[15];
    List<Vector3> enePosies = new List<Vector3>(15);
    int n;
    public void CheckNeareastEnemies(int neededQuantity)
    {
        Vector3 thisPos = transform.position;
        float tempRadius = radius;
        float tempMaxRadius = maxRadius;
        bool isR = false;
        int tempN = 0;
        for (int i = 0; i < 4; i++)
        {
            tempN = Physics.OverlapSphereNonAlloc(thisPos, tempRadius, enemiesTemp, layerMask);
            if(tempN > neededQuantity)
            {
                tempMaxRadius = tempRadius;
                tempRadius /= 2;
                result = enemiesTemp;
                n = tempN;
                isR = true;
            }
            else if(tempN < neededQuantity)
            {
                tempRadius += (tempMaxRadius - tempRadius) / 2;
            }
            else
            {
                result = enemiesTemp;
                n = tempN;
            }
        }
        if (!isR)
        {
            result = enemiesTemp;
            n = tempN;
        }
    }
    public List<Vector3> GetNearestEnemies(int neededQuantity)
    {
        Vector3 thisPos = transform.position;
        enePosies.Clear();
        CheckNeareastEnemies(neededQuantity);
        if(n < neededQuantity)
        {
            for (int i = 0; i < n; i++)
            {
                enePosies.Add(result[i].transform.position);
            }
        }
        else
        {
            for (int i = 0; i < neededQuantity; i++)
            {
                enePosies.Add(result[i].transform.position);
            }
        }
        enePosies.Sort((x, y) => (x - thisPos).sqrMagnitude.CompareTo((y - thisPos).sqrMagnitude));
        return enePosies;
    }
}
