using UnityEngine;
using TMPro;

public class SkillDetail : MonoBehaviour
{
    [SerializeField] TMP_Text[] detail;
    
    public string GetSkillDetail(int index)
    {
        Debug.Log(Time.time + ":" + index + "-" + detail.Length);
        return detail[index].text;
    }
}