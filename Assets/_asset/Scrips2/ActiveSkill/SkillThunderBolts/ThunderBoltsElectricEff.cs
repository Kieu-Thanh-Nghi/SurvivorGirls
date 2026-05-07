using UnityEngine;
public class ThunderBoltsElectricEff : PlayerElectricEff
{
    internal void SetElecEffTime(float time)
    {
        effectRunner.totalTime = time;
    }
    internal float GetElecEffTime() => effectRunner.totalTime;
}

