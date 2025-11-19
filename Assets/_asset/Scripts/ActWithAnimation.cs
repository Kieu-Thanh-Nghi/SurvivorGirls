using UnityEngine;
using UnityEngine.Events;

public abstract class ActWithAnimation : CharacterAct
{
    internal override void CheckDoingAct(Character character)
    {
        base.CheckDoingAct(character);
        SetAnimVal(character);
    }
    internal abstract void SetAnimVal(Character character);
}

public abstract class CharacterAct : MonoBehaviour
{
    internal virtual void CheckDoingAct(Character character)
    {
        SetValueForActAndAnim(character);
        DoAct(character);
    }
    internal abstract void DoAct(Character character);
    internal abstract void SetValueForActAndAnim(Character character);
}
