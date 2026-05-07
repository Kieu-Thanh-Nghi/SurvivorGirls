using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [SerializeField] bool isDoneSkillChoosing;
    [SerializeField] internal GameObject SkillChoiceCanvas;
    [SerializeField] internal Image lvlProgressBar;
    [SerializeField] internal TMP_Text currentLvlText;
    [SerializeField] LevelData levelData;
    internal int expInOneFrame; 

    WaitUntil wait;

    [ContextMenu("Up1Level")]
    public void Up1Level()
    {
        expInOneFrame = levelData.currentMaxProgress;
    }

    private void Start()
    {
        wait = new WaitUntil(() => isDoneSkillChoosing);
        lvlProgressBar.fillAmount = 0;
        currentLvlText.text = "1";
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (!other.TryGetComponent<IHasLvlPoint>(out var HasLvlPoint)) return;
    //    int point = HasLvlPoint.GetLvlPoint();
    //    int n = levelData.GetPercentage(point, out float percent);
    //    lvlProgressBar.fillAmount = percent;
    //    if (n > 0)
    //    {
    //        currentLvlText.text = levelData.CurrentLevel.ToString();
    //        StartCoroutine(ChooseSkill(n));
    //    }
    //}

    private void Update()
    {
        UpdatePercentage();
    }

    void UpdatePercentage()
    {
        if(expInOneFrame > 0)
        {
            int n = levelData.GetPercentage(expInOneFrame, out float percent);
            lvlProgressBar.fillAmount = percent;
            if (n > 0)
            {
                currentLvlText.text = levelData.CurrentLevel.ToString();
                StartCoroutine(ChooseSkill(n));
            }
            expInOneFrame = 0;
        }
    }

    public void SetIsDoneChoosing(bool isDone) => isDoneSkillChoosing = isDone;
    IEnumerator ChooseSkill(int n)
    {
        for (int i = 0; i < n; i++)
        {
            TurnSkillChoiceOn();
            yield return wait;
            TurnSkillChoiceOff();
        }
        Time.timeScale = 1;
    }

    void TurnSkillChoiceOn()
    {
        Time.timeScale = 0;
        GamePlayCtrler.Instance.IsPause = true;
        SkillChoiceCanvas.SetActive(true);
    }
    void TurnSkillChoiceOff()
    {
        GamePlayCtrler.Instance.IsPause = false;
        isDoneSkillChoosing = false;
    }

    private void OnDisable()
    {
        var allRemainExp = transform.GetComponentsInChildren<Transform>();
        int n = allRemainExp.Length;
        for(int i = 1; i < n; i++)
        {
            Destroy(allRemainExp[i].gameObject);
        }
    }
}
