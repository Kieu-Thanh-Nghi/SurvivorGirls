using System;
using UnityEngine;

public class DailyProduct
{
    private string key;

    public DailyProduct(string key)
    {
        this.key = key;
    }

    // 🔹 Lưu ngày mua (theo UTC)
    public void SaveAchive()
    {
        DateTime today = DateTime.UtcNow.Date;

        PlayerPrefs.SetString(key, today.ToBinary().ToString());
        PlayerPrefs.Save();
    }

    // 🔹 Kiểm tra hôm nay đã mua chưa
    public bool IsAchivedToday()
    {
        if (!PlayerPrefs.HasKey(key))
            return false;

        long binary = Convert.ToInt64(PlayerPrefs.GetString(key));
        DateTime savedDate = DateTime.FromBinary(binary);

        return savedDate == DateTime.UtcNow.Date;
    }

    // 🔹 Kiểm tra đã sang ngày mới chưa (có thể mua lại)
    public bool IsNewDay()
    {
        if (!PlayerPrefs.HasKey(key))
            return true;

        long binary = Convert.ToInt64(PlayerPrefs.GetString(key));
        DateTime savedDate = DateTime.FromBinary(binary);

        return DateTime.UtcNow.Date > savedDate;
    }

    // 🔹 Reset (xóa dữ liệu)
    public void Reset()
    {
        PlayerPrefs.DeleteKey(key);
    }

    // 🔹 (Optional) Lấy ngày đã mua (debug)
    public DateTime GetLastAchiveDate()
    {
        if (!PlayerPrefs.HasKey(key))
            return DateTime.MinValue;

        long binary = Convert.ToInt64(PlayerPrefs.GetString(key));
        return DateTime.FromBinary(binary);
    }
}
