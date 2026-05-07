using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSphere : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("cs: exit");
        //enemy di ra thi se bi chyen sang phia ben kia
        var enemyAdapter = other.GetComponent<EnemyAdapter>();
        enemyAdapter.ResetMoveMechanic();
        var enemyAllBody = enemyAdapter.allBody;
        Vector3 relativePosition = transform.InverseTransformPoint(enemyAllBody.position);
        Vector3 newEnemyPos = transform.TransformPoint(-relativePosition * 0.8f);
        newEnemyPos.y = enemyAllBody.position.y;
        enemyAllBody.position = newEnemyPos;
    }
}
