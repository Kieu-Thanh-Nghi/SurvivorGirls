using UnityEngine;

public class SpawnChecker : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] LayerMask layerMask;

    private void OnEnable()
    {
        if(Physics.CheckSphere(transform.position,1, layerMask))
        {
            Debug.Log("ss");
            Ray aRay = new Ray(transform.position, transform.right);
            if(Physics.Raycast(aRay, out RaycastHit hitInfo, 1000f, 7))
            {
                transform.position = hitInfo.point + transform.right;
                Instantiate(enemyPrefab, transform.position, transform.rotation);
            }
        }
        else
        {
            Instantiate(enemyPrefab, transform.position, transform.rotation);
        }
    }
}
