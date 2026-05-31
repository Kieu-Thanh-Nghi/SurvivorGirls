using UnityEngine;
using UnityEngine.Events;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] internal AWeapon weapon;
    [SerializeField] internal Transform rotateBody;
    internal UnityAction DoWhenDoneAnAtk;
    bool _isDone = true;
    public bool IsDone
    {
        get => _isDone;
        set => _isDone = value;
    }

    public virtual void DoAttack()
    {
        weapon.EmitAnAtk();
        DoWhenDoneAnAtk?.Invoke();
    }
}
