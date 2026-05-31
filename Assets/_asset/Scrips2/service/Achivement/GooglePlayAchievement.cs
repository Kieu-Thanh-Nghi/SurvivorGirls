using UnityEngine;
using GooglePlayGames;
using TigerForge;
using System;

public class GooglePlayAchievement : MonoBehaviour
{
    public static GooglePlayAchievement Instance;
    private void Awake()
    {
        // Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Unlock achievement thường
    /// </summary>
    public void UnlockAchievement(
        string achievementId
    )
    {
        GooglePlayService.Instance
            .ExecuteWhenAuthenticated(() =>
            {
                PlayGamesPlatform.Instance
                    .UnlockAchievement(
                        achievementId,
                        success =>
                        {
                            Debug.Log(
                                success
                                    ? $"Unlock Success: {achievementId}"
                                    : $"Unlock Failed: {achievementId}"
                            );
                        });
            });
    }

    /// <summary>
    /// Increment achievement
    /// dành cho achievement có progress
    /// </summary>
    public void IncrementAchievement(
        string achievementId,
        int steps
    )
    {
        GooglePlayService.Instance
            .ExecuteWhenAuthenticated(() =>
            {
                PlayGamesPlatform.Instance
                    .IncrementAchievement(
                        achievementId,
                        steps,
                        success =>
                        {
                            Debug.Log(
                                success
                                    ? $"Increment Success: {achievementId} +{steps}"
                                    : $"Increment Failed: {achievementId}"
                            );
                        });
            });
    }

    /// <summary>
    /// Mở achievement UI
    /// </summary>
    public void ShowAchievements()
    {
        GooglePlayService.Instance
            .ExecuteWhenAuthenticated(() =>
            {
                PlayGamesPlatform.Instance
                    .ShowAchievementsUI();
            });
    }

    public void IsAchievementUnlocked(
        string achievementId,
        Action<bool> callback
    )
    {
        GooglePlayService.Instance
            .ExecuteWhenAuthenticated(() =>
            {
                PlayGamesPlatform.Instance
                    .LoadAchievements(result =>
                    {
                        if (result == null)
                        {
                            callback?.Invoke(false);
                            return;
                        }

                        foreach (var achievement in result)
                        {
                        // Tìm đúng achievement ID
                        if (achievement.id == achievementId)
                            {
                            // completed = true nghĩa là đã unlock
                            callback?.Invoke(
                                achievement.completed
                            );

                                return;
                            }
                        }

                        callback?.Invoke(false);
                    });
            });
    }
}

public abstract class AchivementMeasurement : MonoBehaviour
{
    [SerializeField] protected string achievementId;
    private void Start()
    {
        GooglePlayAchievement.Instance.IsAchievementUnlocked(achievementId, SubsTheMeasurement);
    }

    void SubsTheMeasurement(bool isAchiveCompleted)
    {
        if (isAchiveCompleted) Destroy(this);
    }

    public abstract void AchivementUpdate();
}
