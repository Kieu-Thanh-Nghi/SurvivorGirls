using UnityEngine;
using System.Collections;

public class BossSkillManager : MonoBehaviour
{
    [SerializeField] BossSkill[] bossSkills;
    [SerializeField] Enemy enemySelf;
    [SerializeField] float FirstTimeDelay = 4;

    private void Start()
    {
        foreach (var skill in bossSkills)
        {
            skill.SetupSkill();
        }
    }
    private void OnEnable()
    {
        Invoke(nameof(StartFirstTime), FirstTimeDelay);
    }
    void StartFirstTime()
    {
        StartCoroutine(DoSkills());
    }
    IEnumerator DoSkills()
    {
        while (true)
        {
            foreach(var skill in bossSkills)
            {
                skill.ActiveSkill();
                yield return skill.waitDone;
                Debug.Log("done");
                yield return skill.waitCountDown;
                Debug.Log("cd");
            }
        }
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}

[System.Serializable]
public class BossSkill
{
    [SerializeField] internal EnemySkill enemySkill;
    internal WaitUntil waitDone;
    internal WaitForSeconds waitCountDown;

    internal void SetupSkill()
    {
        enemySkill.DoWhenDone += DeactiveSkill;
        waitDone = new WaitUntil(() => enemySkill.gameObject.activeSelf == false);
        waitCountDown = new WaitForSeconds(enemySkill.coolDown);
    }

    internal void ActiveSkill()
    {
        enemySkill.gameObject.SetActive(true);
    }
    internal void DeactiveSkill()
    {
        enemySkill.gameObject.SetActive(false);
    }
}

