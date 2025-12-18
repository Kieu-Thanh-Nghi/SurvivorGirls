using UnityEngine;

public class ExpAttracter : MonoBehaviour
{
    [SerializeField] LevelManager levelManager;
    [SerializeField] int theExp;
    private void OnParticleTrigger()
    {
        levelManager.expInOneFrame += theExp;
        Debug.Log("triggered");
    }
}
