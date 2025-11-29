using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] Transform mapPivot;
    [SerializeField] float maxDistance = 40;
    [SerializeField] float squreLength = 60;
    [SerializeField] MapColume[] mapRows;
    Vector3 distance;

    private void Update()
    {
        distance = GamePlayCtrler.Instance.Player.position - mapPivot.position;
        if (distance.z > maxDistance)
        {
            mapPivot.position += Vector3.forward * squreLength;
            RowSwap(mapRows, true);
        }
        else if(distance.z < -maxDistance)
        {
            mapPivot.position -= Vector3.forward * squreLength;
            RowSwap(mapRows, false);
        }

        if (distance.x > maxDistance)
        {
            mapPivot.position += Vector3.right * squreLength;
            foreach(var row in mapRows)
            {
                ColumeSwap(row.squres, true);
            }
        }
        else if (distance.x < -maxDistance)
        {
            mapPivot.position -= Vector3.right * squreLength;
            foreach (var row in mapRows)
            {
                ColumeSwap(row.squres, false);
            }
        }
    }

    void ColumeSwap(Transform[] columes, bool isPositive)
    {
        int n = columes.Length;
        Transform temp;
        if (isPositive)
        {
            temp = columes[0];
            for(int i = 1; i < n; i++)
            {
                columes[i - 1] = columes[i];

            }
            columes[n - 1] = temp;
            columes[n - 1].position += Vector3.right * 3 * squreLength;
        }
        else
        {
            temp = columes[n - 1];
            for (int i = n - 1; i > 0; i--)
            {
                columes[i] = columes[i - 1];
            }
            columes[0] = temp;
            columes[0].position -= Vector3.right * 3 * squreLength;
        }
    }

    void RowSwap(MapColume[] rows, bool isPositive)
    {
        int n = rows.Length;
        MapColume temp;
        if (!isPositive)
        {
            temp = rows[0];
            for (int i = 1; i < n; i++)
            {
                rows[i - 1] = rows[i];
            }
            rows[n - 1] = temp;
            foreach(var row in rows[n - 1].squres)
            {
                row.position -= Vector3.forward * 3 * squreLength;
            }
        }
        else
        {
            temp = rows[n - 1];
            for (int i = n - 1; i > 0; i--)
            {
                rows[i] = rows[i - 1];
            }
            rows[0] = temp;
            foreach (var row in rows[0].squres)
            {
                row.position += Vector3.forward * 3 * squreLength;
            }
        }
    }
}

[System.Serializable]
public class MapColume
{
    [SerializeField] internal Transform[] squres;
}
