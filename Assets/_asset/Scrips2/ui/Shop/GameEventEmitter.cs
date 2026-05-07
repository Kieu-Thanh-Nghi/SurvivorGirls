using UnityEngine;
using TigerForge;

public class GameEventEmitter : MonoBehaviour
{
    [SerializeField] GameEvents theEvent;
    public void EmitThisEvent()
    {
        EventManager.EmitEvent(theEvent.ToString());
    }
}

public enum GameEvents
{
    DrawChip,
    DrawEquipment,
    WeaponLvlUp,
    NormalZombiesKilled,
    StageClear,
    BossKilled,
    EvMergeEquipment,
    EvRankupWeapon,
    EvCompleteDailyMission,
    PlayerDead,
    EndGameImmediate
}