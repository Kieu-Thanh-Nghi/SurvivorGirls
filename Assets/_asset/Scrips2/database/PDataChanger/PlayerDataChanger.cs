using UnityEngine;

public abstract class PlayerDataChanger : MonoBehaviour
{
#if UNITY_EDITOR
    [SerializeField] bool isValidate;
    protected void OnValidate()
    {
        if(isValidate) GetComponent<PlayerEquipableItem>().dataChangers.Add(this);
    }
#endif
    public abstract void ChangeData(bool isMinus = false);
}
