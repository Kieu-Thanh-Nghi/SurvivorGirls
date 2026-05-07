using UnityEngine;

public class ExpDetecter : MonoBehaviour
{
    [SerializeField] LevelManager levelManager;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<IExp>(out var expType)){
            //other.gameObject.SetActive(false);
            expType.PickThisExp(levelManager);
        }
    }
}
