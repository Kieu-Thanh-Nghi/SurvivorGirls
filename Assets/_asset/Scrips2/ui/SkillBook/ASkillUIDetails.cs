using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ASkillUIDetails : MonoBehaviour
{
    [SerializeField] Image skillIcon;
    [SerializeField] TMP_Text skillName, describe;
    [SerializeField] Transform skillDetailsContainer;

    public void SetDetails(Sprite skill_icon, string skill_name, 
        string skill_describe, GameObject skillDetails)
    {
        skillIcon.sprite = skill_icon;
        skillName.text = skill_name;
        describe.text = skill_describe;

        Instantiate(skillDetails, skillDetailsContainer);
    }

    private void OnDisable()
    {
        var detail = skillDetailsContainer.GetChild(0);
        if (detail != null)
        {
            Destroy(detail.gameObject);
        }
    }
}