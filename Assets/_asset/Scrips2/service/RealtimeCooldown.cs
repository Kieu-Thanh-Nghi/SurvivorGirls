using UnityEngine;
using System;

[Serializable]
public class RealtimeCooldown
{
    [SerializeField] private string key;

    public RealtimeCooldown(string key)
    {
        this.key = key;
    }

    // 🔹 Bắt đầu cooldown (seconds)
    public void StartCooldown(int seconds)
    {
        long now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        long endTime = now + seconds;

        PlayerPrefs.SetString(key, endTime.ToString());
        PlayerPrefs.Save();
    }

    // 🔹 Check đã xong chưa
    public bool IsDone()
    {
        if (!PlayerPrefs.HasKey(key))
            return true;

        long now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        long endTime = long.Parse(PlayerPrefs.GetString(key));

        return now >= endTime;
    }

    // 🔹 Lấy số giây còn lại
    public long GetRemainingSeconds()
    {
        if (!PlayerPrefs.HasKey(key))
            return 0;

        long now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        long endTime = long.Parse(PlayerPrefs.GetString(key));

        long remaining = endTime - now;
        return remaining > 0 ? remaining : 0;
    }

    // 🔹 Format "hh:mm:ss" để hiển thị UI
    public string GetTimeText()
    {
        long seconds = GetRemainingSeconds();

        TimeSpan t = TimeSpan.FromSeconds(seconds);

        return $"{t.Hours:D2}:{t.Minutes:D2}:{t.Seconds:D2}";
    }

    public string GetTimeTextShort()
    {
        long seconds = GetRemainingSeconds();

        if (seconds <= 0)
            return "0s";

        TimeSpan t = TimeSpan.FromSeconds(seconds);

        int days = t.Days;
        int hours = t.Hours;
        int minutes = t.Minutes;
        int secs = t.Seconds;

        // 🔥 Ưu tiên đơn vị lớn nhất trước
        if (days > 0)
        {
            if (hours > 0)
                return $"{days}d:{hours}h";
            return $"{days}d:{minutes}m";
        }

        if (hours > 0)
        {
            if (minutes > 0)
                return $"{hours}h:{minutes}m";
            return $"{hours}h:{secs}s";
        }

        if (minutes > 0)
        {
            if (secs > 0)
                return $"{minutes}m:{secs}s";
            return $"{minutes}m";
        }

        return $"{secs}s";
    }

    // 🔹 Xóa cooldown (reset)
    public void Reset()
    {
        StartCooldown(5);
    }
}