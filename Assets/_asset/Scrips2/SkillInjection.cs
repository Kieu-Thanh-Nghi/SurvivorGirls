using System.Collections.Generic;
using UnityEngine;

public class SkillInjection : MonoBehaviour, ISkillInjection
{
    [SerializeField] protected int skillQuantity;
    [SerializeField] internal List<Skill> skillList;
    [SerializeField] protected List<int> skillIndex;
    [SerializeField] protected List<int> usingSkill;
    protected int resultEnum;
    int fullLvlSkillCount;
    int usedSkillCount;
    internal int selectedTimes;

    [SerializeField] internal AbstractSkillData SkillData;

#if UNITY_EDITOR
    [SerializeField] protected bool isValidate;
    protected void OnValidate()
    {
        if (!isValidate) return;
        skillIndex.Clear();
        skillList.Sort((x, y) => (x.thisEnumInt).CompareTo(y.thisEnumInt));
        int last = skillList[skillList.Count - 1].thisEnumInt;

        var tempList = new List<Skill>(last + 1);
        foreach (var aSkill in skillList)
        {
            tempList.Insert(aSkill.thisEnumInt, aSkill);
        }
        skillList = tempList;

        foreach (var aSkill in skillList)
        {
            if(aSkill != null) skillIndex.Add(aSkill.thisEnumInt);
        }
    }
#endif

    protected virtual void Start()
    {
        usingSkill = new List<int>(skillQuantity);
        fullLvlSkillCount = 0;
        usedSkillCount = 0;
        //thirdSkill = new PistolThirdSkill();

        //InjectFirstSkill();
        //InjectSecondSkill();
        //InjectThirdSkill();
    }

    public void ResetToNew()
    {
        skillIndex.Clear();
        foreach (var aSkill in skillList)
        {
            if (aSkill != null) skillIndex.Add(aSkill.thisEnumInt);
        }
        foreach(var e in usingSkill)
        {
            skillList[e].currentLV = 0;
        }
        usingSkill.Clear();
        fullLvlSkillCount = 0;
        usedSkillCount = 0;
        selectedTimes = 0;
    }

    public virtual int ChoseSkill(out int skillLvl)
    {
        if(fullLvlSkillCount >= skillQuantity)
        {
            skillLvl = -1;
            return -1;
        }
        var theList = PickList();
        int n = theList.Count;
        return CalculateChosenSkill(n, theList, out skillLvl);
    }

    public virtual SkillInfos GetSkillInfos(int theSkillIndex)
    {
        if (theSkillIndex < 0) return null;
        return SkillData.GetASkillInfo(theSkillIndex);
    }

    protected virtual int CalculateChosenSkill(int n, List<int> theList, out int skillLvl)
    {
        if (n <= selectedTimes)
        {
            skillLvl = -1;
            return -1;
        }
        int lastIndex = n - selectedTimes;
        int i = Random.Range(0, lastIndex);
        resultEnum = theList[i];
        Swap(i, lastIndex - 1, theList);
        selectedTimes++;
        skillLvl = skillList[resultEnum].currentLV;
        return resultEnum;
    }

    protected void Swap(int a, int b, List<int> theList)
    {
        if (a >= b) return;
        Debug.Log(a + "-" + b);
        Debug.Log(theList.Count);
        var temp = theList[a];
        theList[a] = theList[b];
        theList[b] = temp;
    }
    List<int> PickList()
    {
        if (usedSkillCount >= skillQuantity)
        {
            Debug.Log("a");
            return usingSkill;
        }
        else
        {
            Debug.Log("b");
            return skillIndex;
        }
    }

    protected virtual void OnDestroy()
    {
        
    }
    public virtual void UpgradeASkill(int skillEnum)
    {
        var result = skillList[skillEnum];
        if (result.currentLV == 0)
        {
            result.SetSkillInjection(this);
            usingSkill.Add(skillEnum); 
            usedSkillCount++;
        }
        if (result.UpgradeSkill())
        {
            usingSkill.Remove(skillEnum);
            skillIndex.Remove(skillEnum);
            fullLvlSkillCount++;
            Debug.Log("skill done: " + result.name + " " + fullLvlSkillCount+"," +skillQuantity);
        }
    }
}
