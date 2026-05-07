using UnityEngine;

public class SkillBook_ASkill : MonoBehaviour
{
    [SerializeField] Sprite theIcon;
    [SerializeField] string skill_name, describe;
    [SerializeField] GameObject skillDetailPrefab;

    public void OpenASkillScreen()
    {
        var aSkillUIDetails = UIManager.instance.aSkillUIDetails;

        aSkillUIDetails.SetDetails(theIcon, skill_name, describe, skillDetailPrefab);
        aSkillUIDetails.gameObject.SetActive(true);
    }
}