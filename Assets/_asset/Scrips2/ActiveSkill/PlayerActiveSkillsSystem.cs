using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActiveSkillsSystem : MonoBehaviour
{
    internal List<UpdateSkill> updateSkills = new();

    // Update is called once per frame
    void Update()
    {
        foreach (var skill in updateSkills)
        {
            skill.DoUpdate();
        }
    }
}

public abstract class UpdateSkill : MonoBehaviour
{
    [SerializeField] protected float countDown, activeDuration;
    [SerializeField] protected bool isActive;
    protected float realCountDown => countDown * PlayerParaScale.Instance._coolDown;
    protected float realActiveDuration => activeDuration * PlayerParaScale.Instance._activeDuration;

    protected WaitForSeconds waitCountDown, waitActiveDuration;

    protected virtual void Start()
    {
        waitCountDown = new WaitForSeconds(realCountDown);
        waitActiveDuration = new WaitForSeconds(realActiveDuration);
    }
    public abstract void DoUpdate();

    protected virtual IEnumerator StartSkill()
    {
        while (true)
        {
            BeforeActiveSkill();
            yield return waitActiveDuration;
            AfterActiveSkill();
            yield return waitCountDown;
        }
    }
    protected virtual void BeforeActiveSkill()
    {
        isActive = true;
    }
    protected virtual void AfterActiveSkill()
    {
        isActive = false;
    }
}

public abstract class UpdateSkillWithPaddingActs : UpdateSkill
{
    protected override IEnumerator StartSkill()
    {
        while (true)
        {
            yield return new WaitUntil(() => isActive);
            yield return waitActiveDuration;
            yield return new WaitUntil(() => isActive);
            yield return waitCountDown;
        }
    }
}
