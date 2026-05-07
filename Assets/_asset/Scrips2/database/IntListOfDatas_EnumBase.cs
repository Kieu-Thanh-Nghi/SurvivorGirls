using AASave;
using UnityEngine;

public class IntListOfDatas_EnumBase<T> where T : System.Enum
{
    [SerializeField] protected int backupVal;
    public virtual int this[T indexes]
    {
        get => LoadIndexes(indexes);
        set => SaveIndexes(indexes, value);
    }
    protected virtual void SaveIndexes(T indexes, int val)
    {
        SaveSystem saveSystem = Database.instance.saveSystem;
        saveSystem.Save(indexes.ToString(), val);
    }
    protected virtual int LoadIndexes(T indexes)
    {
        SaveSystem saveSystem = Database.instance.saveSystem;
        return saveSystem.Load(indexes.ToString(), backupVal);
    }
}
