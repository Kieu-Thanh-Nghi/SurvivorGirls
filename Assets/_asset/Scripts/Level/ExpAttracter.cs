using UnityEngine;

public class ExpAttracter : MonoBehaviour
{
    [SerializeField] LevelManager levelManager;
    [SerializeField] int theExp;
    private void OnParticleTrigger()
    {
        levelManager.expInOneFrame += Mathf.CeilToInt(theExp * PlayerParaScale.Instance._gotExp);
        Debug.Log("triggered");
    }
}
