using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "VATAnimData", menuName = "VAT/AnimData")]
public class VATAnimData : ScriptableObject
{
    public List<string> names = new List<string>();
    public List<int> startFrames = new List<int>();
    public List<int> frameCounts = new List<int>();
    public int totalFrames;

    public bool TryGetAnim(string animName, out int startFrame, out int frameCount)
    {
        int index = names.IndexOf(animName);
        return TryGetAnim(index, out startFrame, out frameCount);
    }
    public bool TryGetAnim(int index, out int startFrame, out int frameCount)
    {
        if (index >= 0)
        {
            startFrame = startFrames[index];
            frameCount = frameCounts[index];
            return true;
        }

        startFrame = 0;
        frameCount = 0;
        Debug.LogWarning($"Không tìm thấy animation: {index}");
        return false;
    }
}