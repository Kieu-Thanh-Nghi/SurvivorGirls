using UnityEngine;

public class LevelData : MonoBehaviour
{
    [SerializeField] Vector2[] LvlsAndMaxProcess;
    [SerializeField] public int CurrentLevel;
    int currentProgress;
    int currentIndex = 0;
    [SerializeField] int length;
    [SerializeField] internal int currentMaxProgress;

    private void OnValidate()
    {
        length = LvlsAndMaxProcess.Length;
        if (length > 0) currentMaxProgress = (int)LvlsAndMaxProcess[0].y;
    }
    public int GetPercentage(int addPoint, out float percentage)
    {
        currentProgress += addPoint;
        int n = 0;
        while(currentProgress >= currentMaxProgress)
        {
            currentProgress -= currentMaxProgress;
            CurrentLevel++;
            if (currentIndex < length - 1)
            {
                if(CurrentLevel >= LvlsAndMaxProcess[currentIndex + 1].x)
                {
                    currentIndex++;
                    currentMaxProgress = (int)LvlsAndMaxProcess[currentIndex].y;
                }
            }
            n++;
        }
        percentage = (float)currentProgress / currentMaxProgress;
        return n;
    }
}
