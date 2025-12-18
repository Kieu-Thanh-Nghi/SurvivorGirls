using UnityEngine;
using UnityEngine.AI;
using Lean.Pool;
using System.Collections;

public class SpawnChecker : MonoBehaviour, IPoolable
{
    [SerializeField] float bonusRange = 3;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Enemy EnemyBody;
    [SerializeField] LayerMask layerMask;

    [ContextMenu("start check")]
    public void StartCheck()
    {
        if (RayCheckObs())
        {
            StartCoroutine(CheckIfItObstacle());
        }
        else
        {
            SpawnTheEnemy(transform.position);
        }
        GamePlayCtrler.Instance.AddAnEnemy(EnemyBody);
    }

    IEnumerator CheckIfItObstacle()
    {
        yield return new WaitUntil(() => !RayCheckObs());
        SpawnTheEnemyInObs();
    }

    void SpawnTheEnemyInObs()
    {
        float randomBonusRange = Random.Range(0f, bonusRange);
        Vector3 pos;
        if (Physics.CheckSphere(transform.position + transform.right * randomBonusRange, 0.5f, layerMask))
        {
            pos = transform.position + transform.right;
        }
        else
        {
            pos = transform.position + transform.right * randomBonusRange;
        }
        SpawnTheEnemy(pos);
    }
    void SpawnTheEnemy(Vector3 pos)
    {
        pos.y = 0;
        transform.position = pos;
        EnemyBody.gameObject.SetActive(true);
        agent.enabled = true;
    }

    [ContextMenu("RayCheck")]
    bool RayCheckObs()
    {
        Ray aRay = new Ray(transform.position, transform.up);
        if (Physics.Raycast(aRay, 1000f, layerMask))
        {
            MoveToChoose();
            return true;
        }
        else
        {
            return false;
        }
    }

    void MoveToChoose()
    {
        float speed = 10;
        //transform.forward = transform.position - GamePlayCtrler.Instance.Player.position;
        transform.position += transform.right * speed * Time.deltaTime;
    }

    public void OnSpawn()
    {
        StartCheck();
    }

    public void OnDespawn()
    {
        agent.enabled = false;
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Handles.color = new Color(1, 0, 0, 1f);
    //    Handles.DrawLine(transform.position, 
    //        transform.position + transform.up*3);
    //    Gizmos.DrawSphere(transform.position, 0.4f);
    //}
}
