using UnityEngine;

public interface ICharacterAct
{
    void DoAct(Character character);
    void SetValueForActAndAnim();
}

public interface ICharacterAnim
{
    void SetAnim(Character character);
}
