using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistInject : MonoBehaviour
{
    PistolFirstSkill firstSkill;
    PistolSecondSkill secondSkill;
    PistolThirdSkill thirdSkill;

    public bool UpgradeSkill_1()
    {
        int firstSkillLV = firstSkill.currentLV;
        if (firstSkillLV >= 5) return true;
        switch (firstSkillLV)
        {
            case 0:
                firstSkill.ToLV1();
                break;
            case 1:
                firstSkill.ToLV2();
                break;
            case 2:
                firstSkill.ToLV3();
                break;
            case 3:
                firstSkill.ToLV4();
                break;
            case 4:
                firstSkill.ToLV5();
                break;
        }
        firstSkill.currentLV++;
        return false;
    }
    public bool UpgradeSkill_2()
    {
        int firstSkillLV = secondSkill.currentLV;
        if (firstSkillLV >= 5) return true;
        switch (firstSkillLV)
        {
            case 0:
                secondSkill.ToLV1();
                break;
            case 1:
                secondSkill.ToLV2();
                break;
            case 2:
                secondSkill.ToLV3();
                break;
            case 3:
                secondSkill.ToLV4();
                break;
            case 4:
                secondSkill.ToLV5();
                break;
        }
        secondSkill.currentLV++;
        return false;
    }
    public bool UpgradeSkill_3()
    {
        int firstSkillLV = thirdSkill.currentLV;
        if (firstSkillLV >= 5) return true;
        switch (firstSkillLV)
        {
            case 0:
                thirdSkill.ToLV1();
                break;
            case 1:
                thirdSkill.ToLV2();
                break;
            case 2:
                thirdSkill.ToLV3();
                break;
            case 3:
                thirdSkill.ToLV4();
                break;
            case 4:
                thirdSkill.ToLV5();
                break;
        }
        thirdSkill.currentLV++;
        return false;
    }
}

class PistolFirstSkill 
{
    public int currentLV;
    public void ToLV1() { }
    public void ToLV2() { }
    public void ToLV3() { }
    public void ToLV4() { }
    public void ToLV5() { }
}
class PistolSecondSkill
{
    public int currentLV;
    public void ToLV1() { }
    public void ToLV2() { }
    public void ToLV3() { }
    public void ToLV4() { }
    public void ToLV5() { }
}
class PistolThirdSkill
{
    public int currentLV;
    public void ToLV1() { }
    public void ToLV2() { }
    public void ToLV3() { }
    public void ToLV4() { }
    public void ToLV5() { }
}