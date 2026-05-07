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

    public Transform GetSquareOfAPosion(Vector3 thePosition)
    {
        var centerSquarePosition = mapRows[1].squres[1].position;
        int row = 1;
        int col = 1;
        float compareNunber = squreLength / 2;

        float x_diffirent = thePosition.x - centerSquarePosition.x;
        if (x_diffirent > compareNunber)
        {
            row = 2;
        }
        else if(x_diffirent < -compareNunber)
        {
            row = 0;
        }

        float z_diffirent = thePosition.z - centerSquarePosition.z;
        if(z_diffirent > compareNunber)
        {
            col = 0;
        }
        else if (z_diffirent < -compareNunber)
        {
            row = 2;
        }

        return mapRows[row].squres[col];
    }
}

[System.Serializable]
public class MapColume
{
    [SerializeField] internal Transform[] squres;
}
