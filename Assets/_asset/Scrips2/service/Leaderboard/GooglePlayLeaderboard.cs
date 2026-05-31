using UnityEngine;
using GooglePlayGames;

public class GooglePlayLeaderboard : MonoBehaviour
{
    public static GooglePlayLeaderboard Instance;

    [Header("Leaderboard ID")]
    [SerializeField]
    private string leaderboardId;

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
    /// Submit score lên leaderboard
    /// </summary>
    public void SubmitScore(long score)
    {
        GooglePlayService.Instance
            .ExecuteWhenAuthenticated(() =>
            {
                PlayGamesPlatform.Instance
                    .ReportScore(
                        score,
                        leaderboardId,
                        success =>
                        {
                            Debug.Log(
                                success
                                    ? $"Submit Score Success: {score}"
                                    : "Submit Score Failed"
                            );
                        });
            });
    }

    /// <summary>
    /// Mở leaderboard UI
    /// </summary>
    public void ShowLeaderboard()
    {
        GooglePlayService.Instance
            .ExecuteWhenAuthenticated(() =>
            {
                PlayGamesPlatform.Instance
                    .ShowLeaderboardUI(
                        leaderboardId
                    );
            });
    }
}
