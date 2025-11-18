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

public abstract class UpdateActs : MonoBehaviour
{
    [SerializeField] protected Character character;
#if UNITY_EDITOR
    internal virtual bool isUpdate_editorOnly => true;
    internal virtual bool isFixUpdate_editorOnly => false;

    private void OnValidate()
    {
        character = GetComponentInParent<Character>();
        if (character == null) {Debug.Log("khong co character"); return; } 
        if (isUpdate_editorOnly) character?.updateActs.Add(this);
        if (isFixUpdate_editorOnly) character?.fixupdateActs.Add(this);
    }
#endif
    internal abstract void CheckIfDoAct_update();
    internal abstract void CheckIfDoAct_fixUpdate();
}
