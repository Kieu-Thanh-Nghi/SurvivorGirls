using UnityEngine;
using TMPro;

public class ClockUI : MonoBehaviour
{
    [SerializeField] TMP_Text timeText;

    public void UpdateClock()
    {
        timeText.text = SecondsToTotalMinuteSS(
            GamePlayCtrler.Instance.CountingTime);
    }
    public static string SecondsToTotalMinuteSS(float totalSeconds)
    {
        if (totalSeconds < 0f) totalSeconds = 0f;

        int total = Mathf.FloorToInt(totalSeconds);
        int minutes = total / 60;
        int seconds = total % 60;

        return $"{minutes:00}:{seconds:00}";
    }
}