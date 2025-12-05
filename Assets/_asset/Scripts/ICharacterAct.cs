using UnityEngine;

public interface ICharacterAct
{
    void DoAct(Character character);
    void SetValueForActAndAnim(Character character);
}

public interface ICharacterAnim
{
    void SetAnim(Character character);
}
