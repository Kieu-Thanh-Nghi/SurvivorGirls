using UnityEngine;

public class LeaderboardShower : MonoBehaviour
{
    public void ShowBoard()
    {
        GooglePlayLeaderboard.Instance.ShowLeaderboard();
    }
}