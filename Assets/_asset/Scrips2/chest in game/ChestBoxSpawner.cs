using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

public class ChestBoxSpawner : MonoBehaviour, IHasCoolDown
{
    [SerializeField] LayerMask ObstacleMask;
    [SerializeField] float minDistance, maxDistance;
    [SerializeField] float boxSpawnCoolDownMin, boxSpawnCoolDownMax;
    float realCoolDown;
    [SerializeField] CoolDownSystem coolDownSystem;
    [SerializeField] LeanGameObjectPool lootBoxPool;

    public float GetCoolDown()
    {
        return realCoolDown;
    }

    public void Start()
    {
        StartCoroutine(coolDownSystem.RunEffInCoolDown(SpawnLootBox, this, false));
    }

    void SpawnLootBox()
    {
        var spawnPos = GetSpawnPos();
        var theLand = GamePlayCtrler.Instance.mapManager.GetSquareOfAPosion(transform.position);
        var box = lootBoxPool.Spawn(theLand, true);
        box.transform.position = spawnPos;
        realCoolDown = Random.Range(boxSpawnCoolDownMin, boxSpawnCoolDownMax);
    }

    Vector3 GetSpawnPos()
    {
        //random angle
        var angle = Random.Range(0, 361);
        transform.Rotate(Vector3.up, angle);

        //random distance
        float distance = Random.Range(minDistance, maxDistance);

        //
        var thePos = transform.position + transform.forward * distance;
        if (Physics.CheckSphere(thePos, 0.5f, ObstacleMask))
        {
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, distance, ObstacleMask))
            {
                return hitInfo.point;
            }
            else
            {
                return thePos;
            }
        }
        else
        {
            return thePos;
        }
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
