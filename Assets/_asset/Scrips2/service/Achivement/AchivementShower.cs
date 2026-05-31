using UnityEngine;

public class AchivementShower : MonoBehaviour
{
    public void ShowAchive()
    {
        GooglePlayAchievement.Instance.ShowAchievements();
    }
}