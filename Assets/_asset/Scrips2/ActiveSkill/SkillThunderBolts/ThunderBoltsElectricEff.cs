using UnityEngine;
public class ThunderBoltsElectricEff : ElectricEff
{
    internal void SetElecEffTime(float time)
    {
        effectRunner.totalTime = time;
    }
    internal float GetElecEffTime() => effectRunner.totalTime;
}

