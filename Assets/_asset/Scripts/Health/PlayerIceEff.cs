using UnityEngine;

public class PlayerIceEff : IceEff
{
    internal override float TotalTime
        => base.TotalTime * (1 + PlayerDataManager.Instance.ElementBoost);
}